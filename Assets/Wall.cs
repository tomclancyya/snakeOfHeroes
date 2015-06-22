using UnityEngine;
using System.Collections;

public class Wall : MonoBehaviour {
    private Navigator navigator;
    public Factory factory;

	// Use this for initialization
	void Start () {
        navigator = new Navigator();	
	}

    public void CreateWall(int sizeX, int sizeY){
        GameObject brick;
        for (int i = -1; i <= Consts.BOARD_SIZE_Y + 1; i++) {
            brick = factory.CreateBrick();
            brick.transform.parent = gameObject.transform;
            brick.gameObject.transform.position = new Coordinate(-1, i).getWorldCoords();
        }
        for (int i = -1; i <= Consts.BOARD_SIZE_X + 1; i++) {
            brick = factory.CreateBrick();
            brick.transform.parent = gameObject.transform;
            brick.gameObject.transform.position = new Coordinate(i, Consts.BOARD_SIZE_Y + 1).getWorldCoords();
        }
        for (int i = -1; i <= Consts.BOARD_SIZE_Y + 1; i++) {
            brick = factory.CreateBrick();
            brick.transform.parent = gameObject.transform;
            brick.gameObject.transform.position = new Coordinate(Consts.BOARD_SIZE_X + 1, i).getWorldCoords();
        }
        for (int i = -1; i <= Consts.BOARD_SIZE_X + 1; i++) {
            brick = factory.CreateBrick();
            brick.transform.parent = gameObject.transform;
            brick.gameObject.transform.position = new Coordinate(i, -1).getWorldCoords();
        }
        
    }
	
	
}
