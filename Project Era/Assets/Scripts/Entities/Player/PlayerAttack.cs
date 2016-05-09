using UnityEngine;
using System.Collections;

public class PlayerAttack : PlayerMovement {

	public Rigidbody2D bulletPreFab;
	public float attackspeed = 0.5f;
	float coolDown;



	void Update () {
	
		if (Time.time >= coolDown) {
			if( direction == 0) {
			if (Input.GetKey(KeyCode.Space)) {

				Fireup();
			}
			}
			if (direction == 1) {
				if (Input.GetKey(KeyCode.Space)) {
					
					Firedown();
				}
			}
			if (direction == 2) {
				if (Input.GetKey(KeyCode.Space)) {
					
					Fireleft();
				}
			}
			if (direction == 3) {
				if (Input.GetKey(KeyCode.Space)) {
					
					Fireright();
				}
			}



		}


	}

	void Fireup() {

		Rigidbody2D bPrefab = Instantiate (bulletPreFab, new Vector3 (transform.position.x, transform.position.y + .5f, transform.position.z), Quaternion.identity) as Rigidbody2D;

			bPrefab.GetComponent<Rigidbody2D>().AddForce (Vector2.up * 600);

			coolDown = Time.time + attackspeed;


	}

	void Firedown() {

		Rigidbody2D bPrefab = Instantiate (bulletPreFab, new Vector3 (transform.position.x, transform.position.y - .5f, transform.position.z), Quaternion.identity) as Rigidbody2D;
		
		bPrefab.GetComponent<Rigidbody2D>().AddForce (-Vector2.up * 600);
		
		coolDown = Time.time + attackspeed;

	}
	void Fireleft() {
		
		Rigidbody2D bPrefab = Instantiate (bulletPreFab, new Vector3 (transform.position.x- .5f, transform.position.y, transform.position.z), Quaternion.identity) as Rigidbody2D;
		bPrefab.GetComponent<Rigidbody2D>().AddForce (-Vector2.right * 600);
		
		coolDown = Time.time + attackspeed;
		
	}
	void Fireright() {
		
		Rigidbody2D bPrefab = Instantiate (bulletPreFab, new Vector3 (transform.position.x + .5f, transform.position.y, transform.position.z), Quaternion.identity) as Rigidbody2D;
		
		bPrefab.GetComponent<Rigidbody2D>().AddForce (Vector2.right * 600);
		
		coolDown = Time.time + attackspeed;
		
	}

}
