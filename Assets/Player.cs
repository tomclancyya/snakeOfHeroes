using UnityEngine;
using System.Collections;

public class Player : MonoBehaviour {

    private Vector2 lookDirection;
    private float targetTime = 0.1f;
    private Navigator navigator;
    private float lastKeyEventX = 0;
    private float lastKeyEventY = 0;
    public GameObject hero;
    private bool isStop = false;
    private bool invertDirection = false;
    private float velocity = Consts.PLAYER_INIT_SPEED; 

    // Use this for initialization
    void Start() {
        lookDirection = (Vector2.right);
        navigator = new Navigator();
        lastKeyEventX = 0.0f;
        lastKeyEventY = 0.0f;
    }

    public void Faster() {
        velocity = velocity * Consts.PLAYER_SPEED_FACTOR;
    }

    // Update is called once per frame
    void Update() {
        if (!isStop) {
            float x = Input.GetAxisRaw("Horizontal");
            float y = Input.GetAxisRaw("Vertical");

            if (lastKeyEventX == 0.0f)
                lastKeyEventX = x;

            if (lastKeyEventY == 0.0f)
                lastKeyEventY = y;

            targetTime -= Time.deltaTime;
            if (targetTime <= 0.0f) {
                if (lastKeyEventY == -1)
                    PreviousHeroIsLeader();
                if (lastKeyEventY == 1)
                    NextHeroIsLeader();

                if (invertDirection) {
                    lookDirection = Quaternion.Euler(0, 0, -180) * ((Vector3)lookDirection);
                    invertDirection = false;
                } else if (lastKeyEventX == 1)
                    lookDirection = Quaternion.Euler(0, 0, -90) * ((Vector3)lookDirection);
                else if (lastKeyEventX == -1)
                    lookDirection = Quaternion.Euler(0, 0, 90) * ((Vector3)lookDirection);

                targetTime = 1.0f / velocity;
                lastKeyEventX = 0;
                lastKeyEventY = 0;
                gotoNextCell();
                Input.ResetInputAxes();
            }
        }
    }

    private void gotoNextCell() {
        GetComponentInChildren<Hero>().transform.position = transform.position;
        GetComponentInChildren<Hero>().FollowMe();
        transform.position = navigator.getNextCell(lookDirection, transform.position);
    }

    public void PreviousHeroIsLeader() {
        GameObject exLeader = GetComponentInChildren<Hero>().gameObject;
        exLeader.transform.parent = null;
        exLeader.GetComponent<Hero>().previousNeighbor.transform.parent = gameObject.transform;
        exLeader.GetComponent<Hero>().nextNeighbor.GetComponent<Hero>().isLast = false;
        exLeader.GetComponent<Hero>().isLast = true;
        hero = exLeader.GetComponent<Hero>().previousNeighbor;
        transform.position = hero.transform.position;
    }

    public void NextHeroIsLeader() {
        GameObject exLeader = GetComponentInChildren<Hero>().gameObject;
        exLeader.transform.parent = null;
        exLeader.GetComponent<Hero>().nextNeighbor.transform.parent = gameObject.transform;
        exLeader.GetComponent<Hero>().nextNeighbor.GetComponent<Hero>().isLast = false;
        exLeader.GetComponent<Hero>().nextNeighbor.GetComponent<Hero>().nextNeighbor.GetComponent<Hero>().isLast = true;
        hero = exLeader.GetComponent<Hero>().nextNeighbor;
        hero.transform.position = transform.position;
    }

    public void InvertDirection() {
        invertDirection = true;
    }

    public void Stop() {
        isStop = true;
    }

    public void Go() {
        isStop = false;
    }

    public bool IsStop(){
        return isStop;
    }
            
}
