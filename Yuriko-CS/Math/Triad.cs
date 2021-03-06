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

namespace YurikoCS {
	class Triad {

		private byte[] bytes;

		public Triad(byte[] bytes){
			this.bytes = bytes;
		}

		public Triad(short value){
			this.bytes = BitConverter.GetBytes(value);
		}
		
		public Triad(int value){
			this.bytes = BitConverter.GetBytes(value);
		}
		
		public Triad(long value){
			this.bytes = BitConverter.GetBytes(value);
		}

		public short ToInt16(){
			return (short)(bytes[0] + (bytes[1] << 8) + (bytes[2] << 16));
		}

		public int ToInt32(){
			return (int)(bytes[0] + (bytes[1] << 8) + (bytes[2] << 16));
		}

		public long ToInt64(){
			return (long)(bytes[0] + (bytes[1] << 8) + (bytes[2] << 16));
		}

		public byte[] GetBytes(){
			byte[] bytesr = new byte[3];
			Array.Copy(bytes, bytesr, 3);
			return bytesr;
		}
	}
}
