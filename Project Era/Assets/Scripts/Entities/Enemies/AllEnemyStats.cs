using UnityEngine;
using System.Collections;

public class AllEnemyStats : MonoBehaviour {

    public int health;
    public int defense;
    public int attack;

	// Use this for initialization
	void Start () {
	
        //Set Stats for every enemy

        //Kite Fighter





        //Unnatural Log
        if (this.gameObject.tag == "Enemies")
        {
            health = 250;
            defense = 100;
            attack = 60;
            
            
        }

        if (this.gameObject.tag == "Unnatural Log")
        {
            health = 200;
            defense = 1;
            attack = 60;
        }


        //Boss idiot
        if (this.gameObject.tag == "Boss Dude")
        {
            health = 100;
            defense = 1;
            attack = 40;
        }

    }
	
	// Update is called once per frame
	void Update () {
        
        

	}
}
