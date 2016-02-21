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
	class OpenConnectionRequest2Packet : Packet {

		public byte[] securitycookie = new byte[5];

		public short ServerPort;

		public short mtusize;

		public long ClientID;
		
		private MemoryStream packetcontent;
		
		public OpenConnectionRequest2Packet(byte[] data){
			packetcontent = new MemoryStream(data);
			packetcontent.Position = 17;
			packetcontent.Read(securitycookie, 0, 5);
			Array.Reverse(securitycookie, 0, securitycookie.Length);
			packetcontent.Position = 22;
			byte[] ServerPortb = new byte[2];
			packetcontent.Read(ServerPortb, 0, 2);
			Array.Reverse(ServerPortb, 0, ServerPortb.Length);
			ServerPort = BitConverter.ToInt16(ServerPortb, 0);
			packetcontent.Position = 24;
			byte[] mtusizeb = new byte[2];
			packetcontent.Read(mtusizeb, 0, 2);
			//Array.Reverse(mtusizeb, 0, mtusizeb.Length);
			mtusize = BitConverter.ToInt16(mtusizeb, 0);
			packetcontent.Position = 26;
			byte[] ClientIDb = new byte[8];
			packetcontent.Read(ClientIDb, 0, 8);
			Array.Reverse(ClientIDb, 0, ClientIDb.Length);
			ClientID = BitConverter.ToInt64(ClientIDb, 0);
		}
		
		public byte GetID(){
			return PacketID.MCPE_OPEN_CONNECTION_REQUEST_2;
		}
		
		public byte[] GetContent(){
			return packetcontent.ToArray();
		}
	}
}
