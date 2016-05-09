using UnityEngine;
using System.Collections;

public class SmallCog5 : MonoBehaviour {

    bool activateBattle = false;
    bool inBattle = false;
    float moveToPosition = 0;

    // Use this for initialization
    void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
        if (BattleTime.engageEnemy == true)
        {
            activateBattle = true;

        }



        if (activateBattle == true)
        {
            transform.position = Camera.main.ViewportToWorldPoint(new Vector3(-0.7f, 0.508f, 1));
            inBattle = true;
            activateBattle = false;


        }


        if (inBattle == true)
        {
            moveToPosition++;
            if (moveToPosition < 117)
            {
                transform.position = new Vector3(transform.position.x + 0.1f, transform.position.y);
                
            }
            else if (moveToPosition >= 130)
            {

                 RotateCounterClockwise();
            }
        }

        //If Enemies Dead or Players die
        if (SpinnerControl.inBattle == false)
        {

            activateBattle = false;
            inBattle = false;
            moveToPosition = 0;

            if (BattleTime.victoryAnimation == true && BattleTime.timer < 200)
            {
                transform.position = new Vector3(transform.position.x - 0.02f, transform.position.y);
            }
            if (BattleTime.victoryAnimation == true && BattleTime.timer == 200)
            {
                transform.position = new Vector3(23.55f, -20.98f, 0);
            }

        }

    }
    void RotateCounterClockwise()
    {
        transform.Rotate(0, 0, 75 * Time.deltaTime);
    }
    void RotateClockwise()
    {
        transform.Rotate(0, 0, 75 * -Time.deltaTime);
    }

}
