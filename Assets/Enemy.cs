using UnityEngine;
using System.Collections;

public class Enemy : Mob {

    void OnTriggerEnter2D(Collider2D some_object) {
        {
            if (some_object.gameObject.transform.parent != null 
                && some_object.gameObject.transform.parent.tag == "Player"
                && !some_object.GetComponent<Hero>().isBussy )
                    HeyMisterTrickOrTreat(some_object.gameObject);
        }
    }

    private void HeyMisterTrickOrTreat(GameObject hero) {
        GameObject.FindGameObjectWithTag("Referee").GetComponent<Referee>().StartFight(this, hero.GetComponent<Hero>());
    }
}

