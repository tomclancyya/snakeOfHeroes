using UnityEngine;
using System.Collections;

static class Consts
{
    public static class Direction
    {
        public const int UP = 1;
        public const int RIGHT = 2;
        public const int DOWN = 3;
        public const int LEFT = 4;
    }

    public const float BOARD_SCALE = 1.0f; //amount of units, the distance between play board cell in real units value
    public const float BOARD_SCALE_SHIFT = BOARD_SCALE / 2; //the center position of first play board cell 
    public const int BOARD_SIZE_X = 20; //amount of cell on game board
    public const int BOARD_SIZE_Y = 10; //amount of cell on game board

    public const float SPAWN_SPEED = 1.0f;
    public const int MAX_MOBS = 30;

    
    public const float PLAYER_SPEED_FACTOR = 1.1f; // how we increase the player speed after win
    public const float PLAYER_INIT_SPEED = 1.5f;

    
}

