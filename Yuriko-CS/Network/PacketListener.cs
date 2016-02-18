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

		public PacketListener(int port){
			this.port = port;
		}

		public void Start(){
			server = new UdpClient(port);
			receivePackets();
		}

		private void receivePackets(){
			byte[] data = new byte[1024];
			IPEndPoint sender = new IPEndPoint(IPAddress.Any, 0);
			data = server.Receive(ref sender);
			while(true){
				UnconnectedPongPacket packet = new UnconnectedPongPacket(45, 457587, Server.getInstance().getMotd());
				server.Send(packet.getContent(), packet.getContent().Length, sender);
				Logger.getLogger().Debug(BitConverter.ToString(packet.getContent()));
				Logger.getLogger().Debug(sender.Address + ":" + sender.Port);
			}
		}
	}
}
	
