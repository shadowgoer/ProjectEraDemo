using UnityEngine;
using System.Collections;

public class SpinnerXRico : MonoBehaviour
{

    public GameObject spinner;
    private SpriteRenderer sprite;


    // Use this for initialization
    void Start()
    {
        sprite = GetComponent<SpriteRenderer>();
        sprite.sortingOrder = 1;
        spinner = GameObject.FindGameObjectWithTag("Spinner");
    }

    // Update is called once per frame
    void Update()
    {
        //Stay with spinner
        this.transform.position = spinner.transform.position;
        this.transform.rotation = spinner.transform.rotation;


        if (SpinnerControl.inBattle == true)
        {
            //check if dead
            if (RicoStats.ricoDead == true)
            {
                sprite.sortingOrder = 3;

            }




            if (SpinnerControl.stopOnRico == true)
            {
                sprite.sortingOrder = 3;
            }


            if (SpinnerControl.enemiesTurnDone == true && Input.GetKeyDown(KeyCode.A))
            {
                sprite.sortingOrder = 1;

            }


        }


        //If Enemies Dead or Players die
        if (SpinnerControl.inBattle == false)
        {



            if (BattleTime.victoryAnimation == true && BattleTime.timer < 200)
            {
                transform.position = new Vector3(transform.position.x + 0.02f, transform.position.y);
            }
            if (BattleTime.victoryAnimation == true && BattleTime.timer == 200)
            {
                transform.position = new Vector3(23.97f, -25.88f, 0);
            }

        }

    }

    }



   


    