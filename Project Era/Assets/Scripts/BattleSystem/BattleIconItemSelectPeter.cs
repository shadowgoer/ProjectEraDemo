using UnityEngine;
using System.Collections;

public class BattleIconItemSelectPeter : MonoBehaviour {

    
    bool buttonSelected = false;

    private SpriteRenderer sprite;

    void Start () {

        sprite = GetComponent<SpriteRenderer>();
        sprite.sortingOrder = -2;


    }

    // Update is called once per frame
    void Update () {

        if (SpinnerControl.peterTurn == false)
        {
            sprite.sortingOrder = -2;
        }

        

       else if (SpinnerControl.peterTurn == true)
            {

            if (BattleIconAttackSelectPeter.hideButtons == false)
            {
                sprite.sortingOrder = 2;
            }
            else if (BattleIconAttackSelectPeter.hideButtons == true)
            {
                sprite.sortingOrder = -2;
            }

            if (buttonSelected == false)
            {

              

                if (BattleIconAttackSelectPeter.iconSelect == 2)
                {
                    GetComponent<SpriteRenderer>().color = Color.yellow;
                }
                else
                {
                    GetComponent<SpriteRenderer>().color = Color.white;
                }

            }

            //Selecting Button
            if (BattleIconAttackSelectPeter.iconSelect == 2 && Input.GetKeyDown(KeyCode.A) && BattleIconAttackSelectPeter.hideButtons == false)
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
