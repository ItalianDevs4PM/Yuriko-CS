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
 * See LICENSE.md for the license applied to this file/project
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
	public class StringFunctions {
		public static bool IsNullOrOnlySpaces(string str){
			foreach(char chr in str){
				if(chr != ' '){
					return false;
				}
			}
			return true;
		}

		public static string GetMCPEStringFromStream(MemoryStream stream, int index){
			byte[] data = stream.ToArray();
			byte[] lengthb = new byte[]{data[index + 1], data[index]};
			short length = BitConverter.ToInt16(lengthb, 0);
			string str = "";
			short size = 0;
			while(true){
				if(size == length){
					return str;
				}
				str += (char) data[index + 2 + size];
				size++;
			}
		}
	}
}
