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

namespace YurikoCS {
	class TextFormat {

		//MCPE Escape Character
		public const string MCPE_ESCAPE_CHAR = "\u00C2\u00A7";
		public const char MCPE_SINGLE_ESCAPE_CHAR = '\u00A7';

		//Color Constants
		public readonly string BLACK = MCPE_ESCAPE_CHAR + "0";
		public readonly string DARK_BLUE = MCPE_ESCAPE_CHAR + "1";
		public readonly string DARK_GREEN = MCPE_ESCAPE_CHAR + "2";
		public readonly string DARK_CYAN = MCPE_ESCAPE_CHAR + "3";
		public readonly string DARK_RED = MCPE_ESCAPE_CHAR + "4";
		public readonly string DARK_MAGENTA = MCPE_ESCAPE_CHAR + "5";
		public readonly string DARK_YELLOW = MCPE_ESCAPE_CHAR + "6";
		public readonly string GRAY = MCPE_ESCAPE_CHAR + "7";
		public readonly string DARK_GRAY = MCPE_ESCAPE_CHAR + "8";
		public readonly string BLUE = MCPE_ESCAPE_CHAR + "9";
		public readonly string GREEN = MCPE_ESCAPE_CHAR + "a";
		public readonly string CYAN = MCPE_ESCAPE_CHAR + "b";
		public readonly string RED = MCPE_ESCAPE_CHAR + "c";
		public readonly string MAGENTA = MCPE_ESCAPE_CHAR + "d";
		public readonly string YELLOW = MCPE_ESCAPE_CHAR + "e";
		public readonly string WHITE = MCPE_ESCAPE_CHAR + "f";

		//Format Constants
		public readonly string OBFUSCATED = MCPE_ESCAPE_CHAR + "k";
		public readonly string BOLD = MCPE_ESCAPE_CHAR + "l";
		public readonly string STRIKETHROUGH = MCPE_ESCAPE_CHAR + "m";
		public readonly string UNDERLINE = MCPE_ESCAPE_CHAR + "n";
		public readonly string ITALIC = MCPE_ESCAPE_CHAR + "o";
		public readonly string RESET = MCPE_ESCAPE_CHAR + "r";

		public static string formatMCPEString(string str){
			return str.Replace(MCPE_SINGLE_ESCAPE_CHAR.ToString(), MCPE_ESCAPE_CHAR.ToString());
		}

		public static string translateColors(char escape_char, string str){
			return str.Replace(escape_char.ToString(), MCPE_SINGLE_ESCAPE_CHAR.ToString());
		}

		//Prints formatted messages to the console
		public static void formattedConsoleOutput(string message){
			int index = 0;
			Console.ForegroundColor = ConsoleColor.Gray;
			foreach(char chr in message){
				if(index + 1 < message.Length && message[index] == MCPE_SINGLE_ESCAPE_CHAR){
					if(message[index + 1] == '0'){
						Console.ForegroundColor = ConsoleColor.Black;
					}else if(message[index + 1] == '1'){
						Console.ForegroundColor = ConsoleColor.DarkBlue;
					}else if(message[index + 1] == '2'){
						Console.ForegroundColor = ConsoleColor.DarkGreen;
					}else if(message[index + 1] == '3'){
						Console.ForegroundColor = ConsoleColor.DarkCyan;
					}else if(message[index + 1] == '4'){
						Console.ForegroundColor = ConsoleColor.DarkRed;
					}else if(message[index + 1] == '5'){
						Console.ForegroundColor = ConsoleColor.DarkMagenta;
					}else if(message[index + 1] == '6'){
						Console.ForegroundColor = ConsoleColor.DarkYellow;
					}else if(message[index + 1] == '7'){
						Console.ForegroundColor = ConsoleColor.Gray;
					}else if(message[index + 1] == '8'){
						Console.ForegroundColor = ConsoleColor.DarkGray;
					}else if(message[index + 1] == '9'){
						Console.ForegroundColor = ConsoleColor.Blue;
					}else if(message[index + 1] == 'a'){
						Console.ForegroundColor = ConsoleColor.Green;
					}else if(message[index + 1] == 'b'){
						Console.ForegroundColor = ConsoleColor.Cyan;
					}else if(message[index + 1] == 'c'){
						Console.ForegroundColor = ConsoleColor.Red;
					}else if(message[index + 1] == 'd'){
						Console.ForegroundColor = ConsoleColor.Magenta;
					}else if(message[index + 1] == 'e'){
						Console.ForegroundColor = ConsoleColor.Yellow;
					}else if(message[index + 1] == 'f'){
						Console.ForegroundColor = ConsoleColor.White;
					}else{
						Console.Write(message[index]);
						Console.Write(message[index + 1]);
					}
					if(index + 2 < message.Length){
						Console.Write(message[index + 2]);
						index++;
					}
					index++;
				}else if(index < message.Length){
					Console.Write(message[index]);
				}
				index++;
			}
			Console.Write("\n");
			Console.ForegroundColor = ConsoleColor.White;
		}

	}
}