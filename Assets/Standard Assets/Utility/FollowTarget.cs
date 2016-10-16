using System;
using UnityEngine;


namespace UnityStandardAssets.Utility
{
    public class FollowTarget : MonoBehaviour
    {
        public Transform target;
//        public Vector3 offset = new Vector3(0f, 7.5f, 0f);

		double moveSpeed = 1.0;
		double rotationSpeed = .5;

		Transform myTransform; //current transform data of this enemy


		void Awake()
		{
			myTransform = transform; //cache transform data for easy access/preformance
		}

        private void LateUpdate()
        {
			myTransform.rotation = Quaternion.Slerp(myTransform.rotation,
			Quaternion.LookRotation(target.position - myTransform.position), rotationSpeed*Time.deltaTime);


			//move towards the player
			myTransform.position += myTransform.forward * moveSpeed * Time.deltaTime;
//            transform.position = target.position + offset;
        }
    }
}
