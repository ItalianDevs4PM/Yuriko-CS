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

namespace YurikoCS {
	public class PacketString {

		private string str;

		public PacketString(string str){
			this.str = str;
		}

		public byte[] getBytes(){
			byte[] strarray = System.Text.Encoding.Default.GetBytes(str);
			byte[] strlen = BitConverter.GetBytes((short) strarray.Length);
			Array.Reverse(strlen, 0, strlen.Length);
			MemoryStream ms = new MemoryStream();
			ms.Write(strlen, 0, strlen.Length);
			ms.Write(strarray, 0, strarray.Length);
			return ms.ToArray();
		}
	
	}
}

