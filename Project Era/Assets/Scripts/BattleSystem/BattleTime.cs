using UnityEngine;
using System.Collections;
using System.Collections.Generic;


public class BattleTime : MonoBehaviour {

    public static float timer = 0;
    public Animator anim;
   public static GameObject target;
   public static bool cutOffMovement = false;
   public static bool engageEnemy = false;
   
    bool walkToPosition = false;
    public static bool startAnimation = false;
    public static bool midAnimation = false;
    public static bool victoryAnimation = false;
    public static bool enemyAttackAnimation = false;

    public static bool joeyWasAttacked = false;
    public static bool peterWasAttacked = false;
    public static bool tiaWasAttacked = false;
    public static bool ricoWasAttacked = false;

    public static AllEnemyStats enemyStats;

    float distanceToEnemy;

    public static int enemyNum = 0;
    public int randomPlayer = 0;

    public static List<GameObject> enemies = new List<GameObject>();

    public static List<GameObject> players = new List<GameObject>();

    System.Random r = new System.Random();

    public AudioClip victoryMusic;
    public AudioClip getAttackedSound;
    


    //I guess list every enemy in the game here?
    public GameObject boxEnemy;



    




	// Use this for initialization
	void Start () {

        anim = GetComponent<Animator>();
        

    }
	
	// Update is called once per frame
	void Update () {


        

        if (cutOffMovement == true)
        {
            
            this.GetComponent<PlayerMovement>().enabled = false;
  
        }
        if (cutOffMovement == false)
        {
            timer = 0;
            this.GetComponent<PlayerMovement>().enabled = true;
        }

        //Move player to positions based on enemy encounter
        if (walkToPosition == true)
        {
            if (target.gameObject.tag == "Enemies")
            {
                distanceToEnemy = Vector3.Distance(transform.position, target.transform.position);

                if (distanceToEnemy < 3)
                {
                    GetComponent<Rigidbody2D>().AddForce(Vector2.up * 300);
                    anim.SetInteger("Walking", 0);
                    anim.SetInteger("Direction", -1);

                }

                else
                {
                    walkToPosition = false;
                    anim.SetInteger("Walking", -1);
                    anim.SetInteger("Direction", 1);
                    startAnimation = true;

                }
            }


            if (target.gameObject.tag == "Boss Dude")
            {
                distanceToEnemy = Vector3.Distance(transform.position, target.transform.position);

                if (distanceToEnemy < 3)
                {
                    GetComponent<Rigidbody2D>().AddForce(Vector2.up * 300);
                    anim.SetInteger("Walking", 0);
                    anim.SetInteger("Direction", -1);

                }

                else
                {
                    walkToPosition = false;
                    anim.SetInteger("Walking", -1);
                    anim.SetInteger("Direction", 1);
                    startAnimation = true;

                }

            }



            //------------
        }






        if (startAnimation == true)
            {
            
                timer++;
            if (timer > 300)
            {
                midAnimation = true;
                startAnimation = false;
                timer = 0;
            }
            }

            else if (midAnimation == true)
        {
            
            //See if all enemies are dead
            if (enemies.Count == 0)
            {
                midAnimation = false;
                victoryAnimation = true;
                timer = 0;

            }

        }

            else if (victoryAnimation == true)
        {
            timer++;

            if (timer == 10) {
                engageEnemy = false;
                SpinnerControl.inBattle = false;
                SpinnerArrowControl.inBattle = false;
               
                SoundManager.instance.PlayBattleSong(victoryMusic);


                //move stuff away
                

            }
            if (timer > 390)
            {
                anim.SetBool("BattleVictory", false);
                victoryAnimation = false;
                cutOffMovement = false;
                PlayerAnimations.canMove = true;
                SoundManager.instance.PlayBattleSong(null);
            }

        }





        //Have Enemies attack Players
        if (SpinnerControl.nextTurn == 5 && SpinnerControl.inBattle == true)
        {

            if (enemyNum < enemies.Count && enemyAttackAnimation == false)
            {
                timer = 0;
               
                randomPlayer = r.Next(0, players.Count);
                enemyAttackAnimation = true;
                
            }

            else if (enemyNum == enemies.Count)
            {
                
                SpinnerControl.enemiesTurnDone = true;
                
            }


            if (enemyAttackAnimation == true)
              {
                timer++;


                if (timer < 50)
                {
                    

                    //have enemy attack animation going here
                }

                else if (timer == 50)
                {
                    SoundManager.instance.PlaySoundEffect(getAttackedSound);
                }

                else if (timer > 50 && timer < 100)
                {

                    players[randomPlayer].GetComponent<SpriteRenderer>().color = Color.grey;

                }
                else if (timer > 100)
                {
                    enemyStats = enemies[enemyNum].GetComponent<AllEnemyStats>();



                    if (players[randomPlayer].gameObject.name == "Joey")
                    {
                        joeyWasAttacked = true;

                    }
                    else if (players[randomPlayer].gameObject.name == "Peter")
                    {
                        peterWasAttacked = true;
                    }
                    else if (players[randomPlayer].gameObject.name == "Tia")
                    {
                        tiaWasAttacked = true;
                    }
                    else if (players[randomPlayer].gameObject.name == "Rico")
                    {
                        ricoWasAttacked = true;
                    }


                    players[randomPlayer].GetComponent<SpriteRenderer>().color = Color.white;
                    enemyAttackAnimation = false;
                    timer = 0;
                    enemyNum++;
                }
              }

                


        }





    }

    void OnTriggerEnter2D(Collider2D other)
    {

        if (this.gameObject.tag == "Player")
        {


            //Battle by bridge
            if (other.gameObject.tag == "Boss Dude")
            {
              //  if (Input.GetKeyDown(KeyCode.A))
                //{
                    cutOffMovement = true;
                    engageEnemy = true;
                    walkToPosition = true;
                    target = other.gameObject;

                    players.Add(this.gameObject);
                    players.Add(GameObject.FindGameObjectWithTag("Player2"));
                    players.Add(GameObject.FindGameObjectWithTag("Player3"));
                    players.Add(GameObject.FindGameObjectWithTag("Player4"));

                    enemies.Add(other.gameObject);
                    
               // }
            }





            if (other.gameObject.tag == "Enemies")
            {

                cutOffMovement = true;
                engageEnemy = true;
                walkToPosition = true;
                target = other.gameObject;

                players.Add(this.gameObject);
                players.Add(GameObject.FindGameObjectWithTag("Player2"));
                players.Add(GameObject.FindGameObjectWithTag("Player3"));
                players.Add(GameObject.FindGameObjectWithTag("Player4"));



                enemies.Add(other.gameObject);
                enemies.Add(boxEnemy);

                
                
            }
        }





       



    }

    void LateUpdate()
    {
        if (engageEnemy == true)
        {
            engageEnemy = false;
            

        }



    }


}
