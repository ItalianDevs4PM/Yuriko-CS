using System;
using System.Collections.Generic;
using System.IO;

namespace YurikoCS {
	public class EnumConfig {
		
		private string fname;
		private List<object> content = new List<object>();

		public EnumConfig (){}

		public EnumConfig(string filename){
			fname = filename;
			load(filename);
		}

		public void reload(){
			load();
		}

		public void load(string filename){
			fname = filename;
			clear();
			if(!File.Exists(filename)){
				FileStream fs = File.Create(filename);
				fs.Close();
			}
			try{
				StreamReader file = new StreamReader(filename);
				string line;
				while((line = file.ReadLine()) != null){
					content.Add(line);
				}
				file.Close();
			}catch(Exception ex){
				//To-DO
			}
		}

		public void save(string filename){
			if(!File.Exists(filename)){
				FileStream fs = File.Create(filename);
				fs.Close();
			}
			try{
				StreamWriter file = new StreamWriter(filename);
				foreach(object obj in content){
					file.WriteLine(obj.ToString());
				}
				file.Close();
			}catch(Exception ex){
				//To-DO
			}
		}

		public void clear(){
			content.Clear();
		}

		public void add(object obj){
			content.Add(obj);
		}

		public void exists(object obj){
			return content.Contains(obj);
		}

		public void remove(object obj){
			content.Remove(obj);
		}
			
	}
}
