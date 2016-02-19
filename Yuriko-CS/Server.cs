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
using System.IO;
using System.Net;
using System.Threading;

namespace YurikoCS {
	class Server {

		//Client Protocol Constants
		public static readonly byte[] OFFLINE_MESSAGE_DATA_ID = new byte[]{0x00, 0xff, 0xff, 0x00, 0xfe, 0xfe, 0xfe, 0xfe, 0xfd, 0xfd, 0xfd, 0xfd, 0x12, 0x34, 0x56, 0x78};
		public const string MCPE_VERSION = "0.14.0.7";
		public const byte MCPE_PROTOCOL_ID = 0x45;

		private static Server instance;
		private static Config cfg;
		private static string motd;
		private static int maxplayers;
		private Thread UDPServerThread;
		private List<Player> onlineplayers = new List<Player>();
		private ConsoleSender consolesender;

		public Server(){
			if(instance == null){
				instance = this;
				new Logger();
				String cwd = Directory.GetCurrentDirectory();
				Logger.getLogger().Info("Starting Yuriko-CS §bv" + Version.YURIKO_CS_VERSION + " §f[§bAPI " + Version.YURIKO_CS_API_VERSION + "§f][Build §b#" + Version.YURIKO_CS_BUILD + "§f]");
				if(!Directory.Exists(cwd + "/players")){
					Directory.CreateDirectory(cwd + "/players");
				}
				if(!Directory.Exists(cwd + "/plugins")){
					Directory.CreateDirectory(cwd + "/plugins");
				}
				if(!Directory.Exists(cwd + "/worlds")){
					Directory.CreateDirectory(cwd + "/worlds");
				}
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
				maxplayers = serverprop.getInt("max-players");
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
				cfg = serverprop;
				consolesender = new ConsoleSender();
				DefaultPermissions.RestoreDefaultPermissions();
				DefaultCommands.RestoreDefaultCommands();
				Logger.getLogger().Info("Starting Server on port: §b" + GetPort());
				Logger.getLogger().Info("Starting UDP Server thread");
				PacketListener pk = new PacketListener(GetPort());
				Thread UDPServerThread = new Thread(new ThreadStart(pk.Start));
				UDPServerThread.Start();
				waitConsoleInput();
			}else{
				Logger.getLogger().Critical("Server already initialized!");
			}
		}

		private void waitConsoleInput(){
			Console.Write(">");
			string cmd = Console.ReadLine();
			Command.Execute(GetConsoleSender(), cmd);
			waitConsoleInput();
		}

		public string GetMotd(){
			return motd;
		}

		public int GetPort(){
			return cfg.getInt("server-port");
		}

		public int GetMaxPlayers(){
			return maxplayers;
		}

		public static Server GetInstance(){
			return instance;
		}

		public void SendPacket(IPAddress ipaddress){
		}

		public void SendPacket(string ipaddress){
		}

		public List<Player> GetOnlinePlayers(){
			return onlineplayers;
		}

		public ConsoleSender GetConsoleSender(){
			return consolesender;
		}
	}
}
