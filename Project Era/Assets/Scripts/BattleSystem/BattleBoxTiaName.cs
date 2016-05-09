using UnityEngine;
using System.Collections;

public class BattleBoxTiaName : SpinnerControl {

   public static float moveToPosition2 = 0;
    public static float moveToPosition3 = 0;
    int whichOne = 8;
    bool allSetUp = false;
    bool letItMove = false;

    void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {

        if (stopOnTia == true)
        {
            
            if (spinCount == 1)
            {
                transform.position = Camera.main.ViewportToWorldPoint(new Vector3(1.2f, 0.42f, 1));
                whichOne = 1;
            }
            if (spinCount == 2)
            {
                transform.position = Camera.main.ViewportToWorldPoint(new Vector3(1.2f, 0.30f, 1));
                whichOne = 2;
            }
            if (spinCount == 3)
            {
                transform.position = Camera.main.ViewportToWorldPoint(new Vector3(1.2f, 0.18f, 1));
                whichOne = 3;
            }
            if (spinCount == 4)
            {
                transform.position = Camera.main.ViewportToWorldPoint(new Vector3(1.2f, 0.06f, 1));
                whichOne = 4;
            }

            allSetUp = true;
        }
        else if (landOnX)
        {

        }


        if (allSetUp == true)
        {
            moveToPosition2++;

            if (spinCount == 1)
            {
                if (moveToPosition2 < 44)
                {
                    transform.position = new Vector3(transform.position.x - 0.1f, transform.position.y);

                }
            }

            if (spinCount == 2)
            {
                if (moveToPosition2 < 44)
                {
                    transform.position = new Vector3(transform.position.x - 0.1f, transform.position.y);

                }
            }

            if (spinCount == 3)
            {
                if (moveToPosition2 < 44)
                {
                    transform.position = new Vector3(transform.position.x - 0.1f, transform.position.y);

                }
            }

            if (spinCount == 4)
            {
                if (moveToPosition2 < 44)
                {
                    transform.position = new Vector3(transform.position.x - 0.1f, transform.position.y);
                }
            }

        }

        if (nextTurn > whichOne)
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
                whichOne = 8;
            }

        }

        //If Enemies Dead or Players die
        if (SpinnerControl.inBattle == false)
        {

            moveToPosition2 = 0;
            moveToPosition3 = 0;
            allSetUp = false;
            letItMove = false;
            whichOne = 8;

            if (BattleTime.victoryAnimation == true && BattleTime.timer < 200)
            {
                transform.position = new Vector3(transform.position.x + 0.02f, transform.position.y);
            }
            if (BattleTime.victoryAnimation == true && BattleTime.timer == 200)
            {
                transform.position = new Vector3(31.79f, -20.98f, 0);
            }

        }
    }
}
