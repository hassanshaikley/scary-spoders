using UnityEngine;
using System.Collections;

public class PlayerScript : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}
	void OnCollisionEnter (Collision col)
	{			
		Debug.Log ("Hit main player");
		if(col.gameObject.tag == "Enemy")
		{
			
			//				Destroy(col.gameObject);
			Time.timeScale = 0;
		}
	}
}
