using UnityEngine;
using System.Collections;

public class Hero : Mob {
    public GameObject nextNeighbor = null;
    public GameObject previousNeighbor = null;
    public bool isBussy = false;
    //public bool isHead;
    public bool isTeammate = false;
    public bool isLast = false;
    private float teamTotalPower;

    void Start() {
        nextNeighbor = gameObject;
        previousNeighbor = gameObject;
    }

    void OnTriggerEnter2D(Collider2D some_object) {
        if (!isTeammate 
            && some_object.gameObject.transform.parent != null 
            && some_object.gameObject.transform.parent.tag == "Player") {
            MyHeroIWantFollowToYou(some_object.gameObject);
        }
    }

    // Attach the hero to hero's chain
    public void MyHeroIWantFollowToYou(GameObject myHero) {
        isTeammate = true;
        isLast = true;
        previousNeighbor = myHero;
        myHero.GetComponent<Hero>().nextNeighbor.GetComponent<Hero>().previousNeighbor = gameObject;
        myHero.GetComponent<Hero>().nextNeighbor.GetComponent<Hero>().isLast = false;
        nextNeighbor = myHero.GetComponent<Hero>().nextNeighbor;
        myHero.GetComponent<Hero>().nextNeighbor = gameObject;
    }

    //Detach the hero from hero's chain
    public void ByeMyHeroWasHonoredToServeYou() {
        previousNeighbor.GetComponent<Hero>().nextNeighbor = nextNeighbor;
        Player parent = GetComponentInParent<Player>();
        parent.gameObject.transform.position = previousNeighbor.transform.position;
        previousNeighbor.transform.SetParent(parent.gameObject.transform);
        nextNeighbor.GetComponent<Hero>().previousNeighbor = previousNeighbor;
        Destroy(gameObject);
    }

    protected override void Death() {
        ByeMyHeroWasHonoredToServeYou();
        Destroy(this);
    }

    // tell the previos chainhero to get new position
    public void FollowMe() {
        if (isLast == false) {
            previousNeighbor.GetComponent<Hero>().FollowMe();
            previousNeighbor.transform.position = transform.position;
        }
    }  

    public bool AreYouAlone() {
        return (previousNeighbor == nextNeighbor);
    }

    public override float AttackPowerModificator(Mob enemy) {
        float attackPower = Sword;
        if (MobType == enemy.GetComponent<Mob>().MobType) {
            Debug.Log("Doble power!");
            attackPower = attackPower * 2;
        }
        attackPower += teamTotalPower;
        return attackPower;
    }

    private void setTotalPower() {
        float totalPower = Sword;
        if (isTeammate && gameObject.transform.parent != null) {
            totalPower = (GetTeamPower() - Sword);
            GetComponent<Light>().range = (Sword + 100) / 100 + (totalPower / 500);
            teamTotalPower = totalPower / 50;     
        } else {
            GetComponent<Light>().range = (Sword + 100) / 100;
            teamTotalPower = 0;
        }   
        
    }

    void Update() {
        setTotalPower();
    }

    public float GetTeamPower(){
       float newPower = this.Sword; 
       if (!isLast)
           newPower += previousNeighbor.GetComponent<Hero>().GetTeamPower();
       return newPower;
    } 
}

