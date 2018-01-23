using UnityEngine;
using System.Collections;
using System.Collections.Generic;
public class spoder : MonoBehaviour {

	//way points or the player
	public GameObject target;
	public Transform playerTransform;

	public AudioSource aggro;
	public AudioSource leapAudio;
	public AudioSource walkAudio;



	bool triggered;
	Transform targetTransform;

	public float moveSpeed;
	public float rotationSpeed;

	private bool isgrounded;

	Transform myTransform; //current transform data of this enemy
	Rigidbody myRigidbody; //current rigidbody

	void Awake()
	{
		triggered = false;
		aggro.mute = true;
		walkAudio.Play ();
		myTransform = transform; 
		myRigidbody = GetComponent<Rigidbody>();
		targetTransform = target.transform;
		InvokeRepeating("checkForPlayer", 2.0f, 0.3f);
		InvokeRepeating("playerStillInLos", 2.0f, 5.0f);

	}

	void OnTriggerEnter (Collider trig) {
		if (triggered) {
			return;
		}
		if (trig.gameObject.tag == "WayPoint") {
			
			if (target == trig.gameObject){
				target = target.GetComponent<WayPoint>().nextWayPoint ();
				targetTransform = target.transform;
			}
		};
	}
		
	public void OnCollisionEnter(Collision theCollision){

		if(theCollision.gameObject.tag == "Floor")
		{
			isgrounded = true;
			walkAudio.mute = false;
		}
	}

	//consider when character is jumping .. it will exit collision.
	public void OnCollisionExit(Collision theCollision){

		if(theCollision.gameObject.tag == "Floor")
		{
			isgrounded = false;
			walkAudio.mute = true;

		}
	}

	private void startAggro() {

		triggered = true;
		aggro.mute = false;
	}
	private void stopAggro() {

		triggered = false;
		aggro.mute = true;

	}

	private void rotateTowardsTarget() {
		transform.LookAt(targetTransform);
	}

	private void leap(bool aggro) {
		if (!isgrounded)
			return;
		int aggroBonus = aggro ? 30 : 0;
		myRigidbody.AddForce (myTransform.up * Random.Range(60, 80));
		myRigidbody.AddForce (myTransform.forward * (aggroBonus + Random.Range(20,50)));
		leapAudio.Play ();


	}
	private void FixedUpdate()
	{
		
		if (PlayerScript.gameOver) {
			aggro.mute = true;
		}

		rotateTowardsTarget ();
		

		float step = moveSpeed * Time.deltaTime;
		transform.position = Vector3.MoveTowards(transform.position, targetTransform.position, step);

		if (triggered) {
			if (Random.Range (0, 60) < 1) {
				leap (false);
			}
		}


	}

	// if player in LOS aggros player
	void checkForPlayer(){
		if (PlayerScript.gameOver)
			return;
		RaycastHit hit;
//		if (Mathf.Abs (playerTransform.position.x - transform.position.x) < 10 && Mathf.Abs (playerTransform.position.y - transform.position.y) < 10) {
			if (Physics.Linecast (transform.position, playerTransform.position, out hit)) { //&& hit.transform.tag == "Wall"
				if (hit.transform.tag == "Player") {
					if (!triggered) {
						leap (true);
					}
			
					startAggro ();
					targetTransform = playerTransform;

				}
			}
//		}
	}

	// if already pursuing player
	// checks if player is in LOS
	void playerStillInLos(){
		RaycastHit hit;
		if (triggered) {
			if (Physics.Linecast (transform.position, playerTransform.position, out hit)) { //&& hit.transform.tag == "Wall"

				//if player is not in line of sight
				if (hit.transform.tag != "Player") {

					GameObject[] gos;
					List<GameObject> hitGos = new List<GameObject>();


					gos = GameObject.FindGameObjectsWithTag("WayPoint");

					stopAggro ();



					for (int i = 0; i < gos.Length; i++) {
						if (Physics.Linecast (transform.position, gos [i].transform.position, out hit)) {
							if (hit.transform.tag == "WayPoint") {
								hitGos.Add (gos [i]);

							}
						}
					}

					int index = Random.Range (0, hitGos.Count - 1);

					targetTransform = gos [index].transform;
					target = gos [index];
				
				}
			}
		}
	}

}
