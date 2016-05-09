using UnityEngine;
using System.Collections;

public class TiaStats : MonoBehaviour {

    public static int health;
    public static int maxHealth;

    public static int IP;
    public static int maxIP;

    public int attack;


    public static bool attackAnimation = false;
    bool doDamage = false;

    public static bool weaknessFlash = false;

    public static bool tiaDead = false;
    int timer = 0;

    public Animator anim;

    public static AllEnemyStats enemyStat;
    

    public AudioClip attackEnemy;
    public AudioClip weaknessFlashSound;

    public Color flashColor = new Color(1f, 0f, 0f, 0.8f);

    // Use this for initialization
    void Start () {

        //Tia's Starting Stats
        health = 100;
        maxHealth = 100;

        IP = 50;
        maxIP = 100;

        attack = 40;


        anim = GetComponent<Animator>();
    }
	
	// Update is called once per frame
	void Update () {

        if (attackAnimation == true)
        {
            timer++;

            if (timer < 100)
            {
                anim.SetBool("MidBattle", false);
                anim.SetBool("Attack", true);
                if (timer == 30)
                {
                    SoundManager.instance.PlaySoundEffect(attackEnemy);
                }
                if (timer > 30 && timer < 80)
                {
                    BattleTime.enemies[BattleIconAttackSelectJoey.selectedEnemy].GetComponent<SpriteRenderer>().color = Color.Lerp(flashColor, Color.white, 75 * Time.deltaTime);
                }
            }
            else
            {
                BattleTime.enemies[BattleIconAttackSelectJoey.selectedEnemy].GetComponent<SpriteRenderer>().color = Color.white;
                anim.SetBool("Attack", false);
                anim.SetBool("MidBattle", true);
                timer = 0;
                attackAnimation = false;
                doDamage = true;
            }
        }

        //Have Tia Attack Target
        if (doDamage == true)
        {
            enemyStat = BattleTime.enemies[BattleIconAttackSelectTia.selectedEnemy].GetComponent<AllEnemyStats>();
            enemyStat.health = enemyStat.health - attack;

            //Go to the next character's turn
            doDamage = false;
            SpinnerControl.tiaTurn = false;
            BattleIconAttackSelectTia.selectedEnemy = 0;
            SpinnerControl.nextTurn++;
        }


        //Using SAI: Weakness Flash
        if (weaknessFlash == true)
        {
            //do an animation HERE -----

           enemyStat = BattleTime.enemies[BattleIconSAISelectTia.selectedEnemy].GetComponent<AllEnemyStats>();
            enemyStat.attack = enemyStat.attack - 10;
            if (enemyStat.attack < 0)
            {
                enemyStat.attack = 0;
            }

            SoundManager.instance.PlaySoundEffect(weaknessFlashSound);

            //next turn
            weaknessFlash = false;
            SpinnerControl.tiaTurn = false;

            BattleIconSAISelectTia.selectedEnemy = 0;
            SpinnerControl.nextTurn++;

        }


        //Tia Getting attacked
        if (BattleTime.tiaWasAttacked == true)
        {
            health = health - BattleTime.enemyStats.attack;
            print("Tia Health = " + health);

            BattleTime.tiaWasAttacked = false;
        }

        //Seeing if Tia is dead
        if (health < 1)
        {
            BattleTime.players.Remove(this.gameObject);
            tiaDead = true;
            this.GetComponent<SpriteRenderer>().color = Color.black;
            health = 0;
        }
        else if (health > 0)
        {
            tiaDead = false;
        }
    }
}
