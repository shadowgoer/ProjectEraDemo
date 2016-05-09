using UnityEngine;
using System.Collections;

public class BattleIconAttackSelectPeter : MonoBehaviour {

    public static int iconSelect = 4;
    public static bool buttonSelected = false;
    bool attackSelected = false;
    public static bool hideButtons = false;

    public static int selectedEnemy = 0;
    int previousEnemy;

    private SpriteRenderer sprite;

    public AudioClip iconMoving;

    // Use this for initialization
    void Start () {

        sprite = GetComponent<SpriteRenderer>();
        sprite.sortingOrder = -2;

    }
	
	// Update is called once per frame
	void Update () {

        if (SpinnerControl.peterTurn == false)
        {
            sprite.sortingOrder = -2;
            hideButtons = false;
        }



        else if (SpinnerControl.peterTurn == true)
        {

            if (hideButtons == false)
            {
                sprite.sortingOrder = 2;
            }
            else if (hideButtons == true)
            {
                sprite.sortingOrder = -2;
            }

            if (buttonSelected == false)
            {

                if (Input.GetKeyDown(KeyCode.DownArrow) || Input.GetKeyDown(KeyCode.K))
                {
                    iconSelect--;
                    SoundManager.instance.PlaySoundEffect(iconMoving);
                }
                if (Input.GetKeyDown(KeyCode.UpArrow) || Input.GetKeyDown(KeyCode.I))
                {
                    iconSelect++;
                    SoundManager.instance.PlaySoundEffect(iconMoving);
                }
                if (iconSelect == 5)
                {
                    iconSelect = 1;
                }
                if (iconSelect == 0)
                {
                    iconSelect = 4;
                }

                if (iconSelect == 4)
                {
                    GetComponent<SpriteRenderer>().color = Color.yellow;
                }
                else
                {
                    GetComponent<SpriteRenderer>().color = Color.white;
                }
            }

            //Picking an enemy to attack
            if (buttonSelected == true && attackSelected == true)
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

                if (selectedEnemy > BattleTime.enemies.Count - 1) { 
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

                BattleTime.enemies[selectedEnemy].GetComponent<SpriteRenderer>().color = Color.red;
                

                if (Input.GetKeyDown(KeyCode.A))
                {
                    BattleTime.enemies[selectedEnemy].GetComponent<SpriteRenderer>().color = Color.white;
                    buttonSelected = false;
                    attackSelected = false;
                    iconSelect = 4;
                    hideButtons = true;

                    PeterStats.attackAnimation = true;

                }
            }

            //Selecting Button
            if (iconSelect == 4 && Input.GetKeyDown(KeyCode.A) && hideButtons == false)
            {
                GetComponent<SpriteRenderer>().color = Color.red;
                buttonSelected = true;
                attackSelected = true;
            }
            else if (Input.GetKeyDown(KeyCode.A))
            {
                buttonSelected = true;
            }

            //GoingBackwards
            if (buttonSelected == true)
            {

                if (Input.GetKeyDown(KeyCode.S))
                {
                    
                    BattleTime.enemies[selectedEnemy].GetComponent<SpriteRenderer>().color = Color.white;
                    buttonSelected = false;
                    attackSelected = false;
                }

            }


        }


        //if enemies are dead, reset values
        if (BattleTime.victoryAnimation == true)
        {
            sprite.sortingOrder = -2;
            iconSelect = 4;
            buttonSelected = false;
            hideButtons = false;
            
        }



    }
}
