using UnityEngine;
using System.Collections;

public class BattleIconTacticsSelectRico : MonoBehaviour {
    
    bool buttonSelected = false;

    private SpriteRenderer sprite;

    // Use this for initialization
    void Start () {
        sprite = GetComponent<SpriteRenderer>();
        sprite.sortingOrder = -2;
    }
	
	// Update is called once per frame
	void Update () {
        if (SpinnerControl.ricoTurn == false)
        {
            sprite.sortingOrder = -2;
        }

        if (SpinnerControl.ricoTurn == true)
        {
            if (BattleIconAttackSelectRico.hideButtons == false)
            {
                sprite.sortingOrder = 2;
            }
            else if (BattleIconAttackSelectRico.hideButtons == true)
            {
                sprite.sortingOrder = -2;
            }

            if (buttonSelected == false)
            {

               


                if (BattleIconAttackSelectRico.iconSelect == 1)
                {
                    GetComponent<SpriteRenderer>().color = Color.yellow;
                }
                else
                {

                    GetComponent<SpriteRenderer>().color = Color.white;
                }


            }


            //Selecting Button
            if (BattleIconAttackSelectRico.iconSelect == 1 && Input.GetKeyDown(KeyCode.A) && BattleIconAttackSelectRico.hideButtons == false)
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
