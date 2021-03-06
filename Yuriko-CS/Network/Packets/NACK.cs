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
	class NACK : Packet {//TODO
		
		public long ClientID;
		
		public long Session;
		
		private MemoryStream packetcontent;
		
		public NACK(byte[] data){
		}
		
		public byte GetID(){
			return 0xA0;
		}
		
		public byte[] Encode(){
			return packetcontent.ToArray();
		}

		public byte[] Decode(){
			return packetcontent.ToArray();
		}

		public void SetPacketCount(Triad PacketCount){}
		
	}
}
