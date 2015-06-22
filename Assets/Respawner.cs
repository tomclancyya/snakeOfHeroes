using UnityEngine;
using System.Collections;

/*
 * Create the Mobs every some seconds
 */
public class Respawner : MonoBehaviour {
    float targetTime = 1.0f;
    public Factory factory;
    private Navigator navigator;

	// Use this for initialization
	void Start () {
        navigator = new Navigator();	
	}
	
	// Update is called once per frame
	void Update () {

        targetTime -= Time.deltaTime;

        if (targetTime <= 0.0f
            && GameObject.FindGameObjectsWithTag("Mob").Length < Consts.MAX_MOBS 
            && GameObject.FindGameObjectsWithTag("Player").Length > 0) {
            
            GameObject newMob = factory.CreateRandomMob();
            newMob.transform.position = navigator.GetRandomCoordinate();
            targetTime = Consts.SPAWN_SPEED;
        }
	}


}
