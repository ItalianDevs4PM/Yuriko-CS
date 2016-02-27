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

		public long Identifier;
		
		private MemoryStream packetcontent;

		
		public ACK(Packet packet, Triad packetCount){
			packetcontent = new MemoryStream();
			packetcontent.WriteByte(GetID());
			packetcontent.Write(new byte[]{0x00, 0x01}, 0, 2);
			packetcontent.WriteByte(0x01);
			byte[] packetCountb = new byte[3];
			packetCountb = packetCount.GetBytes();
			Array.Reverse(packetCountb, 0, 3);
			packetcontent.Write(packetCountb, 0, 3); //Packet Count
			//packetCountb = new Triad(packetCount.ToInt32() + 1).GetBytes();
			//Array.Reverse(packetCountb, 0, 3);
			//stream.Write(packetCountb, 0, 3); //Packet Count
			//packetcontent = new MemoryStream(EncapsulationHelper.Encode(packetcontent.ToArray(), 0x40, packetCount, 0x84).GetData());
		}

		public ACK(Triad packetCount){
			packetcontent = new MemoryStream();
			packetcontent.WriteByte(GetID());
			packetcontent.Write(new byte[]{0x00, 0x01}, 0, 2);
			packetcontent.WriteByte(0x01);
			byte[] packetCountb = new byte[3];
			packetCountb = packetCount.GetBytes();
			//Array.Reverse(packetCountb, 0, 3);
			packetcontent.Write(packetCountb, 0, 3); //Packet Count
			//packetCountb = new Triad(packetCount.ToInt32() + 1).GetBytes();
			//Array.Reverse(packetCountb, 0, 3);
			//stream.Write(packetCountb, 0, 3); //Packet Count
			//packetcontent = new MemoryStream(EncapsulationHelper.Encode(packetcontent.ToArray(), 0x40, packetCount, 0x84).GetData());
		}
		
		public byte GetID(){
			return 0xC0;
		}
		
		public byte[] GetContent(){
			return packetcontent.ToArray();
		}
		
	}
}
