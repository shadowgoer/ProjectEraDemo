using UnityEngine;
using System.Collections;

public class BattleIconSAISelectTia : MonoBehaviour {
    
    bool buttonSelected = false;
    bool saiSelected = false;

    public static int selectedEnemy = 0;
    int previousEnemy = 0;

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

        if (SpinnerControl.tiaTurn == true)
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

              
                if (BattleIconAttackSelectTia.iconSelect == 3)
                {
                    GetComponent<SpriteRenderer>().color = Color.yellow;
                }
                else
                {
                    GetComponent<SpriteRenderer>().color = Color.white;
                }
            }


            //Picking an enemy to debuff
            if (buttonSelected == true && saiSelected == true)
            {
                if (Input.GetKeyDown(KeyCode.RightArrow) || Input.GetKeyDown(KeyCode.L))
                {
                    selectedEnemy++;
                    previousEnemy = selectedEnemy - 1;
                    BattleTime.enemies[previousEnemy].GetComponent<SpriteRenderer>().color = Color.white;
                }
                else if (Input.GetKeyDown(KeyCode.LeftArrow) || Input.GetKeyDown(KeyCode.J))
                {
                    selectedEnemy--;
                    previousEnemy = selectedEnemy + 1;
                    BattleTime.enemies[previousEnemy].GetComponent<SpriteRenderer>().color = Color.white;
                }

                if (selectedEnemy > BattleTime.enemies.Count - 1)
                {
                    selectedEnemy = 0;
                    previousEnemy = BattleTime.enemies.Count - 1;
                    BattleTime.enemies[previousEnemy].GetComponent<SpriteRenderer>().color = Color.white;
                }
                else if (selectedEnemy < 0)
                {
                    selectedEnemy = BattleTime.enemies.Count - 1;
                    previousEnemy = 0;
                    BattleTime.enemies[previousEnemy].GetComponent<SpriteRenderer>().color = Color.white;
                }

                BattleTime.enemies[selectedEnemy].GetComponent<SpriteRenderer>().color = Color.blue;


                if (Input.GetKeyDown(KeyCode.A))
                {
                    BattleTime.enemies[selectedEnemy].GetComponent<SpriteRenderer>().color = Color.white;
                    GetComponent<SpriteRenderer>().color = Color.white;
                    buttonSelected = false;
                    BattleIconAttackSelectTia.buttonSelected = false;
                    saiSelected = false;
                    BattleIconAttackSelectTia.iconSelect = 4;
                    BattleIconAttackSelectTia.hideButtons = true;


                    TiaStats.IP = TiaStats.IP - 5;
                    TiaStats.weaknessFlash = true;
                }

            }



            //Selecting Button
            if (BattleIconAttackSelectTia.iconSelect == 3 && Input.GetKeyDown(KeyCode.A) && BattleIconAttackSelectTia.hideButtons == false)
            {
                GetComponent<SpriteRenderer>().color = Color.red;
                buttonSelected = true;
                saiSelected = true;
            }
            

            //GoingBackwards
            if (buttonSelected == true)
            {

                if (Input.GetKeyDown(KeyCode.S))
                {
                    BattleTime.enemies[selectedEnemy].GetComponent<SpriteRenderer>().color = Color.white;
                    
                    buttonSelected = false;
                    saiSelected = false;
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
