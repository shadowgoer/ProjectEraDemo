using UnityEngine;
using System.Collections;

public class RicoStats : MonoBehaviour {

    public static int health;
    public static int maxHealth;

    public static int IP;
    public static int maxIP;

    public int attack;


    public static bool attackAnimation = false;
    bool doDamage = false;

    public static bool transferModule = false;

    public static bool ricoDead = false;
    int timer = 0;

    public Animator anim;

    public static AllEnemyStats enemyHealth;

    public AudioClip attackEnemy;
    public AudioClip transferModSound;

    public Color flashColor = new Color(1f, 0f, 0f, 0.8f);

    System.Random r = new System.Random();

    // Use this for initialization
    void Start () {

        //Rico's Starting Stats
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

        //Have Rico Attack Target
        if (doDamage == true)
        {
            enemyHealth = BattleTime.enemies[BattleIconAttackSelectRico.selectedEnemy].GetComponent<AllEnemyStats>();
            enemyHealth.health = enemyHealth.health - attack;

            //Go to the next character's turn
            doDamage = false;
            SpinnerControl.ricoTurn = false;
            BattleIconAttackSelectRico.selectedEnemy = 0;
            SpinnerControl.nextTurn++;
        }

        //Using SAI: Transfer Module
        if (transferModule == true)
        {
            //do an animation HERE -----

            if (BattleTime.players[BattleIconSAISelectRico.selectedPlayer].gameObject.name == "Joey")
            {
                JoeyStats.IP = JoeyStats.IP + r.Next(35, 40);
                if (JoeyStats.IP > JoeyStats.maxIP)
                {
                    JoeyStats.IP = JoeyStats.maxIP;
                }
            }
            else if (BattleTime.players[BattleIconSAISelectRico.selectedPlayer].gameObject.name == "Tia")
            {
                TiaStats.IP = TiaStats.IP + r.Next(35, 40);
                if (TiaStats.IP > TiaStats.maxIP)
                {
                    TiaStats.IP = TiaStats.maxIP;
                }
            }
            else if (BattleTime.players[BattleIconSAISelectRico.selectedPlayer].gameObject.name == "Peter")
            {
                PeterStats.IP = PeterStats.IP + r.Next(35, 40);
                if (PeterStats.IP > PeterStats.maxIP)
                {
                    PeterStats.IP = PeterStats.maxIP;
                }
            }
            else if (BattleTime.players[BattleIconSAISelectRico.selectedPlayer].gameObject.name == "Rico")
            {
                
                IP = IP + r.Next(35, 40);
                if (IP > maxIP)
                {
                    IP = maxIP;
                }
            }
            SoundManager.instance.PlaySoundEffect(transferModSound);

            //next turn
            transferModule = false;
            SpinnerControl.ricoTurn = false;

            BattleIconSAISelectRico.selectedPlayer = 0;
            SpinnerControl.nextTurn++;
        }




        //Rico Getting attacked
        if (BattleTime.ricoWasAttacked == true)
        {
            health = health - BattleTime.enemyStats.attack;


            BattleTime.ricoWasAttacked = false;
        }

        //Seeing if Rico is dead
        if (health < 1)
        {
            BattleTime.players.Remove(this.gameObject);
            ricoDead = true;
            this.GetComponent<SpriteRenderer>().color = Color.black;
            health = 0;
        }
        else if (health > 0)
        {
            ricoDead = false;
        }
    }
}
