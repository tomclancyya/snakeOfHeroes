using UnityEngine;
using System.Collections;

/*
 * The class controll the fight between hero and enemy
 */
public class Referee : MonoBehaviour {
    private Enemy enemy;
    private Hero hero;
    private Player player;
    Mob currentAttacker;
    Mob currentDefender;
    public GameManager gameManager;


    public void StartFight(Enemy enemy, Hero hero) {
        this.enemy = enemy;
        this.hero = hero;
        hero.GetComponent<Hero>().isBussy = true;
        this.player = hero.GetComponentInParent<Player>();
        currentAttacker = enemy;
        currentDefender = hero;
        player.Stop();

        StartCoroutine(Fight());
    }

    private IEnumerator Fight() {
        while (currentDefender.Hp > 0 && currentAttacker.Hp > 0) {
            
            currentAttacker.Attack(currentDefender);
            yield return new WaitForSeconds(0.5f);

            if (currentDefender.Hp <= 0 || currentAttacker.Hp <= 0) {
                if (enemy.Hp <= 0) {                   
                    hero.GetComponent<Hero>().isBussy = false;
                    hero.GetComponentInParent<Player>().Faster();
                    gameManager.GetComponent<GameManager>().IncreaseScore(hero.Hp);                    
                }
                if (hero.Hp <= 0) {
                    if (hero.AreYouAlone())
                        gameManager.RestartGame();
                }
                break;            
            }
            changeTurn();
        }
        player.Go(); 
    }

    private void changeTurn() {        
        if (null == currentAttacker.GetComponent(typeof(Hero))) {
            currentAttacker = hero;
            currentDefender = enemy;
        } else {
            currentAttacker = enemy;
            currentDefender = hero;
        }
       
    }
}
