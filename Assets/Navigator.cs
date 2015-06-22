using UnityEngine;
using System.Collections;

/*
 * Class helps to get coordinate of next moving cell
 */
class Navigator {

    public Vector2 getNextCell(Vector2 direction, Vector2 position) {
        Vector2 new_position = new Vector2();
        Coordinate coordinate = new Coordinate(position);
        if (position.y == Consts.BOARD_SIZE_Y ||
            coordinate.y == 1 ||
            coordinate.x == Consts.BOARD_SIZE_X ||
            coordinate.x == 1) {
            new_position = coordinate.getWorldCoords();
        } else {
            coordinate.sum(direction);
            new_position = coordinate.getWorldCoords();
        }

        return new_position;
    }

    public Vector2 GetRandomCoordinate() {
        Coordinate boardCoord;
        Vector2 newCoords = new Vector2();

        // We do not want to spend lot of time to looking for empty place
        for (int i = 0; i < 100; i++) {
            boardCoord = new Coordinate(Random.Range(0, Consts.BOARD_SIZE_X), Random.Range(0, Consts.BOARD_SIZE_Y));
            newCoords = boardCoord.getWorldCoords();
            Collider2D[] hitColliders = Physics2D.OverlapCircleAll(newCoords + new Vector2(Consts.BOARD_SCALE_SHIFT, Consts.BOARD_SCALE_SHIFT), 0.9f);
            if (hitColliders.Length == 0)
                break;
            else {
                ;// Debug.Log("Some Object take the resp place!");  
            }
        }
        return newCoords;

    }
}

