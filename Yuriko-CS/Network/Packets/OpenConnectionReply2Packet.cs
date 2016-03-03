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
	class OpenConnectionReply2Packet : Packet {
		
		public short ClientPort;
		
		public short MtuSize;

		private MemoryStream PacketContent;
		
		public OpenConnectionReply2Packet(){}
		
		public byte GetID(){
			return PacketID.MCPE_OPEN_CONNECTION_REPLY_2;
		}
		
		public byte[] Encode(){
			PacketContent = BinaryHelper.Reset(PacketContent);
			BinaryHelper.WriteByte(PacketContent, GetID());
			BinaryHelper.WriteBytes(PacketContent, Server.OFFLINE_MESSAGE_DATA_ID);
			BinaryHelper.WriteBytes(PacketContent, BitConverter.GetBytes((long) 0x00000000372cdc9e));
			BinaryHelper.WriteShort(PacketContent, ClientPort);
			BinaryHelper.WriteShort(PacketContent, MtuSize);
			BinaryHelper.WriteByte(PacketContent, 0);	//Server security
			return PacketContent.ToArray();
		}
		
		public byte[] Decode(){
			return null;
		}

		public void SetPacketCount(Triad PacketCount){}
	}
}
