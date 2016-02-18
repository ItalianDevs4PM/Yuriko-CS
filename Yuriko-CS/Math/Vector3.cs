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
	public class Vector3 {

		public double x;
		public double y;
		public double z;

		public Vector3 (double x, double y, double z) {
			this.x = x;
			this.y = y;
			this.z = z;
		}

		public Vector3 (Vector3 vector){
			x = vector.x;
			y = vector.y;
			z = vector.z;
		}

		public double getX(){
			return x;
		}

		public double getY(){
			return y;
		}

		public double getZ(){
			return z;
		}

		public Vector3 floor(){
			return new Vector3(Math.Floor(x), Math.Floor(y), Math.Floor(z));
		}

		public Vector3 round(){
			return new Vector3(Math.Round(x), Math.Round(y), Math.Round(z));
		}

		public Vector3 ceil(){
			return new Vector3(Math.Ceiling(x), Math.Ceiling(y), Math.Ceiling(z));
		}

		public Vector3 abs(){
			return new Vector3(Math.Abs(x), Math.Abs(y), Math.Abs(z));
		}

		public double distanceSquared(Vector3 v){
			return Math.Pow(v.x - x, 2) + Math.Pow(v.y - y, 2) + Math.Pow(v.z - z, 2);
		}

		public double distance(Vector3 v){
			return Math.Sqrt(distanceSquared(v));
		}
		
	}
}
