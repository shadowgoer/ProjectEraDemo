using UnityEngine;
using System.Collections;

public class BattleAnimations : MonoBehaviour {

    public Animator anim;
    bool battleStart = false;
    int timer = 0;

	// Use this for initialization
	void Start () {

         anim = GetComponent<Animator>();
       

}

    // Update is called once per frame
    void Update() {

        if (Input.GetKeyDown(KeyCode.B))
        {
            battleStart = true;
        }

        if (battleStart == true) {
            anim.SetBool("activateBattle", true);
            timer++;

            if (timer >= 130)
            {
                anim.SetBool("activateBattle", true);
                anim.SetBool("inBattle", true);
            }

        }
    }

	}

