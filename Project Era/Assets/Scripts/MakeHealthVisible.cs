using UnityEngine;
using System.Collections;


public class MakeHealthVisible : MonoBehaviour {

    bool inBattle = false;
    long moveToPosition = 0;

	// Use this for initialization
	void Start () {
        gameObject.GetComponent<CanvasGroup>().alpha = 0f;

    }
	
	// Update is called once per frame
	void Update () {

	if (Input.GetKeyDown(KeyCode.B))
        {
            inBattle = true;
        }

    if (inBattle == true)
        {
            moveToPosition++;

            if (moveToPosition > 100)
            {
                gameObject.GetComponent<CanvasGroup>().alpha = 1f;
            }

        }
        
	}
}
