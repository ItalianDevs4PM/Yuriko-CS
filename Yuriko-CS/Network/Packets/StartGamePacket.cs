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
	class StartGamePacket : Packet {
		
		public int Seed;
		public int Generator;
		public int Gamemode;
		public int SpawnX;
		public int SpawnY;
		public int SpawnZ;
		public float X;
		public float Y;
		public float Z;

		private MemoryStream packetcontent;
		
		public StartGamePacket(int Seed, int Generator, int Gamemode, int SpawnX, int SpawnY, int SpawnZ, float X, float Y, float Z, Triad packetCount){
			packetcontent = new MemoryStream();
			packetcontent.WriteByte(GetID());
			this.Seed = Seed;
			byte[] Seedb = BitConverter.GetBytes(Seed);
			Array.Reverse(Seedb, 0, 4);
			packetcontent.Write(Seedb, 0, 4);
			packetcontent.WriteByte(0);	//Dimension (To-Do)
			this.Generator = Generator;
			byte[] Generatorb = BitConverter.GetBytes(Generator);
			Array.Reverse(Generatorb, 0, 4);
			packetcontent.Write(Generatorb, 0, 4);
			this.Gamemode = Gamemode;
			byte[] Gamemodeb = BitConverter.GetBytes(Gamemode);
			Array.Reverse(Gamemodeb, 0, 4);
			packetcontent.Write(Gamemodeb, 0, 4);
			this.SpawnX = SpawnX;
			byte[] SpawnXb = BitConverter.GetBytes(SpawnX);
			Array.Reverse(SpawnXb, 0, 4);
			packetcontent.Write(SpawnXb, 0, 4);
			this.SpawnY = SpawnY;
			byte[] SpawnYb = BitConverter.GetBytes(SpawnY);
			Array.Reverse(SpawnYb, 0, 4);
			packetcontent.Write(SpawnYb, 0, 4);
			this.SpawnZ = SpawnZ;
			byte[] SpawnZb = BitConverter.GetBytes(SpawnZ);
			Array.Reverse(SpawnZb, 0, 4);
			packetcontent.Write(SpawnZb, 0, 4);
			this.X = X;
			byte[] Xb = BitConverter.GetBytes(X);
			Array.Reverse(Xb, 0, Xb.Length);
			packetcontent.Write(Xb, 0, Xb.Length);
			this.Y = Y;
			byte[] Yb = BitConverter.GetBytes(Y);
			Array.Reverse(Yb, 0, Yb.Length);
			packetcontent.Write(Yb, 0, Yb.Length);
			this.Z = Z;
			byte[] Zb = BitConverter.GetBytes(Z);
			Array.Reverse(Zb, 0, Zb.Length);
			packetcontent.Write(Zb, 0, Zb.Length);
			packetcontent.WriteByte(0);	//Unknown
			packetcontent = new MemoryStream(EncapsulationHelper.Encode(packetcontent.ToArray(), 0x40, packetCount, 0x84).GetData());
		}
		
		public byte GetID(){
			return PacketID.MCPE_START_GAME_PACKET;
		}
		
		public byte[] GetContent(){
			return packetcontent.ToArray();
		}
		
	}
}
