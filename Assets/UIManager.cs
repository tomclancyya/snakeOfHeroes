using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class UIManager : MonoBehaviour {

    public GameObject scoreIU;
    private Text scoreTextUI;
    public Text gameMessage;    

	// Use this for initialization
    void Awake() {
        gameMessage.gameObject.SetActive(false);
        scoreTextUI = scoreIU.GetComponent<Text>();
        scoreTextUI.text = "Score: " + 0;        	
	}

 
    public void setScore(float value) {
        scoreTextUI.text = "Score: " + Mathf.RoundToInt(value); 
    }

    public void showGameMessage(bool isShow){
        gameMessage.gameObject.SetActive(isShow);
    }
}
