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
	class PacketID {

		public const byte ATTRIBUTE_PACKET = 0x60;
		public const byte LOGIN_PACKET = 0x8f;
		public const byte PLAY_STATUS_PACKET = 0x90;
		public const byte DISCONNECT_PACKET = 0x91;
		public const byte BATCH_PACKET = 0x92;
		public const byte TEXT_PACKET = 0x93;
		public const byte SET_TIME_PACKET = 0x94;
		public const byte START_GAME_PACKET = 0x95;
		public const byte ADD_PLAYER_PACKET = 0x96;
		public const byte REMOVE_PLAYER_PACKET = 0x97;
		public const byte ADD_ENTITY_PACKET = 0x98;
		public const byte REMOVE_ENTITY_PACKET = 0x99;
		public const byte ADD_ITEM_ENTITY_PACKET = 0x9a;
		public const byte TAKE_ITEM_ENTITY_PACKET = 0x9b;
		public const byte MOVE_ENTITY_PACKET = 0x9c;
		public const byte MOVE_PLAYER_PACKET = 0x9d;
		public const byte REMOVE_BLOCK_PACKET = 0x9e;
		public const byte UPDATE_BLOCK_PACKET = 0x9f;
		public const byte ADD_PAINTING_PACKET = 0xa0;
		public const byte EXPLODE_PACKET = 0xa1;
		public const byte LEVEL_EVENT_PACKET = 0xa2;
		public const byte BLOCK_EVENT_PACKET = 0xa3;
		public const byte ENTITY_EVENT_PACKET = 0xa4;
		public const byte MOB_EFFECT_PACKET = 0xa5;
		public const byte UPDATE_ATTRIBUTES_PACKET = 0xa6;
		public const byte MOB_EQUIPMENT_PACKET = 0xa7;
		public const byte MOB_ARMOR_EQUIPMENT_PACKET = 0xa8;
		public const byte INTERACT_PACKET = 0xa9;
		public const byte USE_ITEM_PACKET = 0xaa;
		public const byte PLAYER_ACTION_PACKET = 0xab;
		public const byte HURT_ARMOR_PACKET = 0xac;
		public const byte SET_ENTITY_DATA_PACKET = 0xad;
		public const byte SET_ENTITY_MOTION_PACKET = 0xae;
		public const byte SET_ENTITY_LINK_PACKET = 0xaf;
		public const byte SET_HEALTH_PACKET = 0xb0;
		public const byte SET_SPAWN_POSITION_PACKET = 0xb1;
		public const byte ANIMATE_PACKET = 0xb2;
		public const byte RESPAWN_PACKET = 0xb3;
		public const byte DROP_ITEM_PACKET = 0xb4;
		public const byte CONTAINER_OPEN_PACKET = 0xb5;
		public const byte CONTAINER_CLOSE_PACKET = 0xb6;
		public const byte CONTAINER_SET_SLOT_PACKET = 0xb7;
		public const byte CONTAINER_SET_DATA_PACKET = 0xb8;
		public const byte CONTAINER_SET_CONTENT_PACKET = 0xb9;
		public const byte CRAFTING_DATA_PACKET = 0xba;
		public const byte CRAFTING_EVENT_PACKET = 0xbb;
		public const byte ADVENTURE_SETTINGS_PACKET = 0xbc;
		public const byte BLOCK_ENTITY_DATA_PACKET = 0xbd;
		public const byte FULL_CHUNK_DATA_PACKET = 0xbf;
		public const byte SET_DIFFICULTY_PACKET = 0xc0;
		public const byte SET_PLAYER_GAMETYPE_PACKET = 0xc2;
		public const byte PLAYER_LIST_PACKET = 0xc3;
		public const byte SPAWN_EXPERIENCE_ORB_PACKET = 0xc5;

	}
}
