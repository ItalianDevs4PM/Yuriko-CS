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
					UnconnectedPongPacket packet = new UnconnectedPongPacket(45, Server.getInstance().getMotd());
					server.Send(packet.getContent(), packet.getContent().Length, sender);
					Logger.getLogger().Debug(BitConverter.ToString(packet.getContent()));
					Logger.getLogger().Debug(sender.Address + ":" + sender.Port);
				}else if(data[0] == PacketID.MCPE_OPEN_CONNECTION_REQUEST){	//Initialize Client connection
					OpenConnectionReplyPacket packet = new OpenConnectionReplyPacket(1447);
					server.Send(packet.getContent(), packet.getContent().Length, sender);
				}/*else if(data[0] == PacketID.MCPE_OPEN_CONNECTION_REQUEST){	//Initialize Client connection
					//CALL PRELOGINEVENT HERE
					//CHECK PROTOCOL HERE
					//Server.getInstance().getOnlinePlayers().Add(new Player
				}*/
			}
		}
	}
}
	
