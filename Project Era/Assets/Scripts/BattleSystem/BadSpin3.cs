using UnityEngine;
using System.Collections;

public class BadSpin3 : SpinnerControl {

   public static float moveToPosition2 = 0;
    public static float moveToPosition3 = 0;
    bool allSetUp = false;
    bool letItMove = false;

    // Use this for initialization
    void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {

        if (landOnX == true)
        {

            if (spinCount == 3)
            {
                transform.position = Camera.main.ViewportToWorldPoint(new Vector3(1.2f, 0.18f, 1));
                
                allSetUp = true;
            }
        }


        if (allSetUp == true)
        {
            moveToPosition2++;

            if (moveToPosition2 < 44)
            {
                transform.position = new Vector3(transform.position.x - 0.1f, transform.position.y);

            }

        }

        if (nextTurn > 3 && letItMove == false && allSetUp == true)
        {
            allSetUp = false;
            letItMove = true;
        }

        if (letItMove == true) { 
            moveToPosition3++;
            if (moveToPosition3 < 120)
            {
                transform.position = new Vector3(transform.position.x + 0.02f, transform.position.y);
            }
            if (moveToPosition3 > 120)
            {
                letItMove = false;
            }

        }

        //If Enemies Dead or Players die
        if (SpinnerControl.inBattle == false)
        {

            moveToPosition2 = 0;
            moveToPosition3 = 0;
            allSetUp = false;
            letItMove = false;
            

            if (BattleTime.victoryAnimation == true && BattleTime.timer < 200)
            {
                transform.position = new Vector3(transform.position.x + 0.02f, transform.position.y);
            }
            if (BattleTime.victoryAnimation == true && BattleTime.timer == 200)
            {
                transform.position = new Vector3(28.74f, -20.98f, 0);
            }

        }
    }
}
