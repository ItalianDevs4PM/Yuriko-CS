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
	public class Logger {

		public static void log(LogLevel level, String message){

		}

		public static void info(String message){
			Console.ForegroundColor = ConsoleColor.Gray;
			DateTime time = DateTime.Now;
			Console.WriteLine("[" + time.Hour + ":" + time.Minute + ":" + time.Second + "] INFO: " + message);
		}

		public static void notice(String message){
			Console.ForegroundColor = ConsoleColor.Cyan;
			DateTime time = DateTime.Now;
			Console.WriteLine("[" + time.Hour + ":" + time.Minute + ":" + time.Second + "] NOTICE: " + message);
		}

		public static void warning(String message){
			Console.ForegroundColor = ConsoleColor.Yellow;
			DateTime time = DateTime.Now;
			Console.WriteLine("[" + time.Hour + ":" + time.Minute + ":" + time.Second + "] WARNING: " + message);
		}

		public static void error(String message){
			Console.ForegroundColor = ConsoleColor.Red;
			DateTime time = DateTime.Now;
			Console.WriteLine("[" + time.Hour + ":" + time.Minute + ":" + time.Second + "] ERROR: " + message);
		}

		public static void critical(String message){
			Console.ForegroundColor = ConsoleColor.DarkRed;
			DateTime time = DateTime.Now;
			Console.WriteLine("[" + time.Hour + ":" + time.Minute + ":" + time.Second + "] CRITICAL: " + message);
		}

		public static void debug(String message){
			Console.ForegroundColor = ConsoleColor.Magenta;
			DateTime time = DateTime.Now;
			Console.WriteLine("[" + time.Hour + ":" + time.Minute + ":" + time.Second + "] DEBUG: " + message);
		}
	}
}
