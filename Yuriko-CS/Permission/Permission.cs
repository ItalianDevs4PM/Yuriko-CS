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
	public class Permission {

		private string node;
		private string description;
		private PermissionDefaults defaults;

		public Permission(string node){
			this.node = node;
		}

		public Permission(string node, string description){
		}

		public Permission(string node, string description, PermissionDefaults defaults){
		}

		public string getNode(){
			return node;
		}

		
		public string getDescription(){
			return node;
		}

		public PermissionDefaults getDefaults(){
			return defaults;
		}
	}
}
