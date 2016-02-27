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

namespace YurikoCS {
	class PacketListener {
		public static UdpClient server;
		private int port;
		private byte[] data;

		public PacketListener(int port){
			this.port = port;
		}

		public void Start(){
			server = new UdpClient(port);
			data = new byte[64];
			receivePackets();
		}

		private void receivePackets(){
			IPEndPoint sender = new IPEndPoint(IPAddress.Any, 0);
			while(true){
				data = server.Receive(ref sender);
				if(data[0] == PacketID.MCPE_UNCONNECTED_PING){	//Send Motd on UNCONNECTED_PING request
					UnconnectedPongPacket packet = new UnconnectedPongPacket(45, Server.GetInstance().GetMotd());
					server.Send(packet.GetContent(), packet.GetContent().Length, sender);
				}else if(data[0] == PacketID.MCPE_OPEN_CONNECTION_REQUEST){	//Initialize Client connection
					OpenConnectionReplyPacket packet = new OpenConnectionReplyPacket((short)(data.Length - 17));
					server.Send(packet.GetContent(), packet.GetContent().Length, sender);
				}else if(data[0] == PacketID.MCPE_OPEN_CONNECTION_REQUEST_2){	//Continue Client connection
					OpenConnectionRequest2Packet req2packet = new OpenConnectionRequest2Packet(data);
					OpenConnectionReply2Packet reply2packet = new OpenConnectionReply2Packet((short) sender.Port, req2packet.mtusize);
					server.Send(reply2packet.GetContent(), reply2packet.GetContent().Length, sender);
				}else if(data[0] >= 0x80 && data[0] <= 0x8F){	//Client Login
					EncapsulationHelper helper = EncapsulationHelper.Decode(data);
					byte packetID = helper.GetPacketID();
					Logger.GetLogger().Debug(packetID.ToString("X2"));
					//Process packet
					if(packetID == PacketID.MCPE_PING_PACKET){
						PingPacket ping = new PingPacket(data);
						PongPacket pong = new PongPacket(ping.Identifier, helper.GetPacketCount());
						//server.Send(pong.GetContent(), pong.GetContent().Length, sender);
					}else{
						//Send ACK to Client
						ACK ack = new ACK(new Triad(helper.GetPacketCount().ToInt32()));
						server.Send(ack.GetContent(), ack.GetContent().Length, sender);
						if(packetID == PacketID.MCPE_CLIENT_CONNECT_PACKET){
							ClientConnectPacket ccp = new ClientConnectPacket(data);
							//ACK ack = new ACK(ccp, new Triad(0));
							//server.Send(ack.GetContent(), ack.GetContent().Length, sender);
							ServerHandshakePacket shp = new ServerHandshakePacket((short) port, ccp.Session, new Triad(0));
							server.Send(shp.GetContent(), shp.GetContent().Length, sender);
							Logger.GetLogger().Info("[§b" + sender.Address + ":" + sender.Port + "§f] connected to the server");
						}else if(packetID == PacketID.MCPE_LOGIN_PACKET){
							LoginPacket lpacket = new LoginPacket(data);
							//CALL PRELOGIN EVENT HERE
							LoginStatusPacket lstatus = new LoginStatusPacket(1, new Triad(1)); //To-Do
							server.Send(lstatus.GetContent(), lstatus.GetContent().Length, sender);
							//CALL LOGIN EVENT HERE
							StartGamePacket startgame = new StartGamePacket(100, 100, 1, 0, 128, 0, 0, 0, 0, new Triad(2)); //To-Do
							server.Send(startgame.GetContent(), startgame.GetContent().Length, sender);
							Logger.GetLogger().Info("§e" + lpacket.Username + " joined the game");
							SetTimePacket settime = new SetTimePacket(1000, new Triad(3)); //To-Do
							server.Send(settime.GetContent(), settime.GetContent().Length, sender);
							//CALL JOIN EVENT HERE
						}
					}
				}
			}
		}
	}
}
	
