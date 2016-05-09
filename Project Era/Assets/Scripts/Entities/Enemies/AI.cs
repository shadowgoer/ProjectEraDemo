using UnityEngine;
using System.Collections;

public class AI : MonoBehaviour {

	private Vector3 Player;
	private Vector2 PlayerDirection;
	private float Xdif;
	private float Ydif;

	public float distance;
	private int wall;

	private bool stun;
	private float stuntime;



	void Start () {
		stuntime = 0;
		stun = false;

		wall = 1 << 9;
	
	}
	

	void Update () {

		

		distance = Vector2.Distance (Player, transform.position);
		Player = GameObject.Find ("Player").transform.position;


		if (stuntime > 0) {
			stuntime -= Time.deltaTime;

		} else {
			stun = false;
		}


		if (distance < 6 && !stun) {

		Xdif = Player.x - transform.position.x;
		Ydif = Player.y - transform.position.y;

		PlayerDirection = new Vector2 (Xdif, Ydif);



		if (!Physics2D.Raycast (transform.position, PlayerDirection, 3, wall)) {

			GetComponent<Rigidbody2D>().AddForce (PlayerDirection.normalized * 150);

			}
		}

	}

	void OnCollisionEnter2D (Collision2D Playerhit) {
		if (Playerhit.gameObject.tag == "Player") {
			stun = true;
			stuntime = 0.5f;


		}
	}

		




}
