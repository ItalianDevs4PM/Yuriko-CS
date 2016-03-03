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
	class ACK : Packet {
		
		public Triad FirstPacket;
		
		public Triad LastPacket;
		
		public bool AdditionalPacket;
	
		public byte[] data;

		private MemoryStream PacketContent;
		
		public ACK(){}
		
		public byte GetID(){
			return PacketID.ACK;
		}
		
		public byte[] Encode(){
			PacketContent = BinaryHelper.Reset(PacketContent);
			BinaryHelper.WriteByte(PacketContent, GetID());
			BinaryHelper.WriteShort(PacketContent, 1);
			if(AdditionalPacket){
				BinaryHelper.WriteByte(PacketContent, 0x01);
			}else{
				BinaryHelper.WriteByte(PacketContent, 0x00);
			}
			BinaryHelper.WriteTriad(PacketContent, FirstPacket);
			if(!AdditionalPacket){
				if(LastPacket == null){
					BinaryHelper.WriteTriad(PacketContent, new Triad(0));
				}else{
					BinaryHelper.WriteTriad(PacketContent, LastPacket);
				}
			}
			return PacketContent.ToArray();
		}

		public byte[] Decode(){
			PacketContent = BinaryHelper.Reset(PacketContent, data);
			if(BinaryHelper.ReadByte(PacketContent, 3) == 0x01){
				AdditionalPacket = true;
			}else{
				AdditionalPacket = false;
			}
			FirstPacket = BinaryHelper.ReadTriad(PacketContent);
			if(!AdditionalPacket){
				LastPacket = BinaryHelper.ReadTriad(PacketContent);
			}
			return PacketContent.ToArray();
		}

		public void SetPacketCount(Triad PacketCount){}
		
	}
}
