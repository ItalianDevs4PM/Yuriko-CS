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

		public Triad PacketCount;
		
		private MemoryStream PacketContent;
		
		public PongPacket(){}

		public byte GetID(){
			return PacketID.MCPE_PONG_PACKET;
		}
		
		public byte[] Encode(){
			PacketContent = BinaryHelper.Reset(PacketContent);
			BinaryHelper.WriteByte(PacketContent, GetID());
			BinaryHelper.WriteLong(PacketContent, Identifier);
			PacketContent = new MemoryStream(EncapsulationHelper.Encode(PacketContent.ToArray(), 0x40, PacketCount, 0x84).GetData());	//Encode Packet
			return PacketContent.ToArray();
		}

		public byte[] Decode(){
			return null;
		}

		public void SetPacketCount(Triad PacketCount){
			this.PacketCount = PacketCount;
		}
		
	}
}
