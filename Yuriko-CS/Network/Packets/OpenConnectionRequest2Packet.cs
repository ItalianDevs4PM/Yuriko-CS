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

		public byte[] SecurityCookie = new byte[5];

		public short ServerPort;

		public short MtuSize;

		public long ClientID;

		public byte[] data;
		
		private MemoryStream PacketContent;

		public OpenConnectionRequest2Packet(){}
		
		public byte GetID(){
			return PacketID.MCPE_OPEN_CONNECTION_REQUEST_2;
		}
		
		public byte[] Encode(){
			return null;
		}
		
		public byte[] Decode(){
			PacketContent = BinaryHelper.Reset(PacketContent, data);
			SecurityCookie = BinaryHelper.ReadBytes(PacketContent, 5, 17);
			ServerPort = BinaryHelper.ReadShort(PacketContent);
			MtuSize = BinaryHelper.ReadShort(PacketContent);
			ClientID = BinaryHelper.ReadLong(PacketContent);
			return PacketContent.ToArray();
		}

		public void SetPacketCount(Triad PacketCount){}
	}
}
