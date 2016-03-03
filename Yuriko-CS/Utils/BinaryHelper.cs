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
using System.IO;
using System.Text;

namespace YurikoCS {
	class BinaryHelper {

		private MemoryStream stream;
		
		public void Reset(){
			stream = new MemoryStream();
		}

		public void Reset(byte[] data){
			stream = new MemoryStream(data);
		}

		public static MemoryStream Reset(MemoryStream stream){
			return new MemoryStream();
		}
		
		public static MemoryStream Reset(MemoryStream stream, byte[] data){
			return new MemoryStream(data);
		}

		public BinaryHelper(MemoryStream stream){
			this.stream = stream;
		}

		public void WriteByte(byte b){
			stream.Write(new byte[]{b}, 0, 1);
		}

		public void WriteByte(byte b, int index){
			stream.Position = index;
			stream.Write(new byte[]{b}, 0, 1);
		}

		public static void WriteByte(MemoryStream stream, byte b){
			stream.Write(new byte[]{b}, 0, 1);
		}

		public static void WriteByte(MemoryStream stream, byte b, int index){
			stream.Position = index;
			stream.Write(new byte[]{b}, 0, 1);
		}

		public void WriteBytes(byte[] bs){
			stream.Write(bs, 0, bs.Length);
		}
		
		public void WriteBytes(byte[] bs, int index){
			stream.Position = index;
			stream.Write(bs, 0, bs.Length);
		}
		
		public static void WriteBytes(MemoryStream stream, byte[] bs){
			stream.Write(bs, 0, bs.Length);
		}
		
		public static void WriteBytes(MemoryStream stream, byte[] bs, int index){
			stream.Position = index;
			stream.Write(bs, 0, bs.Length);
		}

		public void WriteShort(short s){
			byte[] shortb = BitConverter.GetBytes(s);
			if(BitConverter.IsLittleEndian){
				Array.Reverse(shortb, 0, 2);
			}
			stream.Write(shortb, 0, 2);
		}
		
		public void WriteShort(short s, int index){
			stream.Position = index;
			byte[] shortb = BitConverter.GetBytes(s);
			if(BitConverter.IsLittleEndian){
				Array.Reverse(shortb, 0, 2);
			}
			stream.Write(shortb, 0, 2);
		}
		
		public static void WriteShort(MemoryStream stream, short s){
			byte[] shortb = BitConverter.GetBytes(s);
			if(BitConverter.IsLittleEndian){
				Array.Reverse(shortb, 0, 2);
			}
			stream.Write(shortb, 0, 2);
		}
		
		public static void WriteShort(MemoryStream stream, short s, int index){
			stream.Position = index;
			byte[] shortb = BitConverter.GetBytes(s);
			if(BitConverter.IsLittleEndian){
				Array.Reverse(shortb, 0, 2);
			}
			stream.Write(shortb, 0, 2);
		}

		public void WriteTriad(Triad t){
			byte[] triadb = t.GetBytes();
			if(BitConverter.IsLittleEndian){
				Array.Reverse(triadb, 0, 3);
			}
			stream.Write(triadb, 0, 3);
		}
		
		public void WriteTriad(Triad t, int index){
			stream.Position = index;
			byte[] triadb = t.GetBytes();
			if(BitConverter.IsLittleEndian){
				Array.Reverse(triadb, 0, 3);
			}
			stream.Write(triadb, 0, 3);
		}
		
		public static void WriteTriad(MemoryStream stream, Triad t){
			byte[] triadb = t.GetBytes();
			if(BitConverter.IsLittleEndian){
				Array.Reverse(triadb, 0, 3);
			}
			stream.Write(triadb, 0, 3);
		}
		
		public static void WriteTriad(MemoryStream stream, Triad t, int index){
			stream.Position = index;
			byte[] triadb = t.GetBytes();
			if(BitConverter.IsLittleEndian){
				Array.Reverse(triadb, 0, 3);
			}
			stream.Write(triadb, 0, 3);
		}

		public void WriteInt(int i){
			byte[] intb = BitConverter.GetBytes(i);
			if(BitConverter.IsLittleEndian){
				Array.Reverse(intb, 0, 4);
			}
			stream.Write(intb, 0, 4);
		}
		
		public void WriteInt(int i, int index){
			stream.Position = index;
			byte[] intb = BitConverter.GetBytes(i);
			if(BitConverter.IsLittleEndian){
				Array.Reverse(intb, 0, 4);
			}
			stream.Write(intb, 0, 4);
		}
		
		public static void WriteInt(MemoryStream stream, int i){
			byte[] intb = BitConverter.GetBytes(i);
			if(BitConverter.IsLittleEndian){
				Array.Reverse(intb, 0, 4);
			}
			stream.Write(intb, 0, 4);
		}
		
		public static void WriteInt(MemoryStream stream, int i, int index){
			stream.Position = index;
			byte[] intb = BitConverter.GetBytes(i);
			if(BitConverter.IsLittleEndian){
				Array.Reverse(intb, 0, 4);
			}
			stream.Write(intb, 0, 4);
		}

