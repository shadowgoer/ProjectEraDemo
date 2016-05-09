using UnityEngine;
using System.Collections;

public class RicoHealthText : MonoBehaviour
{

    bool activateBattle2 = false;
    bool inBattle = false;
    float moveToPosition = 0;



    // Use this for initialization
    void Start()
    {

        this.gameObject.GetComponent<MeshRenderer>().sortingLayerName = "Foreground";
        this.gameObject.GetComponent<MeshRenderer>().sortingOrder = 3;

    }

    // Update is called once per frame
    void Update()
    {

        if (BattleTime.engageEnemy == true)
        {
            activateBattle2 = true;

        }



        if (activateBattle2 == true)
        {
            transform.position = Camera.main.ViewportToWorldPoint(new Vector3(0.0027f, -0.06f, 1));
            inBattle = true;
            activateBattle2 = false;


        }


        if (inBattle == true)
        {
            moveToPosition++;
            if (moveToPosition < 14)
            {
                transform.position = new Vector3(transform.position.x, transform.position.y + 0.19f);

            }

           

        }

        //Change Health Value
        this.gameObject.GetComponent<TextMesh>().text = ("HP: " + RicoStats.health + "/" + RicoStats.maxHealth + "\n" + "IP: " + RicoStats.IP + "/" + RicoStats.maxIP);

       

    }

    void LateUpdate()
    {
        //If Enemies Dead or Players die
        if (SpinnerControl.inBattle == false)
        {

            activateBattle2 = false;
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

}
