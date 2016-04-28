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

namespace YurikoCS {
	public class DefaultCommands {

		public static void RestoreDefaultCommands(){
			Command.RegisterCommand(new Command("exit", new ExitCommand()));
			Command.RegisterCommand(new Command("help", new HelpCommand()));
			Command.RegisterCommand(new Command("about", new AboutCommand()));
			Command.RegisterCommand (new Command ("version", new VersionCommand()));
		}
		
	}
}