		public void WriteLong(long l){
			byte[] longb = BitConverter.GetBytes(l);
			if(BitConverter.IsLittleEndian){
				Array.Reverse(longb, 0, 8);
			}
			stream.Write(longb, 0, 8);
		}
		
		public void WriteLong(long l, int index){
			stream.Position = index;
			byte[] longb = BitConverter.GetBytes(l);
			if(BitConverter.IsLittleEndian){
				Array.Reverse(longb, 0, 8);
			}
			stream.Write(longb, 0, 8);
		}
		
		public static void WriteLong(MemoryStream stream, long l){
			byte[] longb = BitConverter.GetBytes(l);
			if(BitConverter.IsLittleEndian){
				Array.Reverse(longb, 0, 8);
			}
			stream.Write(longb, 0, 8);
		}
		
		public static void WriteLong(MemoryStream stream, long l, int index){
			stream.Position = index;
			byte[] longb = BitConverter.GetBytes(l);
			if(BitConverter.IsLittleEndian){
				Array.Reverse(longb, 0, 8);
			}
			stream.Write(longb, 0, 8);
		}

		public void WriteFloat(float f){
			byte[] floatb = BitConverter.GetBytes(f);
			if(BitConverter.IsLittleEndian){
				Array.Reverse(floatb, 0, floatb.Length);
			}
			stream.Write(floatb, 0, floatb.Length);
		}
		
		public void WriteFloat(float f, int index){
			stream.Position = index;
			byte[] floatb = BitConverter.GetBytes(f);
			if(BitConverter.IsLittleEndian){
				Array.Reverse(floatb, 0, floatb.Length);
			}
			stream.Write(floatb, 0, floatb.Length);
		}
		
		public static void WriteFloat(MemoryStream stream, float f){
			byte[] floatb = BitConverter.GetBytes(f);
			if(BitConverter.IsLittleEndian){
				Array.Reverse(floatb, 0, floatb.Length);
			}
			stream.Write(floatb, 0, floatb.Length);
		}
		
		public static void WriteFloat(MemoryStream stream, float f, int index){
			stream.Position = index;
			byte[] floatb = BitConverter.GetBytes(f);
			if(BitConverter.IsLittleEndian){
				Array.Reverse(floatb, 0, floatb.Length);
			}
			stream.Write(floatb, 0, floatb.Length);
		}

		public void WriteString(string s){
			byte[] stringb = Encoding.Default.GetBytes(s);
			WriteShort((short) s.Length);
			stream.Write(stringb, 0, stringb.Length);
		}
		
		public void WriteString(string s, int index){
			stream.Position = index;
			byte[] stringb = Encoding.Default.GetBytes(s);
			WriteShort((short) s.Length);
			stream.Write(stringb, 0, stringb.Length);
		}
		
		public static void WriteString(MemoryStream stream, string s){
			byte[] stringb = Encoding.Default.GetBytes(s);
			WriteShort(stream, (short) s.Length);
			stream.Write(stringb, 0, stringb.Length);
		}
		
		public static void WriteString(MemoryStream stream, string s, int index){
			stream.Position = index;
			byte[] stringb = Encoding.Default.GetBytes(s);
			WriteShort(stream, (short) s.Length);
			stream.Write(stringb, 0, stringb.Length);
		}

		public byte ReadByte(){
			byte b = (byte) stream.ReadByte();
			return b;
		}
		
		public byte ReadByte(int index){
			stream.Position = index;
			byte b = (byte) stream.ReadByte();
			return b;
		}
		
		public static byte ReadByte(MemoryStream stream){
			byte b = (byte) stream.ReadByte();
			return b;
		}
		
		public static byte ReadByte(MemoryStream stream, int index){
			stream.Position = index;
			byte b = (byte) stream.ReadByte();
			return b;
		}

		public byte[] ReadBytes(int size){
			byte[] bytes = new byte[size];
			stream.Read(bytes, 0, size);
			return bytes;
		}
		
		public byte[] ReadBytes(int size, int index){
			stream.Position = index;
			byte[] bytes = new byte[size];
			stream.Read(bytes, 0, size);
			return bytes;
		}
		
		public static byte[] ReadBytes(MemoryStream stream, int size){
			byte[] bytes = new byte[size];
			stream.Read(bytes, 0, size);
			return bytes;
		}
		
		public static byte[] ReadBytes(MemoryStream stream, int size, int index){
			stream.Position = index;
			byte[] bytes = new byte[size];
			stream.Read(bytes, 0, size);
			return bytes;
		}
		
		public short ReadShort(){
			byte[] shortb = new byte[2];
			stream.Read(shortb, 0, 2);
			if(BitConverter.IsLittleEndian){
				Array.Reverse(shortb, 0, 2);
			}
			return BitConverter.ToInt16(shortb, 0);
		}
		
		public short ReadShort(int index){
			stream.Position = index;
			byte[] shortb = new byte[2];
			stream.Read(shortb, 0, 2);
			if(BitConverter.IsLittleEndian){
				Array.Reverse(shortb, 0, 2);
			}
			return BitConverter.ToInt16(shortb, 0);
		}
		
