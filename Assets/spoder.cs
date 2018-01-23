using UnityEngine;
using System.Collections;

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
		InvokeRepeating("playerInLOS", 2.0f, 5.0f);


	}

	void OnTriggerEnter (Collider trig) {
//		Debug.Log ("spTriggereD " + trig.gameObject.tag);

		//already chasing player llol
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

//	void OnCollisionEnter (Collision col)
//	{			
//		if(col.gameObject.tag == "Player")
//		{
//			//				Destroy(col.gameObject);
//			Time.timeScale = 0;
//			RenderSettings.ambientIntensity = 0.4f;
//		}
//	}
//	

	public void OnCollisionEnter(Collision theCollision){
		Debug.Log("Hit  " + theCollision.gameObject.tag);

		if(theCollision.gameObject.tag == "Floor")
		{
			isgrounded = true;
			walkAudio.mute = false;
		}
	}

	//consider when character is jumping .. it will exit collision.
	public void OnCollisionExit(Collision theCollision){
		Debug.Log("Left  " + theCollision.gameObject.tag);

		if(theCollision.gameObject.tag == "Floor")
		{
			isgrounded = false;
			walkAudio.mute = true;

		}
	}


	private void rotateTowardsTarget() {
//		myRigidbody.rotation = Quaternion.Slerp(myTransform.rotation, Quaternion.LookRotation(targetTransform.position - myTransform.position), rotationSpeed*Time.deltaTime);
//		myRigidbody.MovePosition(targetTransform.position + targetTransform.position * rotationSpeed * Time.fixedDeltaTime);
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
		
//		myRigidbody.velocity = (myTransform.forward * moveSpeed);

		float step = moveSpeed * Time.deltaTime;
		transform.position = Vector3.MoveTowards(transform.position, targetTransform.position, step);

//		myRigidbody.MovePosition(myTransform.position + myTransform.forward * Time.deltaTime *moveSpeed) ;// += myTransform.forward * moveSpeed * Time.deltaTime;
		//gooood
//		myRigidbody.AddForce(myTransform.forward * moveSpeed);
//		myRigidbody.velocity = (targetTransform.position - myTransform.position) * moveSpeed * Time.smoothDeltaTime;

		if (triggered) {

		
			if (Random.Range (0, 60) < 1) {
				Debug.Log ("Going up");
				leap (false);

			}
//			if (Random.Range (0, 90) < 1) {
//				Debug.Log ("Going left");
//				myRigidbody.AddForce (myTransform.right * 20);
//			}
//			if (Random.Range (0, 90) < 1) {
//				Debug.Log ("Going rigt");
//				myRigidbody.AddForce (myTransform.right * -20);
//			}
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
					
					aggro.mute = false;

					targetTransform = playerTransform;
					triggered = true;


				}
			}
//		}
	}

	//checks if player is in LOS
	// if already pursuing player
	// checks if player is in LOS
	void playerInLOS(){
		RaycastHit hit;
		if (triggered) {
			if (Physics.Linecast (transform.position, playerTransform.position, out hit)) { //&& hit.transform.tag == "Wall"

				//if player is not in line of sight
				if (hit.transform.tag != "Player") {

					GameObject[] gos;
					gos = GameObject.FindGameObjectsWithTag("WayPoint");

					for (int i = 0; i < gos.Length; i++) {
						if (Physics.Linecast (transform.position, gos [i].transform.position, out hit)) { //&& hit.transform.tag == "Wall"
							if (hit.transform.tag == "WayPoint") {
								targetTransform = gos [i].transform;
								target = gos [i];
								triggered = false;
								aggro.mute = true;

								return;
							}
						}
					}
				
				}
			}
		}
	}

}
