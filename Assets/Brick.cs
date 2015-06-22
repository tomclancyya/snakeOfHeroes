using UnityEngine;
using System.Collections;

/*
 * The brick in thw wall, which wait the player collisison
 */
public class Brick : MonoBehaviour {

    public GameManager gameManager;

	// Use this for initialization
	void Start () {
        gameManager = GameObject.FindGameObjectWithTag("GameManager").GetComponent<GameManager>();	
	}
	
    void OnTriggerEnter2D(Collider2D some_object) {
        {
            GameObject player;
            if (some_object.gameObject.transform.parent != null
                && some_object.gameObject.transform.parent.tag == "Player" ) {

                player = some_object.gameObject.transform.parent.gameObject;
                if (some_object.GetComponent<Hero>().AreYouAlone()) {
                    gameManager.RestartGame();
                } else {
                    some_object.GetComponent<Hero>().ByeMyHeroWasHonoredToServeYou();
                    player.GetComponent<Player>().InvertDirection();
                }
            }                       
        }
    }
}
