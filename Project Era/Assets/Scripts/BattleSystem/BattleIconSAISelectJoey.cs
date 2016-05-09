using UnityEngine;
using System.Collections;

public class BattleIconSAISelectJoey : MonoBehaviour {

    
    bool buttonSelected = false;
    bool saiSelected = false;

    public static int selectedPlayer = 0;
    int previousPlayer = 0;
    
  
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


                if (BattleIconAttackSelectJoey.iconSelect == 3)
                {
                    GetComponent<SpriteRenderer>().color = Color.yellow;
                }
                else
                {
                    GetComponent<SpriteRenderer>().color = Color.white;
                }
            }

            //Picking a player to heal. 
            if (buttonSelected == true && saiSelected == true)
            {
                if (Input.GetKeyDown(KeyCode.RightArrow) || Input.GetKeyDown(KeyCode.L))
                {
                    selectedPlayer++;
                    previousPlayer = selectedPlayer - 1;
                    BattleTime.players[previousPlayer].GetComponent<SpriteRenderer>().color = Color.white;
                }
                else if (Input.GetKeyDown(KeyCode.LeftArrow) || Input.GetKeyDown(KeyCode.J))
                {
                    selectedPlayer--;
                    previousPlayer = selectedPlayer + 1;
                    BattleTime.players[previousPlayer].GetComponent<SpriteRenderer>().color = Color.white;
                }

                if (selectedPlayer > BattleTime.players.Count - 1)
                {
                    selectedPlayer = 0;
                    previousPlayer = BattleTime.players.Count - 1;
                    BattleTime.players[previousPlayer].GetComponent<SpriteRenderer>().color = Color.white;
                }
                if (selectedPlayer < 0)
                {
                    selectedPlayer = BattleTime.players.Count - 1;
                    previousPlayer = 0;
                    BattleTime.enemies[previousPlayer].GetComponent<SpriteRenderer>().color = Color.white;
                }

                BattleTime.players[selectedPlayer].GetComponent<SpriteRenderer>().color = Color.green;



                if (Input.GetKeyDown(KeyCode.A))
                {

                    BattleTime.players[selectedPlayer].GetComponent<SpriteRenderer>().color = Color.white;
                    GetComponent<SpriteRenderer>().color = Color.white;
                    buttonSelected = false;
                    saiSelected = false;
                    BattleIconAttackSelectJoey.iconSelect = 4;
                    BattleIconAttackSelectJoey.hideButtons = true;

                    JoeyStats.IP = JoeyStats.IP - 5;
                    JoeyStats.firstAidKit = true;
                }


            }




                //Selecting Button
                if (BattleIconAttackSelectJoey.iconSelect == 3 && Input.GetKeyDown(KeyCode.A) && BattleIconAttackSelectJoey.hideButtons == false)
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
                    
                    BattleTime.players[selectedPlayer].GetComponent<SpriteRenderer>().color = Color.white;
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
