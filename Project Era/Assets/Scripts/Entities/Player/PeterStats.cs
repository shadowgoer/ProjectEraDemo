using UnityEngine;
using System.Collections;

public class PeterStats : MonoBehaviour {

    public static int health;
    public static int maxHealth;

    public static int IP;
    public static int maxIP;

    public int attack;



    public static bool attackAnimation = false;
    bool doDamage = false;

    public static bool briefcase = false;

    public static bool peterDead = false;
    int timer = 0;

    public Animator anim;

    public static AllEnemyStats enemyStat;

    public AudioClip attackEnemy;
    public AudioClip briefCaseSound;

    public Color flashColor = new Color(1f, 0f, 0f, 0.8f);

    System.Random r = new System.Random();

    // Use this for initialization
    void Start () {

        //Peter's Starting Stats
        health = 100;
        maxHealth = 100;

        IP = 50;
        maxIP = 100;

        attack = 40;


        anim = GetComponent<Animator>();


    }
	
	// Update is called once per frame
	void Update () {

        //Start Attack animation and attack enemy
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

        //Have Peter Attack Target
        if (doDamage == true)
        {
            enemyStat = BattleTime.enemies[BattleIconAttackSelectPeter.selectedEnemy].GetComponent<AllEnemyStats>();
            enemyStat.health = enemyStat.health - attack;

            //Go to the next character's turn
            doDamage = false;
            SpinnerControl.peterTurn = false;
            BattleIconAttackSelectPeter.selectedEnemy = 0;
            SpinnerControl.nextTurn++;
        }

        //Using SAI: Briefcase
        if (briefcase == true)
        {

            //do an animation HERE -----

            enemyStat = BattleTime.enemies[BattleIconSAISelectPeter.selectedEnemy].GetComponent<AllEnemyStats>();
            
            enemyStat.health = enemyStat.health - (int)(attack * rnd(0.7, 1.5));

            SoundManager.instance.PlaySoundEffect(briefCaseSound);

            //next turn
            briefcase = false;
            SpinnerControl.peterTurn = false;

            BattleIconSAISelectPeter.selectedEnemy = 0;
            SpinnerControl.nextTurn++;


        }



        //Peter Getting attacked
        if (BattleTime.peterWasAttacked == true)
        {
            health = health - BattleTime.enemyStats.attack;
            

            BattleTime.peterWasAttacked = false;
        }

        //Seeing if Peter is dead
        if (health < 1)
        {
            BattleTime.players.Remove(this.gameObject);
            peterDead = true;
            this.GetComponent<SpriteRenderer>().color = Color.black;
            health = 0;
        }

        else if (health > 0)
        {
            peterDead = false;
        }


    }




    double rnd(double a, double b)
    {
        return a + r.NextDouble() * (b - a);
    }
}
