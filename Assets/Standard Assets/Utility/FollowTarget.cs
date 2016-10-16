using System;
using UnityEngine;


namespace UnityStandardAssets.Utility
{
    public class FollowTarget : MonoBehaviour
    {
        public Transform target;
//        public Vector3 offset = new Vector3(0f, 7.5f, 0f);

		float moveSpeed = 3.5f;
		float rotationSpeed = .5f;

		Transform myTransform; //current transform data of this enemy

		Rigidbody myRigidbody;

		void Awake()
		{
			myTransform = transform; //cache transform data for easy access/preformance
			myRigidbody = GetComponent<Rigidbody>();
		}

		void Update(){
//			if (Math.Abs (myTransform.position.x - target.position.x) <= .5 && Math.Abs (myTransform.position.y - target.position.y) <= .5) {
//				Debug.Log ("Game over");
//				Time.timeScale = 0;
//			}
//
		}
		void OnCollisionEnter (Collision col)
		{			
			Debug.Log (col.gameObject.tag);
			if(col.gameObject.tag == "Player")
			{
//				Destroy(col.gameObject);
				Time.timeScale = 0;
				RenderSettings.ambientIntensity = 0.4f;
			}
		}

        private void LateUpdate()
        {
			myTransform.rotation = Quaternion.Slerp(myTransform.rotation,
			Quaternion.LookRotation(target.position - myTransform.position), rotationSpeed*Time.deltaTime);


			//move towards the player
			myRigidbody.MovePosition(myTransform.position + myTransform.forward * Time.deltaTime *moveSpeed) ;// += myTransform.forward * moveSpeed * Time.deltaTime;

//            transform.position = target.position + offset;
        }
    }
}
