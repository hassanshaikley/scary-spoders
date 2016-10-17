using UnityEngine;
using System.Collections;

public class spoder : MonoBehaviour {

	//way points or the player
	public GameObject target;

	Transform targetTransform;

	public float moveSpeed;
	public float rotationSpeed;

	Transform myTransform; //current transform data of this enemy
	Rigidbody myRigidbody; //current rigidbody

	void Awake()
	{
		myTransform = transform; 
		myRigidbody = GetComponent<Rigidbody>();
		targetTransform = target.transform;
	}

	void OnTriggerEnter (Collider trig) {
		Debug.Log ("spTriggereD " + trig.gameObject.tag);
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
//		Debug.Log (col.gameObject.tag);
		if(col.gameObject.tag == "Player")
		{
			//				Destroy(col.gameObject);
			Time.timeScale = 0;
			RenderSettings.ambientIntensity = 0.4f;
		}
		if(col.gameObject.tag == "WayPoint")
		{
			Debug.Log("Hit Waypoint");
		}
	}
	public void nextWayPoint(){
		Debug.Log ("Fuckk my liife");
//		target = target.nextWayPoint ();
		targetTransform = target.transform;
	}

	private void Update()
	{
		myTransform.rotation = Quaternion.Slerp(myTransform.rotation,
			Quaternion.LookRotation(targetTransform.position - myTransform.position), rotationSpeed*Time.deltaTime);

		myRigidbody.MovePosition(myTransform.position + myTransform.forward * Time.deltaTime *moveSpeed) ;// += myTransform.forward * moveSpeed * Time.deltaTime;
//		myRigidbody.AddForce(myTransform.position + myTransform.forward * Time.deltaTime *moveSpeed);
//		myRigidbody.AddForce(myTransform.position + myTransform.forward * Time.deltaTime *moveSpeed);

	}

}
