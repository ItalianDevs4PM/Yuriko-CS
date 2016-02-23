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
		
		private MemoryStream packetcontent;
		
		public ServerHandshakePacket(short ServerPort, long Session, Triad packetCount){
			packetcontent = new MemoryStream();
			packetcontent.WriteByte(GetID());
			packetcontent.Write(new byte[]{0x04, 0x3F, 0x57, 0xFE}, 0, 4);
			packetcontent.WriteByte(0xE7);
			byte[] ServerPortb = BitConverter.GetBytes(ServerPort);
			Array.Reverse(ServerPortb, 0, ServerPortb.Length);
			packetcontent.Write(ServerPortb, 0, ServerPortb.Length);
			putDataArray();
			packetcontent.WriteByte(0x00); //Unkown (0x00 0x00)
			packetcontent.WriteByte(0x00);	
			byte[] Sessionb = BitConverter.GetBytes(Session);
			packetcontent.Write(Sessionb, 0, Sessionb.Length);
			packetcontent.Write(new byte[]{0x00, 0x00, 0x00, 0x00, 0x04, 0x44, 0x0B, 0xA9}, 0, 8); //Unknown
			packetcontent = new MemoryStream(EncapsulationHelper.Encode(packetcontent.ToArray(), 0x40, packetCount, 0x84).GetData());
		}

		private void putDataArray(){
			byte[] unknown1 = new byte[] { 0x80, 0xFF, 0xFF, 0xFE};
			byte[] unknown2 = new byte[] { 0xFF, 0xFF, 0xFF, 0xFF};
			byte[] unknown1lb = new Triad(unknown1.Length).GetBytes();
			Array.Reverse(unknown1lb, 0, 3);
			packetcontent.Write(unknown1lb, 0, 3);
			packetcontent.Write(unknown1, 0, 4);
			for(int i = 0; i < 9; i++){
				byte[] unknown2lb = new Triad(unknown2.Length).GetBytes();
				Array.Reverse(unknown2lb, 0, 3);
				packetcontent.Write(unknown2lb, 0, 3);
				packetcontent.Write(unknown2, 0, 4);
			}
		}
		
		public byte GetID(){
			return PacketID.MCPE_SERVER_HANDSHAKE_PACKET;
		}
		
		public byte[] GetContent(){
			return packetcontent.ToArray();
		}
		
	}
}
