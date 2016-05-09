using UnityEngine;
using System.Collections;

public class SpinnerArrowControl : MonoBehaviour
{
    bool activateBattle = false;
    public static bool inBattle = false;
    bool moveIn = true;

    bool freakOut = false;

    float moveToPosition = 0;
    

    

    // Use this for initialization
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
       

        if (BattleTime.engageEnemy == true)
        {
            activateBattle = true;
            GetComponent<SpriteRenderer>().color = Color.gray;
        }

        if (activateBattle == true)
        {
            transform.position = Camera.main.ViewportToWorldPoint(new Vector3(1.192f, 0.812f, 1));
            inBattle = true;
            activateBattle = false;
        }

        if (inBattle == true)
        {

            if (moveIn == true)
            {

                moveToPosition++;
                if (moveToPosition < 100)
                {
                    transform.position = new Vector3(transform.position.x - 0.05f, transform.position.y);

                }
                else if (moveToPosition >= 130)
                {
                    GetComponent<SpriteRenderer>().color = Color.white;
                    moveIn = false;
                }
            }

            //Make Dark Green during delays

            if (moveIn == false)
            {

                if (SpinnerControl.spinning == false)
                {
                    GetComponent<SpriteRenderer>().color = Color.gray;


                }
                else if (SpinnerControl.spinning == true)
                {
                    GetComponent<SpriteRenderer>().color = Color.white;
                }

            }
        }






        if (Input.GetKeyDown(KeyCode.F))
        {
            freakOut = true;

        }

        if (freakOut == true)
        {
            RotateClockwise();
        }

        //If Enemies Dead or Players die
        if (inBattle == false)
        {
            
            moveToPosition = 0;
            moveIn = true;


            if (BattleTime.victoryAnimation == true && BattleTime.timer < 200)
            {
                transform.position = new Vector3(transform.position.x + 0.02f, transform.position.y);
            }
            if (BattleTime.victoryAnimation == true && BattleTime.timer == 200)
            {
                transform.position = new Vector3(23.97f, -25.88f, 0);
            }

        }



    }




    

    void RotateClockwise()
    {
        transform.Rotate(0, 0, 700 * -Time.deltaTime);
    }

}