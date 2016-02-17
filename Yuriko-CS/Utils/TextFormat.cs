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

namespace YurikoCS {
	class TextFormat {

		//MCPE Escape Character
		public const char MCPE_ESCAPE_CHAR = '§';

		//Color Constants
		public readonly string BLACK = MCPE_ESCAPE_CHAR + "0";
		public readonly string DARK_BLUE = MCPE_ESCAPE_CHAR + "1";
		public readonly string DARK_GREEN = MCPE_ESCAPE_CHAR + "2";
		public readonly string DARK_AQUA = MCPE_ESCAPE_CHAR + "3";
		public readonly string DARK_RED = MCPE_ESCAPE_CHAR + "4";
		public readonly string DARK_PURPLE = MCPE_ESCAPE_CHAR + "5";
		public readonly string GOLD = MCPE_ESCAPE_CHAR + "6";
		public readonly string GRAY = MCPE_ESCAPE_CHAR + "7";
		public readonly string DARK_GRAY = MCPE_ESCAPE_CHAR + "8";
		public readonly string BLUE = MCPE_ESCAPE_CHAR + "9";
		public readonly string GREEN = MCPE_ESCAPE_CHAR + "a";
		public readonly string AQUA = MCPE_ESCAPE_CHAR + "b";
		public readonly string RED = MCPE_ESCAPE_CHAR + "c";
		public readonly string LIGHT_PURPLE = MCPE_ESCAPE_CHAR + "d";
		public readonly string YELLOW = MCPE_ESCAPE_CHAR + "e";
		public readonly string WHITE = MCPE_ESCAPE_CHAR + "f";

		//Format Constants
		public readonly string OBFUSCATED = MCPE_ESCAPE_CHAR + "k";
		public readonly string BOLD = MCPE_ESCAPE_CHAR + "l";
		public readonly string STRIKETHROUGH = MCPE_ESCAPE_CHAR + "m";
		public readonly string UNDERLINE = MCPE_ESCAPE_CHAR + "n";
		public readonly string ITALIC = MCPE_ESCAPE_CHAR + "o";
		public readonly string RESET = MCPE_ESCAPE_CHAR + "r";

		public static string translateColors(char escape_char, string str){
			return str.Replace(escape_char.ToString(), MCPE_ESCAPE_CHAR.ToString());
		}

		//Prints formatted messages to the console
		public static void formattedConsoleOutput(string message){
		}

	}
}