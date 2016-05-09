using UnityEngine;
using System.Collections;
using System.Linq;
using System.Collections.Generic;


public class Player2Movement : MonoBehaviour
{


    public SpriteRenderer spriteParent;
    public GameObject target;
    public static int direction;

    public static bool followLeader = false;


    


    // Use this for initialization
    void Start () {

        direction = 1;
        
        
    }

    // Update is called once per frame
    void Update()
    {

        
        


        //Keep track of distance from leader
       /* target = GameObject.FindGameObjectWithTag("Player");
        float distance = Vector3.Distance(transform.position, target.transform.position);




       
            playerpos.Enqueue(target.transform.position);

        
        
            newpos = playerpos.Dequeue();
            this.transform.position = newpos;
        
        
        /* 
         {

             if (Input.GetKey(KeyCode.LeftShift))
             {
                 speed = 300;
             }
             else if (!Input.GetKey(KeyCode.LeftShift))
             {
                 speed = 150;
             }



             //Walk and face a direction

             if (Input.GetKey(KeyCode.I) || Input.GetKey(KeyCode.UpArrow))
             {
                 GetComponent<Rigidbody2D>().AddForce(Vector2.up * speed);
                 direction = 0;

             }
             if (Input.GetKey(KeyCode.K) || Input.GetKey(KeyCode.DownArrow))
             {
                 GetComponent<Rigidbody2D>().AddForce(-Vector2.up * speed);
                 direction = 1;

             }
             if (Input.GetKey(KeyCode.J) || Input.GetKey(KeyCode.LeftArrow))
             {
                 GetComponent<Rigidbody2D>().AddForce(-Vector2.right * speed);
                 direction = 2;

             }
             if (Input.GetKey(KeyCode.L) || Input.GetKey(KeyCode.RightArrow))
             {
                 GetComponent<Rigidbody2D>().AddForce(Vector2.right * speed);
                 direction = 3;

             }

             //Face diagonal directions

             if ((Input.GetKey(KeyCode.I) || Input.GetKey(KeyCode.UpArrow)) && (Input.GetKey(KeyCode.L) || Input.GetKey(KeyCode.RightArrow)))
             {
                 direction = 4;
             }
             if ((Input.GetKey(KeyCode.K) || Input.GetKey(KeyCode.DownArrow)) && (Input.GetKey(KeyCode.L) || Input.GetKey(KeyCode.RightArrow)))
             {
                 direction = 5;
             }
             if ((Input.GetKey(KeyCode.I) || Input.GetKey(KeyCode.UpArrow)) && (Input.GetKey(KeyCode.J) || Input.GetKey(KeyCode.LeftArrow)))
             {
                 direction = 6;
             }
             if ((Input.GetKey(KeyCode.K) || Input.GetKey(KeyCode.DownArrow)) && (Input.GetKey(KeyCode.J) || Input.GetKey(KeyCode.LeftArrow)))
             {
                 direction = 7;
             }


         } */
    } 

    void LateUpdate()
    {
        this.transform.position = PlayerMovement.leaderMovements.ElementAtOrDefault(35);

    }

}


