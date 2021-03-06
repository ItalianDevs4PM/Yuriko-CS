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
using System.Net;
using System.Threading;

namespace YurikoCS {
	class Server {

		//Client Protocol Constants
		public static readonly byte[] OFFLINE_MESSAGE_DATA_ID = new byte[]{0x00, 0xff, 0xff, 0x00, 0xfe, 0xfe, 0xfe, 0xfe, 0xfd, 0xfd, 0xfd, 0xfd, 0x12, 0x34, 0x56, 0x78};
		public const string MCPE_VERSION = "0.14.0.7";
		public const byte MCPE_PROTOCOL_ID = 0x45;

		private static Server Instance;
		private static Config Cfg;
		private static string Motd;
		private static int MaxPlayers;
		private Thread UDPServerThread;
		public List<Player> OnlinePlayers = new List<Player>();
		private ConsoleSender ConsSender;

		public Server(){
			if(Instance == null){
				Instance = this;
				new Logger();
				String cwd = Directory.GetCurrentDirectory();
				//Yuriko-CS Logo! :D
				Logger.GetLogger().Info("§e***************************************************");
				Logger.GetLogger().Info("§e* §a _   __          _ _                ____ ____   §e*");
				Logger.GetLogger().Info("§e* §a\\ \\ / /   _ _ __(_) | _____        / ___/ ___|  §e*");
				Logger.GetLogger().Info("§e* §a \\ V / | | | '__| | |/ / _ \\ _____| |   \\___ \\  §e*");
				Logger.GetLogger().Info("§e* §a  | || |_| | |  | |   < (_) |_____| |___ ___) | §e*");
				Logger.GetLogger().Info("§e* §a  |_| \\__,_|_|  |_|_|\\_\\___/       \\____|____/  §e*");
				Logger.GetLogger().Info("§e*                                                 §e*");
				Logger.GetLogger().Info("§e***************************************************");
				Logger.GetLogger().Info("Starting Yuriko-CS §bv" + Version.YURIKO_CS_VERSION + " §f[§bAPI " + Version.YURIKO_CS_API_VERSION + "§f][Build §b#" + Version.YURIKO_CS_BUILD + "§f]");
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
				MaxPlayers = serverprop.getInt("max-players");
				if(!serverprop.exists("motd")){
					serverprop.set("motd", "§aYuriko-CS§f Minecraft: Pocket Edition Server");
				}
				Motd = serverprop.getString("motd");
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
				Cfg = serverprop;
				ConsSender = new ConsoleSender();
				DefaultPermissions.RestoreDefaultPermissions();
				DefaultCommands.RestoreDefaultCommands();
				Logger.GetLogger().Info("Starting Server on port: §b" + GetPort());
				Logger.GetLogger().Info("Starting UDP Server thread");
				PacketHandler pk = new PacketHandler(GetPort());
				pk.Start();
				Thread UDPServerSenderThread = new Thread(new ThreadStart(pk.StartSendThread));
				UDPServerSenderThread.Start();
				waitConsoleInput();
			}else{
				Logger.GetLogger().Critical("Server already initialized!");
			}
		}

		private void waitConsoleInput(){
			Console.Write(">");
			string cmd = Console.ReadLine();
			Command.Execute(GetConsoleSender(), cmd);
			waitConsoleInput();
		}

		public string GetMotd(){
			return Motd;
		}

		public int GetPort(){
			return Cfg.getInt("server-port");
		}

		public int GetMaxPlayers(){
			return MaxPlayers;
		}

		public static Server GetInstance(){
			return Instance;
		}

		public void SendPacket(IPAddress ipaddress){
		}

		public void SendPacket(string ipaddress){
		}

		public List<Player> GetOnlinePlayers(){
			return OnlinePlayers;
		}

		public ConsoleSender GetConsoleSender(){
			return ConsSender;
		}
	}
}
