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
	class Player /*: CommandSender*/ {

		private Dictionary<string, Permission> PlayerPermissions = new Dictionary<string, Permission>();

		private Dictionary<int, Packet> PacketQueue = new Dictionary<int, Packet>();

		private IPEndPoint endpoint;

		private string username = "";

		private int packetcount = 0;

		private bool firstrecv = false;

		private int firstpacket;

		private int lastpacket;

		public Player(IPEndPoint endpoint){
			this.endpoint = endpoint;
			Server.GetInstance().OnlinePlayers.Add(this);
		}

		public bool HasPermission(string node){
			return PlayerPermissions.ContainsKey(node.ToLower());
		}

		public bool AddPermission(Permission permission){
			if(HasPermission(permission.GetNode())){
				return false;
			}
			PlayerPermissions.Add(permission.GetNode(), permission);
			return true;
		}
		
		public bool OverridePermission(Permission permission){
			if(HasPermission(permission.GetNode())){
				PlayerPermissions[permission.GetNode()] = permission;
				return true;
			}
			return false;
		}
		
		public bool RemovePermission(Permission permission){
			if(HasPermission(permission.GetNode())){
				PlayerPermissions.Remove(permission.GetNode());
				return true;
			}
			return false;
		}

		public void RecalculatePermissions(){
			Dictionary<string, Permission> globalpermissions = Permission.getGlobalPermissions();
			foreach(Permission permission in globalpermissions.Values){
				if(permission.GetPermissionLevel() == PermissionLevel.All){	//Add permission to All players
					AddPermission(permission);
				}else if(permission.GetPermissionLevel() == PermissionLevel.OP){	//Add permission only to OPs
					if(IsOP()){
						AddPermission(permission);
					}
				}else if(permission.GetPermissionLevel() == PermissionLevel.NotOP){	//Add permission only to players who are not OPs
					if(!IsOP()){
						AddPermission(permission);
					}
				}
			}
		}

		public IPEndPoint GetIPEndPoint(){
			return endpoint;
		}

		public string GetIPAddress(){
			return endpoint.Address.ToString();
		}

		public short GetPort(){
			return (short) endpoint.Port;
		}

		public string GetUsername(){
			return username;
		}

		public Dictionary<int, Packet> GetPacketQueue(){
			return PacketQueue;
		}

		/**
		 * [Unsafe] Sends a direct data packet to the client without checking if it has been received
		 *
		 */
		public void SendDirectDataPacket(Packet packet){
			packet.SetPacketCount(new Triad(packetcount));
			byte[] content = packet.Encode();
			PacketHandler.server.Send(content, content.Length, GetIPEndPoint());
		}

		/**
		 * Sends a data packet to the client and resends it until it has been received from the client
		 *
		 */
		public void SendQueuedDataPacket(Packet packet){
			if(PacketQueue.ContainsKey(packetcount)){
				packet.SetPacketCount(new Triad(packetcount));
				PacketQueue[packetcount] = packet;
				packetcount++;
			}else{
				packet.SetPacketCount(new Triad(packetcount));
				PacketQueue.Add(packetcount, packet);
				packetcount++;
			}
		}

		public void HandleDataPackets(byte[] data, IAsyncResult res){
			Logger.GetLogger().Critical(packetcount.ToString());
			if(data[0] >= 0x80 && data[0] <= 0x8F){	//Encapsulated Packet
				EncapsulationHelper helper = EncapsulationHelper.Decode(data);
				//Process Packet
				byte packetID = helper.GetPacketID();
				Logger.GetLogger().Debug(packetID.ToString("X2"));
				if(packetID == PacketID.MCPE_PING_PACKET){
					PingPacket ping = new PingPacket();
					ping.data = data;
					PongPacket pong = new PongPacket();
					pong.Identifier = ping.Identifier;
					pong.PacketCount = new Triad(packetcount);
					SendQueuedDataPacket(pong);
				}else{
					//Send ACK to Client
//					if(helper.GetPacketCount().ToInt32() == test){
//						ACK ack = new ACK(new Triad(helper.GetPacketCount().ToInt32()));
//						server.Send(ack.GetContent(), ack.GetContent().Length, sender);
//					}else{
//						ACK ack = new ACK(new Triad(test), new Triad(helper.GetPacketCount().ToInt32()));
//						server.Send(ack.GetContent(), ack.GetContent().Length, sender);
//					}
//					test = helper.GetPacketCount().ToInt32();
//					}
					if(!firstrecv){
						firstrecv = true;
						firstpacket = helper.GetPacketCount().ToInt32();
					}
					if(res.IsCompleted){
						firstrecv = false;
						lastpacket = helper.GetPacketCount().ToInt32();
						ACK ack = new ACK();
						ack.FirstPacket = new Triad(firstpacket);
						if(firstpacket == lastpacket){
							ack.AdditionalPacket = true;
						}else{
							ack.AdditionalPacket = false;
							ack.LastPacket = new Triad(lastpacket);
						}
						SendDirectDataPacket(ack);
					}
					if(packetID == PacketID.MCPE_CLIENT_CONNECT_PACKET){
						ClientConnectPacket ccp = new ClientConnectPacket();
						ccp.data = data;
						//ACK ack = new ACK(ccp, new Triad(0));
						//server.Send(ack.GetContent(), ack.GetContent().Length, sender);
						ccp.Decode();
						ServerHandshakePacket shp = new ServerHandshakePacket();
						shp.ServerPort = (short) Server.GetInstance().GetPort();
						shp.Session = ccp.Session;
						SendQueuedDataPacket(shp);
						Logger.GetLogger().Info("[§b" + GetIPAddress() + ":" + GetPort() + "§f] connected to the server");
					}else if(packetID == PacketID.MCPE_LOGIN_PACKET){
						LoginPacket lpacket = new LoginPacket();
						lpacket.data = data;
						lpacket.Decode();
						//CALL PRELOGIN EVENT HERE
						LoginStatusPacket lstatus = new LoginStatusPacket();
						lstatus.Status = 1; //To-Do
						lstatus.PacketCount = new Triad(packetcount);
						SendQueuedDataPacket(lstatus);
						//CALL LOGIN EVENT HERE
						StartGamePacket startgame = new StartGamePacket();	//To-Do
						startgame.Seed = 100;
						startgame.Generator = 100;
						startgame.Gamemode = 1;
						startgame.SpawnX = 0;
						startgame.SpawnY = 128;
						startgame.SpawnZ = 0;
						startgame.X = 0;
						startgame.Y = 0;
						startgame.Z = 0;
						SendQueuedDataPacket(startgame);
						Logger.GetLogger().Info("§e" + lpacket.Username + " joined the game");
						SetTimePacket settime = new SetTimePacket();	//To-Do
						settime.Ticks = 1000;
						SendQueuedDataPacket(settime);
						//CALL JOIN EVENT HERE
					}
				}
			}else if(data[0] == PacketID.ACK){	//ACK
				ACK ack = new ACK();
				ack.data = data;
				ack.Decode();
				if(ack.AdditionalPacket){
					int firstpacket = ack.FirstPacket.ToInt32();
					if(PacketQueue.ContainsKey(firstpacket)){
						PacketQueue.Remove(firstpacket);
					}
				}else{
					int firstpacket = ack.FirstPacket.ToInt32();
					int lastpacket = ack.LastPacket.ToInt32();
					int orderedfirst = Math.Min(firstpacket, lastpacket);
					int orderedlast = Math.Max(firstpacket, lastpacket);
					for(int i = orderedfirst; i <= orderedlast; i++){
						if(PacketQueue.ContainsKey(i)){
							PacketQueue.Remove(i);
						}
					}
				}
			}else if(data[0] == PacketID.NACK){	//NACK
			}
		}

		public bool IsOP(){
			//To-Do
			return false;
		}
		
	}
}

