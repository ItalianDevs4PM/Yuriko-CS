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
using System.Diagnostics;
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
				Stopwatch counter = new Stopwatch();
				counter.Start();
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
				if(!serverprop.Exists("server-name")){
					serverprop.Set("server-name", "Yuriko-CS Server");
				}
				if(!serverprop.Exists("server-port")){
					serverprop.Set("server-port", 19132);
				}
				if(!serverprop.Exists("gamemode")){
					serverprop.Set("gamemode", 1);
				}
				if(!serverprop.Exists("max-players")){
					serverprop.Set("max-players", 20);
				}
				MaxPlayers = serverprop.GetInt("max-players");
				if(!serverprop.Exists("motd")){
					serverprop.Set("motd", "§aYuriko-CS§f Minecraft: Pocket Edition Server");
				}
				Motd = serverprop.GetString("motd");
				if(!serverprop.Exists("spawn-protection")){
					serverprop.Set("spawn-protection", 10);
				}
				if(!serverprop.Exists("whitelist")){
					serverprop.Set("whitelist", false);
				}
				if(!serverprop.Exists("enable-autosave")){
					serverprop.Set("enable-autosave", true);
				}
				if(!serverprop.Exists("gamemode")){
					serverprop.Set("gamemode", 0);
				}
				if(!serverprop.Exists("force-gamemode")){
					serverprop.Set("force-gamemode", false);
				}
				if(!serverprop.Exists("enable-pvp")){
					serverprop.Set("enable-pvp", true);
				}
				if(!serverprop.Exists("difficulty")){
					serverprop.Set("difficulty", 2);
				}
				if(!serverprop.Exists("world-name")){
					serverprop.Set("world-name", "world");
				}
				if(!serverprop.Exists("world-generator")){
					serverprop.Set("world-generator", "NORMAL");
				}
				//if(!serverprop.exists("world-seed")){
				//	serverprop.set("world-seed", "");
				//}
				if(!serverprop.Exists("announce-achievements")){
					serverprop.Set("announce-achievements", true);
				}
				if(!serverprop.Exists("enable-query")){
					serverprop.Set("enable-query", true);
				}
				if(!serverprop.Exists("enable-rcon")){
					serverprop.Set("enable-rcon", false);
				}
				if(!serverprop.Exists("rcon-port")){
					serverprop.Set("rcon-port", 18345);
				}
				if(!serverprop.Exists("rcon-password")){
					serverprop.Set("rcon-password", "random");
				}
				serverprop.Save("server.properties");
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
				counter.Stop();
				Logger.GetLogger().Info("Load completed in " + (counter.ElapsedMilliseconds / 60f).ToString("0.000") + "s! Type §2\"help\"§f for help");
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
			return Cfg.GetInt("server-port");
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
