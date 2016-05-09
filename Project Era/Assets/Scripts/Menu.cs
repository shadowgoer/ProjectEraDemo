using UnityEngine;
using System.Collections;

public class Menu : MonoBehaviour {

	void OnGUI() {
		if (GUI.Button (new Rect(Screen.width/40f,Screen.height/3, Screen.width/2.75f,Screen.height/10),"Start Game")) {
			Application.LoadLevel(3);
		}
		if (GUI.Button (new Rect(Screen.width/40f,Screen.height/2, Screen.width/2.75f,Screen.height/10),"I'm too scared to start the game!")) {
			Application.Quit();
		}

		if (GUI.Button (new Rect(Screen.width/40f,Screen.height/1.1f, Screen.width/2.75f,Screen.height/10),"No Weapon Challenge")) {
			Application.LoadLevel(6);
		}

	}


}