		public static short ReadShort(MemoryStream stream){
			byte[] shortb = new byte[2];
			stream.Read(shortb, 0, 2);
			if(BitConverter.IsLittleEndian){
				Array.Reverse(shortb, 0, 2);
			}
			return BitConverter.ToInt16(shortb, 0);
		}
		
		public static short ReadShort(MemoryStream stream, int index){
			stream.Position = index;
			byte[] shortb = new byte[2];
			stream.Read(shortb, 0, 2);
			if(BitConverter.IsLittleEndian){
				Array.Reverse(shortb, 0, 2);
			}
			return BitConverter.ToInt16(shortb, 0);
		}

		public Triad ReadTriad(){
			byte[] triadb = new byte[3];
			stream.Read(triadb, 0, 3);
			if(BitConverter.IsLittleEndian){
				Array.Reverse(triadb, 0, 3);
			}
			return new Triad(triadb);
		}
		
		public Triad ReadTriad(int index){
			stream.Position = index;
			byte[] triadb = new byte[3];
			stream.Read(triadb, 0, 3);
			if(BitConverter.IsLittleEndian){
				Array.Reverse(triadb, 0, 3);
			}
			return new Triad(triadb);
		}
		
		public static Triad ReadTriad(MemoryStream stream){
			byte[] triadb = new byte[3];
			stream.Read(triadb, 0, 3);
			if(BitConverter.IsLittleEndian){
				Array.Reverse(triadb, 0, 3);
			}
			return new Triad(triadb);
		}
		
		public static Triad ReadTriad(MemoryStream stream, int index){
			stream.Position = index;
			byte[] triadb = new byte[3];
			stream.Read(triadb, 0, 3);
			if(BitConverter.IsLittleEndian){
				Array.Reverse(triadb, 0, 3);
			}
			return new Triad(triadb);
		}

		public int ReadInt(){
			byte[] intb = new byte[4];
			stream.Read(intb, 0, 4);
			if(BitConverter.IsLittleEndian){
				Array.Reverse(intb, 0, 4);
			}
			return BitConverter.ToInt32(intb, 0);
		}
		
		public int ReadInt(int index){
			stream.Position = index;
			byte[] intb = new byte[4];
			stream.Read(intb, 0, 4);
			if(BitConverter.IsLittleEndian){
				Array.Reverse(intb, 0, 4);
			}
			return BitConverter.ToInt32(intb, 0);
		}
		
		public static int ReadInt(MemoryStream stream){
			byte[] intb = new byte[4];
			stream.Read(intb, 0, 4);
			if(BitConverter.IsLittleEndian){
				Array.Reverse(intb, 0, 4);
			}
			return BitConverter.ToInt32(intb, 0);
		}
		
		public static int ReadInt(MemoryStream stream, int index){
			stream.Position = index;
			byte[] intb = new byte[4];
			stream.Read(intb, 0, 4);
			if(BitConverter.IsLittleEndian){
				Array.Reverse(intb, 0, 4);
			}
			return BitConverter.ToInt32(intb, 0);
		}

		public long ReadLong(){
			byte[] longb = new byte[8];
			stream.Read(longb, 0, 8);
			if(BitConverter.IsLittleEndian){
				Array.Reverse(longb, 0, 8);
			}
			return BitConverter.ToInt64(longb, 0);
		}
		
		public long ReadLong(int index){
			stream.Position = index;
			byte[] longb = new byte[8];
			stream.Read(longb, 0, 8);
			if(BitConverter.IsLittleEndian){
				Array.Reverse(longb, 0, 8);
			}
			return BitConverter.ToInt64(longb, 0);
		}
		
		public static long ReadLong(MemoryStream stream){
			byte[] longb = new byte[8];
			stream.Read(longb, 0, 8);
			if(BitConverter.IsLittleEndian){
				Array.Reverse(longb, 0, 8);
			}
			return BitConverter.ToInt64(longb, 0);
		}
		
		public static long ReadLong(MemoryStream stream, int index){
			stream.Position = index;
			byte[] longb = new byte[8];
			stream.Read(longb, 0, 8);
			if(BitConverter.IsLittleEndian){
				Array.Reverse(longb, 0, 8);
			}
			return BitConverter.ToInt64(longb, 0);
		}


		public string ReadString(){
			short strlen = ReadShort();
			byte[] str = new byte[strlen];
			stream.Read(str, 0, (int) strlen);
			return Encoding.Default.GetString(str);
		}
		
		public string ReadString(int index){
			stream.Position = index;
			short strlen = ReadShort();
			byte[] str = new byte[strlen];
			stream.Read(str, 0, (int) strlen);
			return Encoding.Default.GetString(str);
		}
		
		public static string ReadString(MemoryStream stream){
			short strlen = ReadShort(stream);
			byte[] str = new byte[strlen];
			stream.Read(str, 0, (int) strlen);
			return Encoding.Default.GetString(str);
		}
		
		public static string ReadString(MemoryStream stream, int index){
			stream.Position = index;
			short strlen = ReadShort(stream);
			byte[] str = new byte[strlen];
			stream.Read(str, 0, (int) strlen);
			return Encoding.Default.GetString(str);
		}
	}
}


