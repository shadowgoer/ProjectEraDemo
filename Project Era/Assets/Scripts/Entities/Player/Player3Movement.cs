using UnityEngine;
using System.Collections;
using System.Linq;
using System.Collections.Generic;

public class Player3Movement : MonoBehaviour {

    public SpriteRenderer spriteParent;
    public GameObject target;
    public static int direction;

    public static bool followLeader = false;

    // Use this for initialization
    void Start () {
        direction = 1;
    }
	
	// Update is called once per frame
	void Update () {
	
	}

    void LateUpdate()
    {
        this.transform.position = PlayerMovement.leaderMovements.ElementAtOrDefault(22);

    }

}
