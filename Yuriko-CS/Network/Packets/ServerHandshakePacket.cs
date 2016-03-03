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
	class ServerHandshakePacket : Packet {
		
		public short ServerPort;
		
		public long Session;

		public Triad PacketCount;
		
		private MemoryStream PacketContent;
		
		public ServerHandshakePacket(){}

		private void PutDataArray(){
			byte[] unknown1 = new byte[] { 0x80, 0xFF, 0xFF, 0xFE};
			byte[] unknown2 = new byte[] { 0xFF, 0xFF, 0xFF, 0xFF};
			BinaryHelper.WriteTriad(PacketContent, new Triad(unknown1.Length));
			BinaryHelper.WriteBytes(PacketContent, unknown1);
			for(int i = 0; i < 9; i++){
				BinaryHelper.WriteTriad(PacketContent, new Triad(unknown2.Length));
				BinaryHelper.WriteBytes(PacketContent, unknown2);
			}
		}
		
		public byte GetID(){
			return PacketID.MCPE_SERVER_HANDSHAKE_PACKET;
		}
		
		public byte[] Encode(){
			PacketContent = BinaryHelper.Reset(PacketContent);
			BinaryHelper.WriteByte(PacketContent, GetID());
			BinaryHelper.WriteBytes(PacketContent, new byte[]{0x04, 0x3F, 0x57, 0xFE});
			BinaryHelper.WriteByte(PacketContent, 0xE7);
			BinaryHelper.WriteShort(PacketContent, ServerPort);
			PutDataArray();
			BinaryHelper.WriteByte(PacketContent, 0x00);	//Unkown (0x00 0x00)
			BinaryHelper.WriteByte(PacketContent, 0x00);
			BinaryHelper.WriteLong(PacketContent, Session);
			BinaryHelper.WriteBytes(PacketContent, new byte[]{0x00, 0x00, 0x00, 0x00, 0x04, 0x44, 0x0B, 0xA9}); //Unknown
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
