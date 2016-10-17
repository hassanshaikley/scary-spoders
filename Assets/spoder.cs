using UnityEngine;
using System.Collections;

public class spoder : MonoBehaviour {

	//way points or the player
	public GameObject target;
	public Transform playerTransform;

	public AudioSource aggro;

	bool triggered;
	Transform targetTransform;

	public float moveSpeed;
	public float rotationSpeed;

	Transform myTransform; //current transform data of this enemy
	Rigidbody myRigidbody; //current rigidbody

	void Awake()
	{
		triggered = false;
		myTransform = transform; 
		myRigidbody = GetComponent<Rigidbody>();
		targetTransform = target.transform;

		InvokeRepeating("checkForPlayer", 2.0f, 1.0f);
		InvokeRepeating("playerInLOS", 2.0f, 10.0f);


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

	void OnCollisionEnter (Collision col)
	{			
		if(col.gameObject.tag == "Player")
		{
			//				Destroy(col.gameObject);
			Time.timeScale = 0;
			RenderSettings.ambientIntensity = 0.4f;
		}
//		if(col.gameObject.tag == "WayPoint")
//		{
//			Debug.Log("Hit Waypoint");
//		}
	}

	private void FixedUpdate()
	{


//		myRigidbody.rotation = Quaternion.Slerp(myTransform.rotation,
//		Quaternion.LookRotation(targetTransform.position - myTransform.position), rotationSpeed*Time.deltaTime);

//		myRigidbody.MovePosition(myTransform.position + myTransform.forward * Time.deltaTime *moveSpeed) ;// += myTransform.forward * moveSpeed * Time.deltaTime;
//		myRigidbody.AddForce((targetTransform.position - myTransform.position) * moveSpeed * Time.smoothDeltaTime);
		myRigidbody.velocity = (targetTransform.position - myTransform.position) * moveSpeed * Time.smoothDeltaTime;
	}

	void checkForPlayer(){
		RaycastHit hit;

		if (Mathf.Abs (playerTransform.position.x - transform.position.x) < 10 && Mathf.Abs (playerTransform.position.y - transform.position.y) < 10) {
			if (Physics.Linecast (transform.position, playerTransform.position, out hit)) { //&& hit.transform.tag == "Wall"
				if (hit.transform.tag == "Player") {
					aggro.Play ();

					Debug.Log ("Player is nearby");
					targetTransform = playerTransform;
					triggered = true;
				}
			}
		}
	}

	void playerInLOS(){
		RaycastHit hit;
		if (triggered) {
			if (Physics.Linecast (transform.position, targetTransform.position, out hit)) { //&& hit.transform.tag == "Wall"
				print ("Raycast hit: " + hit.transform.tag);
				if (hit.transform.tag == "Player") {
				
				
					GameObject[] gos;
					gos = GameObject.FindGameObjectsWithTag("WayPoint");

					for (int i = 0; i < gos.Length; i++) {
						if (Physics.Linecast (transform.position, gos [i].transform.position, out hit)) { //&& hit.transform.tag == "Wall"
							if (hit.transform.tag == "WayPoint") {
								Debug.Log ("Yes hit a way point so prusuing that");
								targetTransform = gos [i].transform;
								target = gos [i];
								triggered = false;
								return;
							}
						}
					}
				
				}
			}
		}
	}

}
