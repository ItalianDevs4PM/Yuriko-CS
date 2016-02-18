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
using System.IO;

namespace YurikoCS {
	class UnconnectedPongPacket : Packet {

		public long pingid;
		public string servername;

		private MemoryStream packetcontent;

		public UnconnectedPongPacket(long pingid, string servername){
			this.pingid = pingid;
			this.servername = servername;
			string formattedservername = "MCPE;" + TextFormat.formatMCPEString(servername) + ";" + Server.MCPE_PROTOCOL_ID.ToString("X2") + ";" + Server.MCPE_VERSION + ";" + Server.getInstance().getOnlinePlayers().Count + ";" + Server.getInstance().getMaxPlayers();
			packetcontent = new MemoryStream();
			packetcontent.WriteByte(getID());
			byte[] pingidb = BitConverter.GetBytes(pingid);
			Array.Reverse(pingidb, 0, pingidb.Length);
			packetcontent.Write(pingidb, 0, pingidb.Length);
			byte[] serveridb = BitConverter.GetBytes((long) 0x00000000372cdc9e);
			packetcontent.Write(serveridb, 0, serveridb.Length);
			packetcontent.Write(Server.OFFLINE_MESSAGE_DATA_ID, 0, Server.OFFLINE_MESSAGE_DATA_ID.Length);
			byte[] servernameb = new PacketString(formattedservername).getBytes();
			packetcontent.Write(servernameb, 0, servernameb.Length);
		}

		public byte getID(){
			return PacketID.MCPE_OPEN_CONNECTIONS;
		}

		public byte[] getContent(){
			return packetcontent.ToArray();
		}
	}
}