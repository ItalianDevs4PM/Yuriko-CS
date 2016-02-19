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

		private Dictionary<string, Permission> playerpermissions = new Dictionary<string, Permission>();

		public Player(string name, IPAddress address){
		}

		public bool HasPermission(string node){
			return playerpermissions.ContainsKey(node.ToLower());
		}

		public bool AddPermission(Permission permission){
			if(HasPermission(permission.GetNode())){
				return false;
			}
			playerpermissions.Add(permission.GetNode(), permission);
			return true;
		}
		
		public bool OverridePermission(Permission permission){
			if(HasPermission(permission.GetNode())){
				playerpermissions[permission.GetNode()] = permission;
				return true;
			}
			return false;
		}
		
		public bool RemovePermission(Permission permission){
			if(HasPermission(permission.GetNode())){
				playerpermissions.Remove(permission.GetNode());
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

		public bool IsOP(){
			//To-Do
			return false;
		}
		
	}
}
