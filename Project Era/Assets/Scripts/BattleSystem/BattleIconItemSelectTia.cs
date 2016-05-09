using UnityEngine;
using System.Collections;

public class BattleIconItemSelectTia : MonoBehaviour {
    
    bool buttonSelected = false;

    private SpriteRenderer sprite;

    // Use this for initialization
    void Start () {
        sprite = GetComponent<SpriteRenderer>();
        sprite.sortingOrder = -2;
    }
	
	// Update is called once per frame
	void Update () {
        if (SpinnerControl.tiaTurn == false)
        {
            sprite.sortingOrder = -2;
        }



        else if (SpinnerControl.tiaTurn == true)
        {

            if (BattleIconAttackSelectTia.hideButtons == false)
            {
                sprite.sortingOrder = 2;
            }
            else if (BattleIconAttackSelectTia.hideButtons == true)
            {
                sprite.sortingOrder = -2;
            }

            if (buttonSelected == false)
            {

             
                if (BattleIconAttackSelectTia.iconSelect == 2)
                {
                    GetComponent<SpriteRenderer>().color = Color.yellow;
                }
                else
                {
                    GetComponent<SpriteRenderer>().color = Color.white;
                }

            }

            //Selecting Button
            if (BattleIconAttackSelectTia.iconSelect == 2 && Input.GetKeyDown(KeyCode.A))
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
