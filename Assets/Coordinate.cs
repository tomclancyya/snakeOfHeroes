using UnityEngine;
using System.Collections;


/*
* Store the coordinatex,y on the game-playing board
*/
class Coordinate
{
    public int x = 0;
    public int y = 0;
    public Vector2 coordinate;
    Vector2 shiftVector = new Vector2(Consts.BOARD_SCALE_SHIFT, Consts.BOARD_SCALE_SHIFT);

    // convert realcoords to gameboard cood
    public Coordinate(Vector2 position)
    {
        coordinate = toBoardCoord(position);
    }

    private Vector2 toBoardCoord(Vector2 worldCoords)
    {
        Vector2 new_position = (worldCoords - shiftVector) / Consts.BOARD_SCALE;
        return new Vector2(Mathf.RoundToInt(new_position.x), Mathf.RoundToInt(new_position.y));
    }

    private Vector2 toWorldCoord(Vector2 boardCoord)
    {
        Vector2 wordCoords = boardCoord * Consts.BOARD_SCALE + shiftVector;
        return wordCoords;
    }

    public Vector2 getWorldCoords()
    {
        return toWorldCoord(coordinate);
    }

    public Coordinate(int x = 0, int y = 0)
    {
        this.x = x;
        this.y = y;
        coordinate = new Vector2(x, y);
    }

    public void sum(Vector2 vector)
    {
        coordinate += vector;
    }

    public void sumY(int y)
    {
        this.y += y;
    }

    public void sumX(int x)
    {
        this.x += x;
    }

    public Vector2 getCoordinate()
    {
        return coordinate;
    }
}

