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

		private static Logger instance;

		private string prefix;

		public Logger(){
			new Logger(null);
		}

		public Logger(string prefix){
			if(instance == null){
				instance = this;
			}
			this.prefix = prefix;
		}

		public void log(LogLevel level, String message){
			switch(level){
			case LogLevel.Info:
				info(message);
				break;
			case LogLevel.Notice:
				notice(message);
				break;
			case LogLevel.Warning:
				warning(message);
				break;
			case LogLevel.Error:
				error(message);
				break;
			case LogLevel.Critical:
				critical(message);
				break;
			case LogLevel.Debug:
				debug(message);
				break;
			default:
				info(message);
				break;
			}
		}

		public static Logger getLogger(){
			return instance;
		}

		public void info(String message){
			Console.ForegroundColor = ConsoleColor.Gray;
			DateTime time = DateTime.Now;
			if(prefix == null){
				Console.WriteLine("[" + time.ToString("HH:mm:ss") + "] INFO: " + message);
			}else{
				Console.WriteLine("[" + time.ToString("HH:mm:ss") + "][" + prefix + "] INFO: " + message);
			}
		}

		public void notice(String message){
			Console.ForegroundColor = ConsoleColor.Cyan;
			DateTime time = DateTime.Now;
			if(prefix == null){
				Console.WriteLine("[" + time.ToString("HH:mm:ss") + "] NOTICE: " + message);
			}else{
				Console.WriteLine("[" + time.ToString("HH:mm:ss") + "][" + prefix + "] NOTICE: " + message);
			}
		}

		public void warning(String message){
			Console.ForegroundColor = ConsoleColor.Yellow;
			DateTime time = DateTime.Now;
			if(prefix == null){
				Console.WriteLine("[" + time.ToString("HH:mm:ss") + "] WARNING: " + message);
			}else{
				Console.WriteLine("[" + time.ToString("HH:mm:ss") + "][" + prefix + "] WARNING: " + message);
			}
		}

		public void error(String message){
			Console.ForegroundColor = ConsoleColor.Red;
			DateTime time = DateTime.Now;
			if(prefix == null){
				Console.WriteLine("[" + time.ToString("HH:mm:ss") + "] ERROR: " + message);
			}else{
				Console.WriteLine("[" + time.ToString("HH:mm:ss") + "][" + prefix + "] ERROR: " + message);
			}
		}

		public void critical(String message){
			Console.ForegroundColor = ConsoleColor.DarkRed;
			DateTime time = DateTime.Now;
			if(prefix == null){
				Console.WriteLine("[" + time.ToString("HH:mm:ss") + "] CRITICAL: " + message);
			}else{
				Console.WriteLine("[" + time.ToString("HH:mm:ss") + "][" + prefix + "] CRITICAL: " + message);
			}
		}

		public void debug(String message){
			Console.ForegroundColor = ConsoleColor.Magenta;
			DateTime time = DateTime.Now;
			if(prefix == null){
				Console.WriteLine("[" + time.ToString("HH:mm:ss") + "] DEBUG: " + message);
			}else{
				Console.WriteLine("[" + time.ToString("HH:mm:ss") + "][" + prefix + "] DEBUG: " + message);
			}
		}

		public string getPrefix(){
			return prefix;
		}
	}
}