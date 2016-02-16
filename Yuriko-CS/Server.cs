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
using System.Net;

namespace YurikoCS {
	class Server {

		//Client Protocol Constants
		public const byte[] OFFLINE_MESSAGE_DATA_ID = {0x00, 0xff, 0xff, 0x00, 0xfe, 0xfe, 0xfe, 0xfe, 0xfd, 0xfd, 0xfd, 0xfd, 0x12, 0x34, 0x56, 0x78};
		public const string MCPE_VERSION = "0.14.0.b8";
		public const byte PROTOCOL_ID = 0x60;

		private static Server instance;

		private static string motd;

		public Server(){
			if(instance == null){
				instance = this;
				Config serverprop = new PropertiesConfig("server.properties");
				if(!serverprop.exists("server-name")){
					serverprop.set("server-name", "Yuriko-CS Server");
				}
				if(!serverprop.exists("server-port")){
					serverprop.set("server-port", 19132);
				}
				if(!serverprop.exists("gamemode")){
					serverprop.set("gamemode", 1);
				}
				if(!serverprop.exists("max-players")){
					serverprop.set("max-players", 20);
				}
				if(!serverprop.exists("motd")){
					serverprop.set("motd", "§aYuriko-CS§f Minecraft: Pocket Edition Server");
				}
				motd = serverprop.getString("motd");
				if(!serverprop.exists("spawn-protection")){
					serverprop.set("spawn-protection", 10);
				}
				if(!serverprop.exists("whitelist")){
					serverprop.set("whitelist", false);
				}
				if(!serverprop.exists("enable-autosave")){
					serverprop.set("enable-autosave", true);
				}
				if(!serverprop.exists("gamemode")){
					serverprop.set("gamemode", 0);
				}
				if(!serverprop.exists("force-gamemode")){
					serverprop.set("force-gamemode", false);
				}
				if(!serverprop.exists("enable-pvp")){
					serverprop.set("enable-pvp", true);
				}
				if(!serverprop.exists("difficulty")){
					serverprop.set("difficulty", 2);
				}
				if(!serverprop.exists("world-name")){
					serverprop.set("world-name", "world");
				}
				if(!serverprop.exists("world-generator")){
					serverprop.set("world-generator", "NORMAL");
				}
				//if(!serverprop.exists("world-seed")){
				//	serverprop.set("world-seed", "");
				//}
				if(!serverprop.exists("announce-achievements")){
					serverprop.set("announce-achievements", true);
				}
				if(!serverprop.exists("enable-query")){
					serverprop.set("enable-query", true);
				}
				if(!serverprop.exists("enable-rcon")){
					serverprop.set("enable-rcon", false);
				}
				if(!serverprop.exists("rcon-port")){
					serverprop.set("rcon-port", 18345);
				}
				if(!serverprop.exists("rcon-password")){
					serverprop.set("rcon-password", "random");
				}
				serverprop.save("server.properties");
			}else{
				Logger.critical("Server already initialized!");
			}
		}

		public string getMotd(){
			return motd;
		}

		public static Server getInstance(){
			return instance;
		}

		public void sendPacket(IPAddress ipaddress){
		}

		public void sendPacket(string ipaddress){
		}
	}
}
