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
	class PongPacket : Packet {
		
		public long Identifier;
		
		private MemoryStream packetcontent;
		
		public PongPacket(long Identifier, Triad packetCount){
			packetcontent = new MemoryStream();
			packetcontent.WriteByte(GetID());
			byte[] Identifierb = BitConverter.GetBytes(Identifier);
			//Array.Reverse(Identifierb, 0, Identifierb.Length);
			packetcontent.Write(Identifierb, 0, Identifierb.Length);
			packetcontent = new MemoryStream(EncapsulationHelper.Encode(packetcontent.ToArray(), 0x40, packetCount, 0x84).GetData());
		}

		public byte GetID(){
			return PacketID.MCPE_PONG_PACKET;
		}
		
		public byte[] GetContent(){
			return packetcontent.ToArray();
		}
		
	}
}
