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
					Logger.getLogger().Info("[§b" + sender.Address + ":" + sender.Port + "§f] connected to the server");
					byte packetID = helper.GetPacketID();
					if(packetID == PacketID.MCPE_CLIENT_CONNECT_PACKET){
						ClientConnectPacket ccp = new ClientConnectPacket(data);
						ServerHandshakePacket shp = new ServerHandshakePacket((short) port, ccp.Session, new Triad(0));
						server.Send(shp.GetContent(), shp.GetContent().Length, sender);
					}
				}
			}
		}
	}
}
	
