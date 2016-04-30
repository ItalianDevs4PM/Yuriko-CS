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
using System.Globalization;
using System.IO;

namespace YurikoCS {
	public class PropertiesConfig : Config {

		private Dictionary<string, object> content = new Dictionary<string, object>();
		private string fname;
		//Not for loading
		public PropertiesConfig(){}
		
		public PropertiesConfig(string filename){
			fname = filename;
			load(filename);
		}

		public void Reload(){
			load(fname);
		}

		private void load(string filename){
			fname = filename;
			content.Clear();
			if(!File.Exists(filename)){
				FileStream fs = File.Create(filename);
				fs.Close();
			}
			try{
				StreamReader file = new StreamReader(filename);
				string line;
				while((line = file.ReadLine()) != null){
					if(line.Contains("=")){
						int last = line.LastIndexOf("=");
						content.Add(line.Substring(0, last), line.Substring(last + 1));
					}
				}
				file.Close();
			}catch(Exception ex){
				//To-DO
			}
		}
		
		public void Save(){
			Save(fname);
		}
		
		public void Save(string filename){
			if(!File.Exists(filename)){
				FileStream fs = File.Create(filename);
				fs.Close();
			}
			try{
				StreamWriter file = new StreamWriter(filename);
				file.WriteLine("#Yuriko-CS Properties File");
				DateTime now = DateTime.Now;
				CultureInfo en = new CultureInfo("en-US");
				file.WriteLine("#" + now.ToString("ddd MMM dd HH:mm:ss zzz yyyy", en));
				foreach(string key in content.Keys){
					file.WriteLine(key + "=" + content[key].ToString());
				}
				file.Close();
			}catch(Exception ex){
				//To-DO
			}
		}
		
		public void clear(){
			content.Clear();
		}

		public void Unset(string key) {
			content.Remove(key);
		}

		public void Set(string key, object value) {
			if(Exists(key)){
				content[key] = value;
			}else{
				content.Add(key, value);
			}
		}

		public bool Exists(string key) {
			return content.ContainsKey(key);
		}

		public object Get(string key) {
			return content[key];
		}

		public string GetString(string key) {
			return content[key].ToString();
		}
		
		public bool IsString(string key) {
			return content[key].GetType() == typeof(string);
		}

		public bool GetBoolean(string key) {
			return Convert.ToBoolean(content[key].ToString());
		}

		public bool IsBoolean(string key) {
			return content[key].GetType() == typeof(bool);
		}

		public short GetShort(string key) {
			short res;
			short.TryParse(content[key].ToString(), out res);
			return res;
		}

		public bool IsShort(string key) {
			return content[key].GetType() == typeof(short);
		}

		public int GetInt(string key) {
			int res;
			int.TryParse(content[key].ToString(), out res);
			return res;
		}

		public bool IsInt(string key) {
			return content[key].GetType() == typeof(int);
		}

		public long GetLong(string key) {
			long res;
			long.TryParse(content[key].ToString(), out res);
			return res;
		}

		public bool IsLong(string key) {
			return content[key].GetType() == typeof(long);
		}

		public float GetFloat(string key) {
			float res;
			float.TryParse(content[key].ToString(), out res);
			return res;
		}

		public bool IsFloat(string key) {
			return content[key].GetType() == typeof(float);
		}

		public double GetDouble(string key) {
			double res;
			double.TryParse(content[key].ToString(), out res);
			return res;
		}

		public bool IsDouble(string key) {
			return content[key].GetType() == typeof(double);
		}
	}
}
