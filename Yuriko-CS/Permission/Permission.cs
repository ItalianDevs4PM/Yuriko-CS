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

namespace YurikoCS {
	public class Permission {

		private string node;
		private string description;
		private PermissionLevel level;
		private static Dictionary<string, Permission> globalpermissions = new Dictionary<string, Permission>();

		public Permission(string node){
			this.node = node.ToLower();
			this.description = null;
			this.level = PermissionLevel.All;
		}

		public Permission(string node, string description){
			this.node = node.ToLower();
			this.description = description;
			this.level = PermissionLevel.All;
		}

		public Permission(string node, string description, PermissionLevel level){
			this.node = node.ToLower();
			this.description = description;
			this.level = level;
		}

		public string GetNode(){
			return node;
		}
		
		
		public string GetDescription(){
			return node;
		}
		
		public PermissionLevel GetPermissionLevel(){
			return level;
		}

		public static Dictionary<string, Permission> getGlobalPermissions(){
			return globalpermissions;
		}

		public static bool RegisterPermission(Permission permission){
			if(PermissionExists(permission)){
				return false;
			}
			globalpermissions.Add(permission.GetNode(), permission);
			return true;
		}

		public static bool OverridePermission(Permission permission){
			if(PermissionExists(permission)){
				globalpermissions[permission.GetNode()] = permission;
				return true;
			}
			return false;
		}
		
		public static bool UnregisterPermission(Permission permission){
			if(PermissionExists(permission)){
				globalpermissions.Remove(permission.GetNode());
				return true;
			}
			return false;
		}
		
		public static bool PermissionExists(Permission permission){
			return globalpermissions.ContainsKey(permission.GetNode());
		}

		public static void RecalculatePermissions(){
			foreach(Permission permission in globalpermissions.Values){
				if(permission.GetPermissionLevel() == PermissionLevel.All){	//Add permission to All players
					Server.GetInstance().GetConsoleSender().AddPermission(permission);
					foreach(Player player in Server.GetInstance().GetOnlinePlayers()){
						player.AddPermission(permission);
					}
				}else if(permission.GetPermissionLevel() == PermissionLevel.OP){	//Add permission only to OPs
					Server.GetInstance().GetConsoleSender().AddPermission(permission);
					foreach(Player player in Server.GetInstance().GetOnlinePlayers()){
						if(player.IsOP()){
							player.AddPermission(permission);
						}
					}
				}else if(permission.GetPermissionLevel() == PermissionLevel.NotOP){	//Add permission only to players who are not OPs
					foreach(Player player in Server.GetInstance().GetOnlinePlayers()){
						if(!player.IsOP()){
							player.AddPermission(permission);
						}
					}
				}
			}
		}
		
	}
}
