using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class RandomDialogue : MonoBehaviour {

	private bool inRange;
	private bool talk;
	


	

	void Start () {
	
	}
	

	void Update () {

		if (inRange) {
			if(Input.GetKeyDown (KeyCode.A)){
				talk = true;
			}

		
		}

	}

	
	 
	void OnTriggerEnter2D(Collider2D col){

		if (col.gameObject.tag == "Player") {
			inRange = true;
		} 
	}

	public void GenerateDialogue(){



	}

	void OnTriggerExit2D(Collider2D col) {
			talk = false;
			inRange = false;
		}


	}



[System.Serializable]
public class Dialogue {

	public string dialogue;
}