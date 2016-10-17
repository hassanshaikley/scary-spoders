using UnityEngine;
using System.Collections;

public class spoder : MonoBehaviour {

	//way points or the player
	public GameObject target;
	public Transform playerTransform;

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
	
	}

	void OnTriggerEnter (Collider trig) {
		Debug.Log ("spTriggereD " + trig.gameObject.tag);

		//already chasing player llol
		if (triggered) {
			return;
		}
		if (trig.gameObject.tag == "WayPoint") {
			Debug.Log (target == trig.gameObject);
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
//	public void nextWayPoint(){
//		Debug.Log ("Fuckk my liife");
//	}

	private void Update()
	{


//		myRigidbody.rotation = Quaternion.Slerp(myTransform.rotation,
//		Quaternion.LookRotation(targetTransform.position - myTransform.position), rotationSpeed*Time.deltaTime);

//		myRigidbody.MovePosition(myTransform.position + myTransform.forward * Time.deltaTime *moveSpeed) ;// += myTransform.forward * moveSpeed * Time.deltaTime;
		myRigidbody.AddForce((targetTransform.position - myTransform.position) * moveSpeed * Time.smoothDeltaTime);
	}

	void checkForPlayer(){
		if (Mathf.Abs (playerTransform.position.x - transform.position.x) < 5 && Mathf.Abs (playerTransform.position.y - transform.position.y) < 5) {
			Debug.Log ("Player is nearby");
			targetTransform = playerTransform;
			triggered = true;
		}
	}

}
