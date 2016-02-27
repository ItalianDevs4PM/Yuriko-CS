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
	class PingPacket : Packet {
		
		public long Identifier;
		
		private MemoryStream packetcontent;
		
		public PingPacket(byte[] data){
			data = EncapsulationHelper.Decode(data).GetData();
			packetcontent = new MemoryStream(data);
			byte[] Identifierb = new byte[8];
			packetcontent.Read(Identifierb, 0, 8);
			Identifier = BitConverter.ToInt64(Identifierb, 0);
		}
		
		public byte GetID(){
			return PacketID.MCPE_CLIENT_CONNECT_PACKET;
		}
		
		public byte[] GetContent(){
			return packetcontent.ToArray();
		}
		
	}
}
