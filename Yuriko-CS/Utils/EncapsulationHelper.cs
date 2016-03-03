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
	class EncapsulationHelper {

		private MemoryStream stream;
		private bool isDecode;
		private byte customPacketID;
		private byte packetID;
		private byte encapsulationFormat;
		private short packetLength;
		private Triad packetCount;
		private Triad packetCount2;

//		public EncapsulationHelper(byte[] data, bool isDecode){
//			stream = new MemoryStream(data);
//			this.isDecode = isDecode;
//			if(!isDecode){
//				this.customPacketID = 0x80;
//				this.encapsulationFormat = 0;
//			}
//		}
//
//		public EncapsulationHelper(byte[] data, bool isDecode, byte customPacketID){
//			stream = new MemoryStream(data);
//			this.isDecode = isDecode;
//			this.customPacketID = customPacketID;
//		}

		private EncapsulationHelper(){}

		public static EncapsulationHelper Decode(byte[] data){
			EncapsulationHelper enchelper = new EncapsulationHelper();
			enchelper.stream = new MemoryStream(data);
			enchelper.isDecode = true;
			enchelper.customPacketID = Convert.ToByte(enchelper.stream.ReadByte());
			//enchelper.packetCount = packetCount;
			enchelper.stream.Position = 1;
			byte[] packetCountb = new byte[3];
			enchelper.stream.Read(packetCountb, 0, 3);
			//Array.Reverse(packetCountb, 0, 3);
			enchelper.packetCount = new Triad(packetCountb);
			enchelper.stream.Position = 4;
			enchelper.encapsulationFormat = Convert.ToByte(enchelper.stream.ReadByte());
			enchelper.stream.Position = 5;
			byte[] packetLengthb = new byte[2];
			enchelper.stream.Read(packetLengthb, 0, 2);
			Array.Reverse(packetLengthb, 0, 2);
			enchelper.packetLength = BitConverter.ToInt16(packetLengthb, 0);
			if(enchelper.encapsulationFormat == 0x00){
				enchelper.stream.Position = 7;
				enchelper.packetID = Convert.ToByte(enchelper.stream.ReadByte());
				byte[] packetContent = new byte[enchelper.stream.Length - 8];
				enchelper.stream.Read(packetContent, 0, packetContent.Length);
				enchelper.stream = new MemoryStream(packetContent);
			}else if(enchelper.encapsulationFormat == 0x40){
				enchelper.stream.Position = 10;
				enchelper.packetID = Convert.ToByte(enchelper.stream.ReadByte());
				byte[] packetContent = new byte[enchelper.stream.Length - 11];
				enchelper.stream.Read(packetContent, 0, packetContent.Length);
				enchelper.stream = new MemoryStream(packetContent);
			}else if(enchelper.encapsulationFormat == 0x60){
				enchelper.stream.Position = 14;
				enchelper.packetID = Convert.ToByte(enchelper.stream.ReadByte());
				byte[] packetContent = new byte[enchelper.stream.Length - 15];
				enchelper.stream.Read(packetContent, 0, packetContent.Length);
				enchelper.stream = new MemoryStream(packetContent);
			}
			return enchelper;
		}

		public static EncapsulationHelper Encode(byte[] data){
			return Encode(data, 0, new Triad(0), 0x80);
		}

		public static EncapsulationHelper Encode(byte[] data, byte encapsulationFormat){
			return Encode(data, encapsulationFormat, new Triad(0), 0x80);
		}

		public static EncapsulationHelper Encode(byte[] data, byte encapsulationFormat, Triad packetCount){
			return Encode(data, encapsulationFormat, new Triad(0), 0x80);
		}

		public static EncapsulationHelper Encode(byte[] data, byte encapsulationFormat, Triad packetCount, byte customPacket){
			EncapsulationHelper enchelper = new EncapsulationHelper();
			enchelper.stream = new MemoryStream();
			enchelper.isDecode = false;
			enchelper.customPacketID = customPacket;
			enchelper.stream.WriteByte(customPacket);
			enchelper.packetCount = packetCount;
			enchelper.encapsulationFormat = encapsulationFormat;
			enchelper.packetID = data[0];
			//Custom Packet Format
			byte[] packetCountb = new byte[3];
			packetCountb = packetCount.GetBytes();
			//Array.Reverse(packetCountb, 0, 3);
			enchelper.stream.Write(packetCountb, 0, 3);
			enchelper.stream.WriteByte(encapsulationFormat);
			enchelper.packetLength = (short) data.Length;
			enchelper.GeneratePayload();
			enchelper.stream.Write(data, 0, data.Length);
			return enchelper;
		}

		private void GeneratePayload(){
			packetLength = (short)(packetLength * 8); //LengthInBits = Length * 8
			byte[] dataLengthb = new byte[2];
			dataLengthb = BitConverter.GetBytes(packetLength);
			Array.Reverse(dataLengthb, 0, 2);
			stream.Write(dataLengthb, 0, 2); //Packet Length
			if(encapsulationFormat == 0x40){	//Encapsulation Format 0x40
				packetCount = new Triad(packetCount.ToInt32() + 1);
				byte[] packetCountb = new byte[3];
				packetCountb = packetCount.GetBytes();
				//Array.Reverse(packetCountb, 0, 3);
				stream.Write(packetCountb, 0, 3); //Packet Count
			}else if(encapsulationFormat == 0x60){	//Encapsulation Format 0x60
				packetCount2 = new Triad(packetCount.ToInt32() + 1);
				byte[] packetCountb = new byte[3];
				packetCountb = packetCount.GetBytes();
				Array.Reverse(packetCountb, 0, 3);
				stream.Write(packetCountb, 0, 3); //Packet Count
				stream.Write(new byte[]{0,0,0,0}, 0, 4); //Unknown
			}
		}

		public byte GetCustomPacketID(){
			return customPacketID;
		}

		public byte GetPacketID(){
			return packetID;
		}

		public short GetPacketLength(){
			return packetLength;
		}

		public byte GetEncapsulationFormat(){
			return encapsulationFormat;
		}

		public Triad GetPacketCount(){
			return packetCount;
		}

		public Triad GetPacketCount2(){
			return packetCount2;
		}

		//If isDecode, get datapacket only
		//Else get full packet content (encoded header + datapacket)
		public byte[] GetData(){
			return stream.ToArray();
		}

		public bool IsDecode(){
			return isDecode;
		}
	}
}
