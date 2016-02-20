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
	class OpenConnectionReplyPacket : Packet {
		
		public short mtusize;
		
		private MemoryStream packetcontent;
		
		public OpenConnectionReplyPacket(short mtusize){
			this.mtusize = mtusize;
			packetcontent = new MemoryStream();
			packetcontent.WriteByte(getID());
			packetcontent.Write(Server.OFFLINE_MESSAGE_DATA_ID, 0, Server.OFFLINE_MESSAGE_DATA_ID.Length);
			byte[] serverid = BitConverter.GetBytes((long) 0x00000000372cdc9e);
			packetcontent.Write(serverid, 0, serverid.Length);
			packetcontent.WriteByte(0); //Server security
			byte[] mtusizeb = BitConverter.GetBytes(mtusize);
			//Array.Reverse(mtusizeb, 0, mtusizeb.Length);
			packetcontent.Write(mtusizeb, 0, mtusizeb.Length);
		}
		
		public byte getID(){
			return PacketID.MCPE_OPEN_CONNECTION_REPLY;
		}
		
		public byte[] getContent(){
			return packetcontent.ToArray();
		}
	}
}
