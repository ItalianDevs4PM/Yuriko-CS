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
	public class Command {

		private string command;
		private string description;
		private CommandExecutor executor;
		private Permission permission;
		private static Dictionary<string, Command> registeredcmds = new Dictionary<string, Command>();

		public Command(string command, CommandExecutor executor){
			this.command = command.ToLower();
			this.executor = executor;
			this.description = null;
			this.permission = null;
		}

		public Command(string command, CommandExecutor executor, string description){
			this.command = command.ToLower();
			this.executor = executor;
			this.description = description;
			this.permission = null;
		}

		public Command(string command, CommandExecutor executor, string description, Permission permission){
			this.command = command.ToLower();
			this.executor = executor;
			this.description = description;
			this.permission = permission;
		}

		public CommandExecutor GetExecutor(){
			return executor;
		}

		public string GetCommandName(){
			return command;
		}

		public string GetCommandDescription(){
			return command;
		}

		public Permission GetCommandPermission(){
			return permission;
		}

		public static bool Execute(CommandSender sender, string command){
			command = command.Trim();
			if(!StringFunctions.IsNullOrOnlySpaces(command)){
				string[] args = null;
				if(command.Contains(" ")){
					args = command.Substring(command.IndexOf(' ')).Split(' ');
					command = command.Substring(0, command.IndexOf(' '));
				}
				if(registeredcmds.ContainsKey(command.ToLower())){
					Permission permission = registeredcmds[command.ToLower()].GetCommandPermission();
					if(permission == null || sender.HasPermission(permission.GetNode())){
						return registeredcmds[command.ToLower()].GetExecutor().OnCommand(sender, registeredcmds[command.ToLower()], args);
					}
					sender.SendMessage("§cYou don't have permissions to execute this command");
					return false;
				}
				sender.SendMessage("§cUnknown command. Use \"/help\" for a list of all available commands.");
			}
			return false;
		}

		public static bool RegisterCommand(Command command){
			if(CommandExists(command)){
				return false;
			}
			registeredcmds.Add(command.GetCommandName(), command);
			return true;
		}

		public static bool OverrideCommand(Command command){
			if(CommandExists(command)){
				registeredcmds[command.GetCommandName()] = command;
				return true;
			}
			return false;
		}

		public static bool UnregisterCommand(Command command){
			if(CommandExists(command)){
				registeredcmds.Remove(command.GetCommandName());
				return true;
			}
			return false;
		}

		public static bool CommandExists(Command command){
			return registeredcmds.ContainsKey(command.GetCommandName());
		}
	}
}
