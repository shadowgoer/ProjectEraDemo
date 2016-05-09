using UnityEngine;
using System.Collections;

public class CameraMovement : MonoBehaviour {


    bool stopMovement = false;
	Transform target;

	void Start () {
	
		//target = GameObject.Find ("Joey").transform;
        //transform.position = target.position + new Vector3(0, 0, -10);
    }
	

	void Update () {

        if(BattleTime.engageEnemy == true)
        {
       //     stopMovement = true;
       }


        if (stopMovement == false)
        {
           // transform.position = target.position + new Vector3(0, 0, -10);
        }
	
	}
}
