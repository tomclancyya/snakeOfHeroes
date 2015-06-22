using UnityEngine;
using System.Collections;

public class GameManager : MonoBehaviour {

    private Navigator navigator;
    public Factory factory;
    public Wall wall;
    private int gameScore;
    public UIManager uiManager;

	// Use this for initialization
	void Start () {        
        navigator = new Navigator();
        CreateWall(); 
        StartGame();
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

    public void StartGame() {
        gameScore = 0;
        IncreaseScore(0);
        CreatePlayer();  
    }

    public void RestartGame() {
        GameObject[] gameObjects = GameObject.FindGameObjectsWithTag("Mob");
        for (var i = 0; i < gameObjects.Length; i++)
            Destroy(gameObjects[i]);
        Destroy(GameObject.FindGameObjectWithTag("Player"));
        StartCoroutine(showMessage());        
    }

    IEnumerator showMessage() {
        uiManager.showGameMessage(true);
        yield return new WaitForSeconds(2);
        uiManager.showGameMessage(false);
        StartGame();
    }

    public void CreatePlayer() {
        GameObject newPlayer = factory.CreatePlayer();
        newPlayer.transform.position = navigator.GetRandomCoordinate();
        
    }

    public void CreateWall() {
        wall.CreateWall(Consts.BOARD_SIZE_X, Consts.BOARD_SIZE_Y);
    }

    public void IncreaseScore(float value) {
        gameScore = gameScore + Mathf.RoundToInt(value);
        uiManager.GetComponent<UIManager>().setScore(gameScore);
    }
}
