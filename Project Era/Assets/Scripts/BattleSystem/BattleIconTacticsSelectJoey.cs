using UnityEngine;
using System.Collections;

public class BattleIconTacticsSelectJoey : MonoBehaviour {
    
    bool buttonSelected = false;

    private SpriteRenderer sprite;
    // Use this for initialization
    void Start () {
        sprite = GetComponent<SpriteRenderer>();
        sprite.sortingOrder = -2;
    }
	
	// Update is called once per frame
	void Update () {
        if (SpinnerControl.joeyTurn == false)
        {
            sprite.sortingOrder = -2;
        }

        if (SpinnerControl.joeyTurn == true)
        {
            if (BattleIconAttackSelectJoey.hideButtons == false)
            {
                sprite.sortingOrder = 2;
            }
            else if (BattleIconAttackSelectJoey.hideButtons == true)
            {
                sprite.sortingOrder = -2;
            }

            if (buttonSelected == false)
            {

              

                if (BattleIconAttackSelectJoey.iconSelect == 1)
                {
                    GetComponent<SpriteRenderer>().color = Color.yellow;
                }
                else
                {

                    GetComponent<SpriteRenderer>().color = Color.white;
                }


            }


            //Selecting Button
            if (BattleIconAttackSelectJoey.iconSelect == 1 && Input.GetKeyDown(KeyCode.A) && BattleIconAttackSelectJoey.hideButtons == false)
            {
                GetComponent<SpriteRenderer>().color = Color.red;
                buttonSelected = true;
            }
           

            //GoingBackwards
            if (buttonSelected == true)
            {

                if (Input.GetKeyDown(KeyCode.S))
                {
                    
                    buttonSelected = false;
                }

            }
        }

        //if enemies are dead, reset values
        if (BattleTime.victoryAnimation == true)
        {
            sprite.sortingOrder = -2;

            buttonSelected = false;


        }
    }
}
