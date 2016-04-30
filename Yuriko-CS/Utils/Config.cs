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

		void Save();

		void Save(string filename);

		void Reload();

		void Set(string key, Object value);
		
		void Unset(string key);
		
		bool Exists(string key);
		
		object Get(string key);
		
		string GetString(string key);
		
		bool IsString(string key);
		
		bool GetBoolean(string key);
		
		bool IsBoolean(string key);
		
		short GetShort(string key);
		
		bool IsShort(string key);
		
		int GetInt(string key);
		
		bool IsInt(string key);
		
		long GetLong(string key);
		
		bool IsLong(string key);
		
		float GetFloat(string key);
		
		bool IsFloat(string key);
		
		double GetDouble(string key);
		
		bool IsDouble(string key);

	}
}

