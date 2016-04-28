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

namespace YurikoCS {
	public class AboutCommand : CommandExecutor {

		public AboutCommand(){}

		public bool OnCommand(CommandSender sender, Command command, string[] args){
			sender.SendMessage(TextFormat.translateColors('&',"&6\nYuriko-CS: A fast and full-featured Minecraft: Pocket Edition server software written in C#\n\nThis program is free software: you can redistribute it and/or modify\nit under the terms of the GNU Lesser General Public License as published by\nthe Free Software Foundation, either version 3 of the License, or\n(at your option) any later version.\nThis program is distributed in the hope that it will be useful,\nbut WITHOUT ANY WARRANTY; without even the implied warranty of\nMERCHANTABILITY or FITNESS FOR A PARTICULAR PURPOSE.  See the\nGNU Lesser General Public License for more details.\nYou should have received a copy of the GNU Lesser General Public License\nalong with this program.  If not, see <http://www.gnu.org/licenses/>.\n\n# Links\n[Website](http://devs4pm.eu)\n[Forums](http://devs4pm.eu/forums)\n[Jenkins](http://devs4pm.eu)\n[Wiki and API Docs](https://github.com/ItalianDevs4PM/Yuriko-CS/wiki/)\n# Downloads\nStill In Development\n# Contributions\nItalianDevs4PM Team\n# Third-Party Libraries\nStill In Development\n\nMade in Italy by ItalianDevs4PM"));
				return true;
		}
	}
}