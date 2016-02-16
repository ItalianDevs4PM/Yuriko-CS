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
using System.IO;

namespace YurikoCS
{
	class YurikoCS
	{
		public static void Main (string[] args)
		{
			String cwd = Directory.GetCurrentDirectory();
			Logger.notice("Starting Yuriko-CS v1.0");
			if(!Directory.Exists(cwd + "/players")){
				Directory.CreateDirectory(cwd + "/players");
			}
			if(!Directory.Exists(cwd + "/plugins")){
				Directory.CreateDirectory(cwd + "/plugins");
			}
			if(!Directory.Exists(cwd + "/worlds")){
				Directory.CreateDirectory(cwd + "/worlds");
			}
			Server server = new Server();
		}
	}
}
