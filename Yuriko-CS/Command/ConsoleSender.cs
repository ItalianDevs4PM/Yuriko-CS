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

namespace YurikoCS
{
	public class ConsoleSender : CommandSender {

		private Dictionary<string, Permission> consolepermissions = new Dictionary<string, Permission>();

		public ConsoleSender() {}

		public string GetName(){
			return "CONSOLE";
		}

		public void SendMessage(string message){
			Logger.getLogger().Info(message);
		}

		public bool HasPermission(string node){
			return consolepermissions.ContainsKey(node.ToLower());
		}

		public bool AddPermission(Permission permission){
			if(HasPermission(permission.GetNode())){
				return false;
			}
			consolepermissions.Add(permission.GetNode(), permission);
			return true;
		}
		
		public bool OverridePermission(Permission permission){
			if(HasPermission(permission.GetNode())){
				consolepermissions[permission.GetNode()] = permission;
				return true;
			}
			return false;
		}
		
		public bool RemovePermission(Permission permission){
			if(HasPermission(permission.GetNode())){
				consolepermissions.Remove(permission.GetNode());
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
					AddPermission(permission);
				}
			}
		}

		public bool IsOP(){
			return true;
		}
		
	}
}

