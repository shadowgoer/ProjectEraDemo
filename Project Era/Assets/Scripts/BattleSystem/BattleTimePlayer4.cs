using UnityEngine;
using System.Collections;

public class BattleTimePlayer4 : MonoBehaviour {

    float timer = 0;
    public Animator anim;
    GameObject target;
    public static bool cutOffMovement = false;
    public static bool engageEnemy = false;

    bool walkToPosition = false;
    public static bool startAnimation = false;
    public static bool midAnimation = false;
    public static bool victoryAnimation = false;

    // Use this for initialization
    void Start () {
        anim = GetComponent<Animator>();
    }
	
	// Update is called once per frame
	void Update () {

        if (BattleTime.engageEnemy == true)
        {
            cutOffMovement = true;
            walkToPosition = true;
        }

        //Turn Movement Off
        if (cutOffMovement == true)
        {

            this.GetComponent<Player4Movement>().enabled = false;

        }
        else if (cutOffMovement == false)
        {
            this.GetComponent<Player4Movement>().enabled = true;
        }

        if (walkToPosition == true)
        {
            if (transform.position.y < BattleTime.target.transform.position.y + 3)
            {
                GetComponent<Rigidbody2D>().AddForce(Vector2.up * 300);
                anim.SetInteger("Walking", 0);
                anim.SetInteger("Direction", -1);
            }
            else if (transform.position.x + 0.1f < BattleTime.target.transform.position.x + 3)
            {
                GetComponent<Rigidbody2D>().AddForce(Vector2.right * 300);
                anim.SetInteger("Walking", 3);
                anim.SetInteger("Direction", -1);
            }
            else if (transform.position.x - 0.1f > BattleTime.target.transform.position.x + 3)
            {
                GetComponent<Rigidbody2D>().AddForce(Vector2.left * 300);
                anim.SetInteger("Walking", 2);
                anim.SetInteger("Direction", -1);
            }

            else
            {
                walkToPosition = false;
                anim.SetInteger("Walking", -1);
                anim.SetInteger("Direction", 1);
                startAnimation = true;
                timer = 0;
            }
        }

        if (startAnimation == true)
        {

            timer++;
            if (timer > 300)
            {
                midAnimation = true;
                startAnimation = false;
            }
        }

        else if (midAnimation == true)
        {
            

            if (BattleTime.enemies.Count == 0)
            {
                midAnimation = false;
                victoryAnimation = true;
                timer = 0;
            }

        }
        else if (victoryAnimation == true)
        {
            timer++;
            if (timer > 300)
            {
                anim.SetBool("BattleVictory", false);
                victoryAnimation = false;
                cutOffMovement = false;
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
