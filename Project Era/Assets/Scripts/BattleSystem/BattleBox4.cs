using UnityEngine;
using System.Collections;

public class BattleBox4 : SpinnerControl {

    public static bool activateBattle2 = false;
    bool inBattle2 = false;
    public static float moveToPosition2 = 0;
    public static float moveToPosition3 = 0;

    // Use this for initialization
    void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {

        

        if (BattleTime.engageEnemy == true)
        {
            activateBattle2 = true;
        }



        if (activateBattle2 == true)
        {
            transform.position = Camera.main.ViewportToWorldPoint(new Vector3(1.2f, 0.06f, 1));
            inBattle2 = true;
            activateBattle2 = false;


        }

        if (spinCount == 4 && nextTurn == 1)
        {

            if (inBattle2 == true)
            {
                moveToPosition2++;
                if (moveToPosition2 < 44)
                {
                    transform.position = new Vector3(transform.position.x - 0.1f, transform.position.y);
                }
            }
        }

       

        if (nextTurn > 4)
        {
            moveToPosition3++;
            if (moveToPosition3 < 120)
            {
                transform.position = new Vector3(transform.position.x + 0.02f, transform.position.y);
            }
            
        }

        //If Enemies Dead or Players die
        if (SpinnerControl.inBattle == false)
        {
            activateBattle2 = false;
            inBattle2 = false;
            moveToPosition2 = 0;
            moveToPosition3 = 0;

            if (BattleTime.victoryAnimation == true && BattleTime.timer < 200)
            {
                transform.position = new Vector3(transform.position.x + 0.02f, transform.position.y);
            }
            if (BattleTime.victoryAnimation == true && BattleTime.timer == 200)
            {
                transform.position = new Vector3(31.83f, -20.98f, 0);
            }

        }

    }
}

