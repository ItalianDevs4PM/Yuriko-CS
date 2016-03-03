/*
 *
 * _   __          _ _                ____ ____  
 *\ \ / /   _ _ __(_) | _____        / ___/ ___| 
 * \ V / | | | '__| | |/ / _ \ _____| |   \___ \ 
 *  | || |_| | |  | |   < (_) |_____| |___ ___) |
 *  |_| \__,_|_|  |_|_|\_\___/       \____|____/ 
 *
 * Yuriko-CS, brand a new Minecraft: Pocket Edition
 * server software in C#
 * Copyright 2016 ItalianDevs4PM.
 * 
 * Modifications and implementations of this software
 * which are made by ItalianDevs4PM or affiliates/contributors
 * are licensed under Creative Commons
 * Attribution-NonCommercial-NoDerivatives 4.0
 * International License.
 *
 *
 * @author ItalianDevs4PM
 * @link   http://github.com/ItalianDevs4PM
 *
 *
 */

using System;
using System.Collections.Generic;
using System.Net;
using System.Net.Sockets;
using System.Threading;

namespace YurikoCS {
	class PacketHandler {
		private int port;
		private int spacketcount = 0;
		private int test = 0;
		private byte[] data;
		public static UdpClient server;

		public PacketHandler(int port){
			this.port = port;
		}

		public void Start(){
			server = new UdpClient(port);
			server.Client.ReceiveBufferSize = 1024*1024*3;
			server.Client.SendBufferSize = 4096;
			data = new byte[64];
			test = 0;
			BeginReceive();
		}

		private void BeginReceive(){
			server.BeginReceive(ReceiveCallback, server);
		}

		public void StartSendThread(){
			SendPacketThread();
		}
		
		private void ReceiveCallback(IAsyncResult res){
			try{
				IPEndPoint sender = new IPEndPoint(IPAddress.Any, 0);
				UdpClient server = (UdpClient) res.AsyncState;
				byte[] data = server.EndReceive(res, ref sender);
				if(data[0] == PacketID.MCPE_UNCONNECTED_PING){	//Send Motd on UNCONNECTED_PING request
					UnconnectedPongPacket packet = new UnconnectedPongPacket();
					packet.PingID = 45; //To-Do
					packet.ServerName = Server.GetInstance().GetMotd();
					byte[] content = packet.Encode();
					server.Send(content, content.Length, sender);
				}else if(data[0] == PacketID.MCPE_OPEN_CONNECTION_REQUEST){	//Initialize Client connection
					OpenConnectionReplyPacket packet = new OpenConnectionReplyPacket();
					packet.MtuSize = (short)(data.Length - 17);
					byte[] content = packet.Encode();
					server.Send(content, content.Length, sender);
				}else if(data[0] == PacketID.MCPE_OPEN_CONNECTION_REQUEST_2){	//Continue Client connection
					OpenConnectionRequest2Packet req2packet = new OpenConnectionRequest2Packet();
					req2packet.data = data;
					req2packet.Decode();
					OpenConnectionReply2Packet reply2packet = new OpenConnectionReply2Packet();
					reply2packet.ClientPort = (short) sender.Port;
					reply2packet.MtuSize = req2packet.MtuSize;
					byte[] content = reply2packet.Encode();
					server.Send(content, content.Length, sender);
				}else if((data[0] >= 0x80 && data[0] <= 0x8F) || data[0] == PacketID.ACK || data[0] == PacketID.NACK){	//Encoded Packet sender
					bool alreadyInitialized = false;
					Player pl;
					List<Player> onlineplayers = Server.GetInstance().GetOnlinePlayers();
					foreach(Player player in onlineplayers){
						if(player.GetIPEndPoint() == sender){
							alreadyInitialized = true;
							pl = player;
							pl.HandleDataPackets(data, res);
							break;
						}
					}
					if(!alreadyInitialized){
						pl = new Player(sender);
						pl.HandleDataPackets(data, res);
					}
				}
				if(res.IsCompleted){
					BeginReceive();
				}
			}catch(Exception ex){
				Console.WriteLine(ex.GetBaseException());
			}
		}

		private void SendPacketThread(){
			while(true){
				Player[] onlineplayers = Server.GetInstance().GetOnlinePlayers().ToArray();
				foreach(Player player in onlineplayers){
					// Fix Collection was modified... exception!
					lock (player.GetPacketQueue().Keys){
						List<int> PlayerPacketsQueue = new List<int>(player.GetPacketQueue().Keys);
						foreach(int key in PlayerPacketsQueue){
							if(player.GetPacketQueue().ContainsKey(key)){
								Packet packet = player.GetPacketQueue()[key];
								byte[] content = packet.Encode();
								server.Send(content, content.Length, player.GetIPEndPoint());
							}
						}
					}
				}
				Thread.Sleep(400);
			}
		}
	}
}
	
