using UnityEngine;
using System.Collections;

public class Mob : MonoBehaviour {

    private float hp = 20.0f;
    private float sword = 5.0f;
    private float shield = 0.0f;
    Enums.MobType mobType;

    public Enums.MobType MobType {
        get { return mobType; }
        set { mobType = value; }
    }

    public float Shield {
        get { return shield; }
        set { shield = value; }
    }

    public float Hp {
        get { return hp; }
        set { hp = value;

        float hpIndicator = (hp / 100) - 0.5f;

        GetComponent<LineRenderer>().SetPosition(1, new Vector3(-0.45f,hpIndicator,-1.0f));
        }
    }

    public float Sword {
        get { return sword; }
        set { sword = value; }
    }

    public void Attack(Mob enemy) {
        float damage = AttackPowerModificator(enemy) - enemy.Shield;
        if (damage < 1)
            damage = 1;
        enemy.Hit(damage);
    }

    public virtual float AttackPowerModificator(Mob enemy) {
        return sword;

    }

    // when attacker Bit the mob
    public void Hit(float damage) {
        Hp = hp - damage;
        StartCoroutine(ShowTextDamage(damage)); 
    }

    IEnumerator ShowTextDamage(float damage){
        GetComponentInChildren<TextMesh>().gameObject.renderer.enabled = true;
        GetComponentInChildren<TextMesh>().text = "-" + damage;
        yield return new WaitForSeconds(0.4f);
        GetComponentInChildren<TextMesh>().gameObject.renderer.enabled = false;
        if (hp <= 0)
            Death();
    }

    protected virtual void Death() {        
        Destroy(gameObject);
    }

    
}
