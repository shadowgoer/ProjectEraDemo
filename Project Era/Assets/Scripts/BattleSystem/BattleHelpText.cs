using UnityEngine;
using System.Collections;

public class BattleHelpText : MonoBehaviour {

	// Use this for initialization
	void Start () {

        this.gameObject.GetComponent<MeshRenderer>().sortingLayerName = "Character";
        this.gameObject.GetComponent<MeshRenderer>().sortingOrder = -1;

    }
	
	// Update is called once per frame
	void Update () {

        if (SpinnerControl.joeyTurn == true)
        {
            if(BattleIconAttackSelectJoey.buttonSelected == false)
            {
                if (BattleIconAttackSelectJoey.iconSelect == 4)
                {
                    this.gameObject.GetComponent<MeshRenderer>().sortingOrder = 3;
                    this.gameObject.GetComponent<TextMesh>().text = "Attack Enemy";
                }

                else if (BattleIconAttackSelectJoey.iconSelect == 3)
                {
                    this.gameObject.GetComponent<MeshRenderer>().sortingOrder = 3;
                    this.gameObject.GetComponent<TextMesh>().text = "Restores 60-70 HP to Ally";
                    
                }
                else if(BattleIconAttackSelectJoey.iconSelect == 2)
                {
                    this.gameObject.GetComponent<MeshRenderer>().sortingOrder = 3;
                    this.gameObject.GetComponent<TextMesh>().text = "Not Implemented";
                }
                else if (BattleIconAttackSelectJoey.iconSelect == 1)
                {
                    this.gameObject.GetComponent<MeshRenderer>().sortingOrder = 3;
                    this.gameObject.GetComponent<TextMesh>().text = "Not Implemented";
                }

            }

            else
            {
                this.gameObject.GetComponent<MeshRenderer>().sortingOrder = -1;
            }

        }



       else if (SpinnerControl.tiaTurn == true)
        {
            if (BattleIconAttackSelectTia.buttonSelected == false)
            {
                if (BattleIconAttackSelectTia.iconSelect == 4)
                {
                    this.gameObject.GetComponent<MeshRenderer>().sortingOrder = 3;
                    this.gameObject.GetComponent<TextMesh>().text = "Attack Enemy";
                }

                else if (BattleIconAttackSelectTia.iconSelect == 3)
                {
                    this.gameObject.GetComponent<MeshRenderer>().sortingOrder = 3;
                    this.gameObject.GetComponent<TextMesh>().text = "Lower Offense of Enemy";

                }
                else if (BattleIconAttackSelectTia.iconSelect == 2)
                {
                    this.gameObject.GetComponent<MeshRenderer>().sortingOrder = 3;
                    this.gameObject.GetComponent<TextMesh>().text = "Not Implemented";
                }
                else if (BattleIconAttackSelectTia.iconSelect == 1)
                {
                    this.gameObject.GetComponent<MeshRenderer>().sortingOrder = 3;
                    this.gameObject.GetComponent<TextMesh>().text = "Not Implemented";
                }

            }

            else
            {
                this.gameObject.GetComponent<MeshRenderer>().sortingOrder = -1;
            }





        }

        else if (SpinnerControl.peterTurn == true)
        {
            if (BattleIconAttackSelectPeter.buttonSelected == false)
            {
                if (BattleIconAttackSelectPeter.iconSelect == 4)
                {
                    this.gameObject.GetComponent<MeshRenderer>().sortingOrder = 3;
                    this.gameObject.GetComponent<TextMesh>().text = "Attack Enemy";
                }

                else if (BattleIconAttackSelectPeter.iconSelect == 3)
                {
                    this.gameObject.GetComponent<MeshRenderer>().sortingOrder = 3;
                    this.gameObject.GetComponent<TextMesh>().text = "Power of this attack varies";

                }
                else if (BattleIconAttackSelectPeter.iconSelect == 2)
                {
                    this.gameObject.GetComponent<MeshRenderer>().sortingOrder = 3;
                    this.gameObject.GetComponent<TextMesh>().text = "Not Implemented";
                }
                else if (BattleIconAttackSelectPeter.iconSelect == 1)
                {
                    this.gameObject.GetComponent<MeshRenderer>().sortingOrder = 3;
                    this.gameObject.GetComponent<TextMesh>().text = "Not Implemented";
                }

            }

            else
            {
                this.gameObject.GetComponent<MeshRenderer>().sortingOrder = -1;
            }


        }
        else if (SpinnerControl.ricoTurn == true)
        {
            if (BattleIconAttackSelectRico.buttonSelected == false)
            {
                if (BattleIconAttackSelectRico.iconSelect == 4)
                {
                    this.gameObject.GetComponent<MeshRenderer>().sortingOrder = 3;
                    this.gameObject.GetComponent<TextMesh>().text = "Attack Enemy";
                }

                else if (BattleIconAttackSelectRico.iconSelect == 3)
                {
                    this.gameObject.GetComponent<MeshRenderer>().sortingOrder = 3;
                    this.gameObject.GetComponent<TextMesh>().text = "Restores some IP to an ally";

                }
                else if (BattleIconAttackSelectRico.iconSelect == 2)
                {
                    this.gameObject.GetComponent<MeshRenderer>().sortingOrder = 3;
                    this.gameObject.GetComponent<TextMesh>().text = "Not Implemented";
                }
                else if (BattleIconAttackSelectRico.iconSelect == 1)
                {
                    this.gameObject.GetComponent<MeshRenderer>().sortingOrder = 3;
                    this.gameObject.GetComponent<TextMesh>().text = "Not Implemented";
                }

            }

            else
            {
                this.gameObject.GetComponent<MeshRenderer>().sortingOrder = -1;
            }


        }

        else
        {
            this.gameObject.GetComponent<MeshRenderer>().sortingOrder = -1;
        }


    }
}
