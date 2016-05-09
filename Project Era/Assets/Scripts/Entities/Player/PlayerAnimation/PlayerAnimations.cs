using UnityEngine;
using System.Collections;

public class PlayerAnimations : PlayerMovement
{

    public Animator anim;
    bool poop = true;
   public static bool canMove = true;




    void Start()
    {
        anim = GetComponent<Animator>();

    }


    void Update()
    {


        if (BattleTime.engageEnemy == true)
        {
            canMove = false;
        }



        if (canMove == true)
        {


            if (Input.GetKeyDown(KeyCode.UpArrow) || Input.GetKeyDown(KeyCode.I))
            {
                anim.SetInteger("Walking", 0);
                anim.SetInteger("Direction", -1);

            }



            if (Input.GetKeyDown(KeyCode.DownArrow) || Input.GetKeyDown(KeyCode.K))
            {
                anim.SetInteger("Walking", 1);
                anim.SetInteger("Direction", -1);
            }



            if (Input.GetKeyDown(KeyCode.LeftArrow) || Input.GetKeyDown(KeyCode.J))
            {
                anim.SetInteger("Walking", 2);
                anim.SetInteger("Direction", -1);

            }



            if (Input.GetKeyDown(KeyCode.RightArrow) || Input.GetKeyDown(KeyCode.L))
            {
                anim.SetInteger("Walking", 3);
                anim.SetInteger("Direction", -1);


            }





            //UpRight
            if ((Input.GetKey(KeyCode.I) || Input.GetKey(KeyCode.UpArrow)) && (Input.GetKey(KeyCode.L) || Input.GetKey(KeyCode.RightArrow)))
            {

                anim.SetInteger("Walking", 4);
                anim.SetInteger("Direction", -1);

            }

            else if (Input.GetKeyUp(KeyCode.I) || Input.GetKeyUp(KeyCode.UpArrow))
            {

                if (anim.GetCurrentAnimatorStateInfo(0).IsName("WalkUpRight"))
                {

                    anim.SetInteger("Walking", 3);
                    anim.SetInteger("Direction", -1);
                }
            }

            else if (Input.GetKeyUp(KeyCode.L) || Input.GetKeyUp(KeyCode.RightArrow))
            {

                if (anim.GetCurrentAnimatorStateInfo(0).IsName("WalkUpRight"))
                {

                    anim.SetInteger("Walking", 0);
                    anim.SetInteger("Direction", -1);
                }

            }




            //DownRight
            if ((Input.GetKey(KeyCode.K) || Input.GetKey(KeyCode.DownArrow)) && (Input.GetKey(KeyCode.L) || Input.GetKey(KeyCode.RightArrow)))
            {
                anim.SetInteger("Walking", 5);
                anim.SetInteger("Direction", -1);
            }
            else if (Input.GetKeyUp(KeyCode.K) || Input.GetKeyUp(KeyCode.DownArrow))
            {

                if (anim.GetCurrentAnimatorStateInfo(0).IsName("WalkDownRight"))
                {
                    anim.SetInteger("Walking", 3);
                    anim.SetInteger("Direction", -1);
                }
            }
            else if (Input.GetKeyUp(KeyCode.L) || Input.GetKeyUp(KeyCode.RightArrow))
            {

                if (anim.GetCurrentAnimatorStateInfo(0).IsName("WalkDownRight"))
                {
                    anim.SetInteger("Walking", 1);
                    anim.SetInteger("Direction", -1);
                }
            }




            //UpLeft
            if ((Input.GetKey(KeyCode.I) || Input.GetKey(KeyCode.UpArrow)) && (Input.GetKey(KeyCode.J) || Input.GetKey(KeyCode.LeftArrow)))
            {
                anim.SetInteger("Walking", 6);
                anim.SetInteger("Direction", -1);
            }
            else if (Input.GetKeyUp(KeyCode.I) || Input.GetKeyUp(KeyCode.UpArrow))
            {

                if (anim.GetCurrentAnimatorStateInfo(0).IsName("WalkUpLeft"))
                {
                    anim.SetInteger("Walking", 2);
                    anim.SetInteger("Direction", -1);
                }
            }
            else if (Input.GetKeyUp(KeyCode.J) || Input.GetKeyUp(KeyCode.LeftArrow))
            {

                if (anim.GetCurrentAnimatorStateInfo(0).IsName("WalkUpLeft"))
                {
                    anim.SetInteger("Walking", 0);
                    anim.SetInteger("Direction", -1);
                }
            }



            //DownLeft
            if ((Input.GetKey(KeyCode.K) || Input.GetKey(KeyCode.DownArrow)) && (Input.GetKey(KeyCode.J) || Input.GetKey(KeyCode.LeftArrow)))
            {
                anim.SetInteger("Walking", 7);
                anim.SetInteger("Direction", -1);
            }
            else if (Input.GetKeyUp(KeyCode.K) || Input.GetKeyUp(KeyCode.DownArrow))
            {

                if (anim.GetCurrentAnimatorStateInfo(0).IsName("WalkDownLeft"))
                {
                    anim.SetInteger("Walking", 2);
                    anim.SetInteger("Direction", -1);
                }
            }
            else if (Input.GetKeyUp(KeyCode.J) || Input.GetKeyUp(KeyCode.LeftArrow))
            {

                if (anim.GetCurrentAnimatorStateInfo(0).IsName("WalkDownLeft"))
                {
                    anim.SetInteger("Walking", 1);
                    anim.SetInteger("Direction", -1);
                }
            }

            //idk what this does
            if (Input.anyKey == false)
            {
                anim.SetInteger("Direction", direction);
                anim.SetInteger("Walking", -1);
            }

        }





           if (BattleTime.startAnimation == true)
           {
                anim.SetBool("BattleIntro", true);
                
            }

           else if (BattleTime.midAnimation == true)
        {
            anim.SetBool("BattleIntro", false);
            anim.SetBool("MidBattle", true);
        }
           else if (BattleTime.victoryAnimation == true)
        {
            anim.SetBool("BattleVictory", true);
        }
           






            


        }





        }
    



