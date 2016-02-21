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

		public const byte MCPE_UNCONNECTED_PING = 0x01;
		public const byte MCPE_OPEN_CONNECTION_REQUEST = 0x05;
		public const byte MCPE_OPEN_CONNECTION_REPLY = 0x06;
		public const byte MCPE_OPEN_CONNECTION_REQUEST_2 = 0x07;
		public const byte MCPE_OPEN_CONNECTION_REPLY_2 = 0x08;
		public const byte MCPE_OPEN_CONNECTIONS = 0x1C;
		public const byte MCPE_CLIENT_CONNECT_PACKET = 0x09;
		public const byte MCPE_SERVER_HANDSHAKE_PACKET = 0x10;
		public const byte MCPE_CLIENT_HANDSHAKE_PACKET = 0x13;
		public const byte MCPE_ATTRIBUTE_PACKET = 0x60;
		public const byte MCPE_LOGIN_PACKET = 0x8f;
		public const byte MCPE_PLAY_STATUS_PACKET = 0x90;
		public const byte MCPE_DISCONNECT_PACKET = 0x91;
		public const byte MCPE_BATCH_PACKET = 0x92;
		public const byte MCPE_TEXT_PACKET = 0x93;
		public const byte MCPE_SET_TIME_PACKET = 0x94;
		public const byte MCPE_START_GAME_PACKET = 0x95;
		public const byte MCPE_ADD_PLAYER_PACKET = 0x96;
		public const byte MCPE_REMOVE_PLAYER_PACKET = 0x97;
		public const byte MCPE_ADD_ENTITY_PACKET = 0x98;
		public const byte MCPE_REMOVE_ENTITY_PACKET = 0x99;
		public const byte MCPE_ADD_ITEM_ENTITY_PACKET = 0x9a;
		public const byte MCPE_TAKE_ITEM_ENTITY_PACKET = 0x9b;
		public const byte MCPE_MOVE_ENTITY_PACKET = 0x9c;
		public const byte MCPE_MOVE_PLAYER_PACKET = 0x9d;
		public const byte MCPE_REMOVE_BLOCK_PACKET = 0x9e;
		public const byte MCPE_UPDATE_BLOCK_PACKET = 0x9f;
		public const byte MCPE_ADD_PAINTING_PACKET = 0xa0;
		public const byte MCPE_EXPLODE_PACKET = 0xa1;
		public const byte MCPE_LEVEL_EVENT_PACKET = 0xa2;
		public const byte MCPE_BLOCK_EVENT_PACKET = 0xa3;
		public const byte MCPE_ENTITY_EVENT_PACKET = 0xa4;
		public const byte MCPE_MOB_EFFECT_PACKET = 0xa5;
		public const byte MCPE_UPDATE_ATTRIBUTES_PACKET = 0xa6;
		public const byte MCPE_MOB_EQUIPMENT_PACKET = 0xa7;
		public const byte MCPE_MOB_ARMOR_EQUIPMENT_PACKET = 0xa8;
		public const byte MCPE_INTERACT_PACKET = 0xa9;
		public const byte MCPE_USE_ITEM_PACKET = 0xaa;
		public const byte MCPE_PLAYER_ACTION_PACKET = 0xab;
		public const byte MCPE_HURT_ARMOR_PACKET = 0xac;
		public const byte MCPE_SET_ENTITY_DATA_PACKET = 0xad;
		public const byte MCPE_SET_ENTITY_MOTION_PACKET = 0xae;
		public const byte MCPE_SET_ENTITY_LINK_PACKET = 0xaf;
		public const byte MCPE_SET_HEALTH_PACKET = 0xb0;
		public const byte MCPE_SET_SPAWN_POSITION_PACKET = 0xb1;
		public const byte MCPE_ANIMATE_PACKET = 0xb2;
		public const byte MCPE_RESPAWN_PACKET = 0xb3;
		public const byte MCPE_DROP_ITEM_PACKET = 0xb4;
		public const byte MCPE_CONTAINER_OPEN_PACKET = 0xb5;
		public const byte MCPE_CONTAINER_CLOSE_PACKET = 0xb6;
		public const byte MCPE_CONTAINER_SET_SLOT_PACKET = 0xb7;
		public const byte MCPE_CONTAINER_SET_DATA_PACKET = 0xb8;
		public const byte MCPE_CONTAINER_SET_CONTENT_PACKET = 0xb9;
		public const byte MCPE_CRAFTING_DATA_PACKET = 0xba;
		public const byte MCPE_CRAFTING_EVENT_PACKET = 0xbb;
		public const byte MCPE_ADVENTURE_SETTINGS_PACKET = 0xbc;
		public const byte MCPE_BLOCK_ENTITY_DATA_PACKET = 0xbd;
		public const byte MCPE_FULL_CHUNK_DATA_PACKET = 0xbf;
		public const byte MCPE_SET_DIFFICULTY_PACKET = 0xc0;
		public const byte MCPE_SET_PLAYER_GAMETYPE_PACKET = 0xc2;
		public const byte MCPE_PLAYER_LIST_PACKET = 0xc3;
		public const byte MCPE_SPAWN_EXPERIENCE_ORB_PACKET = 0xc5;

	}
}
