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
	interface Config {

		void save();

		void save(string filename);

		void reload();

		void set(string key, Object value);
		
		void unset(string key);
		
		bool exists(string key);
		
		object get(string key);
		
		string getString(string key);
		
		bool isString(string key);
		
		bool getBoolean(string key);
		
		bool isBoolean(string key);
		
		short getShort(string key);
		
		bool isShort(string key);
		
		int getInt(string key);
		
		bool isInt(string key);
		
		long getLong(string key);
		
		bool isLong(string key);
		
		float getFloat(string key);
		
		bool isFloat(string key);
		
		double getDouble(string key);
		
		bool isDouble(string key);

	}
}

