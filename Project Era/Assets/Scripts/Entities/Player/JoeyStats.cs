using UnityEngine;
using System.Collections;

public class JoeyStats : MonoBehaviour {

    public static int health;
    public static int maxHealth;

    public static int IP;
    public static int maxIP;

    public int attack;



   public static bool attackAnimation = false;
    public static bool firstAidKit = false;
    bool doDamage = false;
    public static bool joeyDead = false;
    int timer = 0;

    public Animator anim;
    

    public static AllEnemyStats enemyHealth;

    public AudioClip attackEnemy;
    public AudioClip firstAidSound;
    public Color flashColor = new Color(1f, 0f, 0f, 0.8f);

    System.Random r = new System.Random();

    // Use this for initialization
    void Start () {

        //Joey's Starting Stats
        
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

        //Have Joey Attack Target
        if (doDamage == true)
        {
            enemyHealth = BattleTime.enemies[BattleIconAttackSelectJoey.selectedEnemy].GetComponent<AllEnemyStats>();
            enemyHealth.health = enemyHealth.health - attack;

            //Go to the next character's turn
            doDamage = false;
            SpinnerControl.joeyTurn = false;
            BattleIconAttackSelectJoey.selectedEnemy = 0;
            SpinnerControl.nextTurn++;
        }


        //Using SAI: First Aid Kit

       if (firstAidKit == true)
        {
            //do an animation HERE -----

            if (BattleTime.players[BattleIconSAISelectJoey.selectedPlayer].gameObject.name == "Joey")
            {
                health = health + r.Next(60, 71);
                if(health > maxHealth)
                {
                    health = maxHealth;
                }
            }
            else if (BattleTime.players[BattleIconSAISelectJoey.selectedPlayer].gameObject.name == "Tia")
            {
                TiaStats.health = TiaStats.health + r.Next(60, 71);
                if (TiaStats.health > TiaStats.maxHealth)
                {
                    TiaStats.health = TiaStats.maxHealth;
                }
            }
            else if (BattleTime.players[BattleIconSAISelectJoey.selectedPlayer].gameObject.name == "Peter")
            {
                PeterStats.health = PeterStats.health + r.Next(60, 71);
                if (PeterStats.health > PeterStats.maxHealth)
                {
                    PeterStats.health = PeterStats.maxHealth;
                }
            }
            else if (BattleTime.players[BattleIconSAISelectJoey.selectedPlayer].gameObject.name == "Rico")
            {
                RicoStats.health = RicoStats.health + r.Next(60, 71);
                if (RicoStats.health > RicoStats.maxHealth)
                {
                    RicoStats.health = RicoStats.maxHealth;
                }
            }

            SoundManager.instance.PlaySoundEffect(firstAidSound);

            //next turn
            firstAidKit = false;
            SpinnerControl.joeyTurn = false;
            BattleIconSAISelectJoey.selectedPlayer = 0;
            SpinnerControl.nextTurn++;
        }





        //Joey Getting attacked
        if (BattleTime.joeyWasAttacked == true)
        {
            health = health - BattleTime.enemyStats.attack;
            print("Joey Health = " + health);

            BattleTime.joeyWasAttacked = false;
        }

        //Seeing if Joey is dead
        if (health < 1)
        {
            BattleTime.players.Remove(this.gameObject);
            joeyDead = true;
            this.GetComponent<SpriteRenderer>().color = Color.black;
            health = 0;
        }
        else if (health > 0)
        {
            joeyDead = false;
        }

    }
}
