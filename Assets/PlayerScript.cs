using UnityEngine;
using System.Collections;

public class PlayerScript : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}

	float timeLeft = 60.0f;

	void Update()
	{
		timeLeft -= Time.deltaTime;
		Debug.Log ("Time left " + timeLeft);
		if(timeLeft < 0)
		{
			Debug.Log ("Try");
			Time.timeScale = 0;
		}
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
