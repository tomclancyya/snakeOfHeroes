using UnityEngine;
using System.Collections;
using System.Reflection;
//using System;

public class Factory : MonoBehaviour {
    public GameObject heroPefab;
    public GameObject enemyPefab;
    public GameObject playerPefab;
    public GameObject brickPrefab;
    public Sprite[] mobSprites;
    static private System.Array mobTypes = System.Enum.GetValues(typeof(Enums.MobType));

    public GameObject SetCommonMobParams(GameObject mob) {
        float sword = Random.Range(50, 100);
        Enums.MobType mobType = RandMobType();

        mob.GetComponent<SpriteRenderer>().sprite = mobSprites[Random.Range(0, mobSprites.Length)];
        mob.GetComponent<Mob>().MobType = mobType;
        mob.GetComponentInChildren<TextMesh>().gameObject.renderer.enabled = false;
        mob.GetComponent<Light>().range = (sword + 100) / 100;
        mob.GetComponent<Mob>().Sword = sword;
        // the GetComponentInChild do not work for SpriteRenderer;
        mob.transform.Find("Type").gameObject.GetComponent<SpriteRenderer>().sprite = Resources.Load<Sprite>(mobType.ToString());

        return mob;
    }

    public GameObject CreateHero() {
        GameObject hero = Object.Instantiate(heroPefab, Vector3.zero, Quaternion.identity) as GameObject;
        hero.GetComponent<Hero>().Hp = Random.Range(20, 100);
        hero.GetComponent<Hero>().Shield = Random.Range(1, 70);

        return SetCommonMobParams(hero);
    }

    public GameObject CreateEnemy() {
        GameObject enemy = Object.Instantiate(enemyPefab, Vector3.zero, Quaternion.identity) as GameObject;
        enemy.GetComponent<Enemy>().Hp = Random.Range(20, 70);
        enemy.GetComponent<Enemy>().Shield = Random.Range(1, 70);

        return SetCommonMobParams(enemy);
    }

    public GameObject CreatePlayer() {
        GameObject player = Object.Instantiate(playerPefab, Vector3.zero, Quaternion.identity) as GameObject;
        GameObject hero = CreateHero();
        player.GetComponent<Player>().hero = hero;
        hero.transform.SetParent(player.transform);
        hero.GetComponent<Hero>().previousNeighbor = hero;
        hero.GetComponent<Hero>().nextNeighbor = hero;
        hero.GetComponent<Hero>().isTeammate = true;
        hero.GetComponent<Hero>().isLast = true;
        return player;
    }

    public GameObject CreateRandomMob() {
        if (Random.Range(0, 2) == 1)
            return CreateEnemy();
        else
            return CreateHero();
    }

    public GameObject CreateBrick() {
        GameObject brick = Object.Instantiate(brickPrefab, Vector3.zero, Quaternion.identity) as GameObject;
        return brick;
    }

    private Enums.MobType RandMobType() {
        string mobType = mobTypes.GetValue(Random.Range(0, mobTypes.Length)).ToString();
        return (Enums.MobType)mobTypes.GetValue(Random.Range(0, mobTypes.Length));
    }
}
