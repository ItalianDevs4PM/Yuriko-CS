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

		public void Log(LogLevel level, String message){
			switch(level){
			case LogLevel.Info:
				Info(message);
				break;
			case LogLevel.Notice:
				Notice(message);
				break;
			case LogLevel.Warning:
				Warning(message);
				break;
			case LogLevel.Error:
				Error(message);
				break;
			case LogLevel.Critical:
				Critical(message);
				break;
			case LogLevel.Debug:
				Debug(message);
				break;
			default:
				Info(message);
				break;
			}
		}

		public static Logger GetLogger(){
			return instance;
		}

		public void Info(String message){
			Console.ForegroundColor = ConsoleColor.Gray;
			DateTime time = DateTime.Now;
			if(prefix == null){
				TextFormat.formattedConsoleOutput("§f[§9" + time.ToString("HH:mm:ss") + "§f] INFO: " + message);
			}else{
				TextFormat.formattedConsoleOutput("§f[§9" + time.ToString("HH:mm:ss") + "§f][" + prefix + "] INFO: " + message);
			}
		}

		public void Notice(String message){
			Console.ForegroundColor = ConsoleColor.Cyan;
			DateTime time = DateTime.Now;
			if(prefix == null){
				TextFormat.formattedConsoleOutput("§f[§9" + time.ToString("HH:mm:ss") + "§f]§b NOTICE: " + message);
			}else{
				TextFormat.formattedConsoleOutput("§f[§9" + time.ToString("HH:mm:ss") + "§f]§b[" + prefix + "] NOTICE: " + message);
			}
		}

		public void Warning(String message){
			Console.ForegroundColor = ConsoleColor.Yellow;
			DateTime time = DateTime.Now;
			if(prefix == null){
				TextFormat.formattedConsoleOutput("§f[§9" + time.ToString("HH:mm:ss") + "§f]§e WARNING: " + message);
			}else{
				TextFormat.formattedConsoleOutput("§f[§9" + time.ToString("HH:mm:ss") + "§f]§e[" + prefix + "] WARNING: " + message);
			}
		}

		public void Error(String message){
			Console.ForegroundColor = ConsoleColor.Red;
			DateTime time = DateTime.Now;
			if(prefix == null){
				TextFormat.formattedConsoleOutput("§f[§9" + time.ToString("HH:mm:ss") + "§f]§c ERROR: " + message);
			}else{
				TextFormat.formattedConsoleOutput("§f[§9" + time.ToString("HH:mm:ss") + "§f]§c[" + prefix + "] ERROR: " + message);
			}
		}

		public void Critical(String message){
			Console.ForegroundColor = ConsoleColor.DarkRed;
			DateTime time = DateTime.Now;
			if(prefix == null){
				TextFormat.formattedConsoleOutput("§f[§9" + time.ToString("HH:mm:ss") + "§f]§4 CRITICAL: " + message);
			}else{
				TextFormat.formattedConsoleOutput("§f[§9" + time.ToString("HH:mm:ss") + "§f]§4[" + prefix + "] CRITICAL: " + message);
			}
		}

		public void Debug(String message){
			Console.ForegroundColor = ConsoleColor.Magenta;
			DateTime time = DateTime.Now;
			if(prefix == null){
				TextFormat.formattedConsoleOutput("§f[§9" + time.ToString("HH:mm:ss") + "§f]§d DEBUG: " + message);
			}else{
				TextFormat.formattedConsoleOutput("§f[§9" + time.ToString("HH:mm:ss") + "§f]§d[" + prefix + "] DEBUG: " + message);
			}
		}

		public string getPrefix(){
			return prefix;
		}
	}
}