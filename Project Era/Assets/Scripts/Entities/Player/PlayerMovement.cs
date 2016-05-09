using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class PlayerMovement : MonoBehaviour
{




    public SpriteRenderer spriteParent;

   

    public static float speed;
    public static int direction;

    public static Queue<Vector3> leaderMovements = new Queue<Vector3>();
    public static Vector3 leaderLastPosition;

    void Start()
    {

        direction = 1;
        
        

    }


    void Update()
    {

        if (Input.GetKey(KeyCode.LeftShift))
        {
            speed = 250;
        }
        else if (!Input.GetKey(KeyCode.LeftShift))
        {
            speed = 100;
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



        //FOLLOWING SCRIPT

        //If leader doesn't move, do not add to trail
        if (leaderLastPosition != (Vector3)this.transform.position)
        {
            leaderMovements.Enqueue(this.transform.position);
        }

        if (leaderMovements.Count > 50)
        {
            leaderMovements.Dequeue();
        }

        //When leader trail gets sizable, follow them
       // if (leaderMovements.Count > 20)
        //{
       //     Player2Movement.followLeader = true;
       // }
       // else {
       //     Player2Movement.followLeader = false;
       // }


        //Update leaders last position
        leaderLastPosition = this.transform.position;





    }


    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.name == "Screen1>Screen2")
        {
            Camera.main.orthographicSize = 6.7f;
            Camera.main.transform.position = new Vector3(10.1f, -11.5f, -50);
            this.gameObject.transform.position = new Vector3(transform.position.x, -17.80f, transform.position.z);
        }

        else if (other.gameObject.name == "Screen2>Screen1")
        {
            Camera.main.transform.position = new Vector3(10, -24.4f, -50);
            Camera.main.orthographicSize = 5f;
            this.gameObject.transform.position = new Vector3(transform.position.x, -19.07f, transform.position.z);

        }
    }



}