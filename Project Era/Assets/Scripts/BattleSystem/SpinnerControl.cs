using UnityEngine;
using System.Collections;

public class SpinnerControl : MonoBehaviour {

    bool activateBattle = false;
    public static bool inBattle = false;
    public static bool canStopWheel = false;
    public static bool stopOnJoey = false;
    public static bool stopOnPeter = false;
    public static bool stopOnTia = false;
    public static bool stopOnRico = false;

    bool joeyHasX = false;
    bool peterHasX = false;
    bool tiaHasX = false;
    bool ricoHasX = false;

    public static bool joeyTurn = false;
    public static bool peterTurn = false;
    public static bool tiaTurn = false;
    public static bool ricoTurn = false;

    public static bool landOnX = false;

    public static int spinCount = 0;
    public static bool enemiesTurnDone = false;

   public static bool spinning = false;
    bool mlaa = false;
    bool spinTime = true;

    
    bool freakOut = false;

    float moveToPosition = 0;
    float randomNumber;
    float timer = 0;
     
    double zPos;

    public string[] turn = new string[5];
   public static int nextTurn = 1;

   
    System.Random r = new System.Random();

    public AudioClip goodSpin;
    public AudioClip badSpin;

    // Use this for initialization
    void Start () {

        
    }

    // Update is called once per frame
    void Update()
    {

        //Have Battle Screen Come Up

        if (BattleTime.engageEnemy == true)
        {
            activateBattle = true;
            spinning = true;
        }

        if (activateBattle == true)
        {
            
            transform.position = Camera.main.ViewportToWorldPoint(new Vector3(1.2f, 0.825f, 1));
            inBattle = true;
            activateBattle = false;
        }


        if (inBattle == true)
        {
            //So that they only register once
            if (stopOnJoey == true)
            {
                stopOnJoey = false;
            }
            if (stopOnPeter == true)
            {
                stopOnPeter = false;
            }
            if (stopOnTia == true)
            {
                stopOnTia = false;
            }
            if (stopOnRico == true)
            {
                stopOnRico = false;
            }
            if (landOnX == true)
            {
                landOnX = false;
            }


            //Check if people are dead
            if (JoeyStats.joeyDead == true)
            {
                joeyHasX = true;

            }
            if (PeterStats.peterDead == true)
            {
                peterHasX = true;

            }
            if (TiaStats.tiaDead == true)
            {
                tiaHasX = true;

            }
            if (RicoStats.ricoDead == true)
            {
                ricoHasX = true;

            }

            if (JoeyStats.joeyDead == true && PeterStats.peterDead == true && TiaStats.tiaDead == true && RicoStats.ricoDead == true)
            {
                Application.LoadLevel(2);
            }


            if (spinTime == true)
            {
                nextTurn = 1;

                if (spinning == true)
                {
                    RotateCounterClockwise();
                }


                moveToPosition++;
                if (moveToPosition < 100)
                {
                    transform.position = new Vector3(transform.position.x - 0.05f, transform.position.y);

                }

                else if (moveToPosition >= 130)
                {
                    canStopWheel = true;

                }



                // Start of a new Turn
                if (spinCount < 4)
                {





                    //Wheel Stopping
                    if (canStopWheel == true)
                    {


                        if (spinning == true && Input.GetKeyDown(KeyCode.A))
                        {
                            canStopWheel = false;
                            spinning = false;
                            randomNumber = (float)rnd(1.0, 2.0);
                            spinCount++;

                            zPos = transform.rotation.eulerAngles.z;



                            if (zPos >= 147 && zPos <= 214)
                            {
                                if (joeyHasX == false)
                                {
                                    stopOnJoey = true;
                                    joeyHasX = true;
                                }
                                else
                                {
                                    landOnX = true;
                                }

                            }
                            else if (zPos > 133 && zPos <= 147)
                            {
                                transform.rotation = Quaternion.Euler(0, 0, 147);
                                if (joeyHasX == false)
                                {
                                    stopOnJoey = true;
                                    joeyHasX = true;
                                }
                                else
                                {
                                    landOnX = true;
                                }

                            }
                            else if (zPos > 214 && zPos <= 224)
                            {
                                transform.rotation = Quaternion.Euler(0, 0, 214);
                                if (joeyHasX == false)
                                {
                                    stopOnJoey = true;
                                    joeyHasX = true;
                                }
                                else
                                {
                                    landOnX = true;
                                }

                            }

                            else if (zPos > 56 && zPos <= 119)
                            {
                                if (peterHasX == false)
                                {
                                    stopOnPeter = true;
                                    peterHasX = true;
                                }
                                else
                                {
                                    landOnX = true;
                                }

                            }
                            else if (zPos > 119 && zPos <= 133)
                            {
                                transform.rotation = Quaternion.Euler(0, 0, 119);
                                if (peterHasX == false)
                                {
                                    stopOnPeter = true;
                                    peterHasX = true;
                                }
                                else
                                {
                                    landOnX = true;
                                }

                            }
                            else if (zPos > 43 && zPos <= 56)
                            {
                                transform.rotation = Quaternion.Euler(0, 0, 56);
                                if (peterHasX == false)
                                {
                                    stopOnPeter = true;
                                    peterHasX = true;
                                }
                                else
                                {
                                    landOnX = true;
                                }

                            }

                            else if (zPos > 328 || zPos <= 36)
                            {
                                if (tiaHasX == false)
                                {
                                    stopOnTia = true;
                                    tiaHasX = true;
                                }
                                else
                                {
                                    landOnX = true;
                                }

                            }
                            else if (zPos > 36 && zPos <= 43)
                            {
                                transform.rotation = Quaternion.Euler(0, 0, 36);
                                if (tiaHasX == false)
                                {
                                    stopOnTia = true;
                                    tiaHasX = true;
                                }
                                else
                                {
                                    landOnX = true;
                                }

                            }
                            else if (zPos > 315 && zPos <= 328)
                            {
                                transform.rotation = Quaternion.Euler(0, 0, 328);
                                if (tiaHasX == false)
                                {
                                    stopOnTia = true;
                                    tiaHasX = true;
                                }
                                else
                                {
                                    landOnX = true;
                                }

                            }

                            else if (zPos > 233 && zPos <= 300)
                            {
                                if (ricoHasX == false)
                                {
                                    stopOnRico = true;
                                    ricoHasX = true;
                                }
                                else
                                {
                                    landOnX = true;
                                }

                            }
                            else if (zPos > 224 && zPos <= 233)
                            {
                                transform.rotation = Quaternion.Euler(0, 0, 233);
                                if (ricoHasX == false)
                                {
                                    stopOnRico = true;
                                    ricoHasX = true;
                                }
                                else
                                {
                                    landOnX = true;
                                }

                            }
                            else if (zPos > 300 && zPos <= 315)
                            {
                                transform.rotation = Quaternion.Euler(0, 0, 300);
                                if (ricoHasX == false)
                                {
                                    stopOnRico = true;
                                    ricoHasX = true;
                                }
                                else
                                {
                                    landOnX = true;
                                }

                            }
                        }


                    }

                    //Delay for some time

                    if (spinning == false && canStopWheel == false)
                    {

                        mlaa = true;
                        StartCoroutine(DelayWheel());

                    }


                }
                if (mlaa == true)
                {
                    timer++;
                    if (timer > 50)
                    {
                        RotateCounterClockwise();
                    }

                }





                if (stopOnJoey == true)
                {
                    SoundManager.instance.PlaySoundEffect(goodSpin);
                    turn[spinCount] = "Joey";

                }
                else if (stopOnPeter == true)
                {
                    SoundManager.instance.PlaySoundEffect(goodSpin);
                    turn[spinCount] = "Peter";
                }
                else if (stopOnTia == true)
                {
                    SoundManager.instance.PlaySoundEffect(goodSpin);
                    turn[spinCount] = "Tia";
                }
                else if (stopOnRico == true)
                {
                    SoundManager.instance.PlaySoundEffect(goodSpin);
                    turn[spinCount] = "Rico";
                }
                else if (landOnX)
                {
                    SoundManager.instance.PlaySoundEffect(badSpin);
                    turn[spinCount] = "Null";
                }
            }

        }



        // New Turn. Reset Things.

        if (spinCount == 4)
        {
            spinTime = false;

            // Go through each player's turn
            if (nextTurn < 5)
            {
                if (turn[nextTurn] == "Joey")
                {
                    joeyTurn = true;
                }
                else if (turn[nextTurn] == "Tia")
                {
                    tiaTurn = true;
                }
                else if (turn[nextTurn] == "Peter")
                {
                    peterTurn = true;
                }
                else if (turn[nextTurn] == "Rico")
                {
                    ricoTurn = true;
                }
                else if (turn[nextTurn] == "Null")
                {
                    nextTurn++;
                }

            }

           else if (nextTurn == 5) {

                //Enemies Turn
                



                //New Turn Start
                if (enemiesTurnDone == true && Input.GetKeyDown(KeyCode.A))
                {


                    spinCount = 0;
                    Debug.Log("New Turn");
                    joeyHasX = false;
                    peterHasX = false;
                    tiaHasX = false;
                    ricoHasX = false;
                    spinTime = true;
                    


                    //Reset Values
                    BattleTime.enemyNum = 0;
                   

                    BattleBox1.moveToPosition2 = 0;
                    BattleBox1.moveToPosition3 = 0;
                    BattleBox1.activateBattle2 = true;
                    BattleBox2.moveToPosition2 = 0;
                    BattleBox2.moveToPosition3 = 0;
                    BattleBox2.activateBattle2 = true;
                    BattleBox3.moveToPosition2 = 0;
                    BattleBox3.moveToPosition3 = 0;
                    BattleBox3.activateBattle2 = true;
                    BattleBox4.moveToPosition2 = 0;
                    BattleBox4.moveToPosition3 = 0;
                    BattleBox4.activateBattle2 = true;

                    BattleBoxCog1.moveToPosition2 = 0;
                    BattleBoxCog1.moveToPosition3 = 0;
                    BattleBoxCog1.activateBattle2 = true;
                    BattleBoxCog2.moveToPosition2 = 0;
                    BattleBoxCog2.moveToPosition3 = 0;
                    BattleBoxCog2.activateBattle2 = true;
                    BattleBoxCog3.moveToPosition2 = 0;
                    BattleBoxCog3.moveToPosition3 = 0;
                    BattleBoxCog3.activateBattle2 = true;
                    BattleBoxCog4.moveToPosition2 = 0;
                    BattleBoxCog4.moveToPosition3 = 0;
                    BattleBoxCog4.activateBattle2 = true;

                    BattleBoxJoeyName.moveToPosition2 = 0;
                    BattleBoxJoeyName.moveToPosition3 = 0;
                    BattleBoxPeterName.moveToPosition2 = 0;
                    BattleBoxPeterName.moveToPosition3 = 0;
                    BattleBoxRicoName.moveToPosition2 = 0;
                    BattleBoxRicoName.moveToPosition3 = 0;
                    BattleBoxTiaName.moveToPosition2 = 0;
                    BattleBoxTiaName.moveToPosition3 = 0;

                    BadSpin2.moveToPosition2 = 0;
                    BadSpin2.moveToPosition3 = 0;
                    BadSpin3.moveToPosition2 = 0;
                    BadSpin3.moveToPosition3 = 0;
                    BadSpin4.moveToPosition2 = 0;
                    BadSpin4.moveToPosition3 = 0;


                }

        }

        }

        //If Enemies Dead or Players die
        if (inBattle == false)
        {
            BattleTime.enemyNum = 0;
            canStopWheel = false;
            joeyTurn = false;
            tiaTurn = false;
            peterTurn = false;
            ricoTurn = false;
            spinCount = 0;
            enemiesTurnDone = false;
            spinning = false;
            mlaa = false;
            spinTime = true;
            moveToPosition = 0;
            timer = 0;
            nextTurn = 1;

            if (BattleTime.victoryAnimation == true && BattleTime.timer < 200) {
                transform.position = new Vector3(transform.position.x + 0.02f, transform.position.y);
            }
            if (BattleTime.victoryAnimation == true && BattleTime.timer == 200)
            {
                transform.position = new Vector3(23.97f, -25.88f, 0);
            }

        }


    }

    void LateUpdate()
    {


        if (enemiesTurnDone == true && Input.GetKeyDown(KeyCode.A))
        {
            enemiesTurnDone = false;
        }
    }





    IEnumerator DelayWheel()
    {
        
        yield return new WaitForSeconds(randomNumber);
        mlaa = false;
        timer = 0;
        spinning = true;
        canStopWheel = true;
    }

    double rnd(double a, double b)
    {
        return a + r.NextDouble() * (b - a);
    }

    void RotateCounterClockwise()
    {
        transform.Rotate(0, 0, 800 * Time.deltaTime);

    }
    void FreakTheFrickOut()
    {
        transform.Rotate(Vector3.forward * -90);

    }
    void RotateClockwise()
    {
        transform.Rotate(0, 0, 400 * -Time.deltaTime);
    }



}
