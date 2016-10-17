using UnityEngine;
using System.Collections;

public class PlayerScript : MonoBehaviour {

	// Use this for initialization
	void Start () {
		RenderSettings.ambientIntensity = 0.0f;

	}

	float timeLeft = 60.0f;

	void Update()
	{
		timeLeft -= Time.deltaTime;
		if(timeLeft < 0)
		{
			Debug.Log ("Try");
			Time.timeScale = 0;
			RenderSettings.ambientIntensity = 3.2f;
		}
	}
	void OnCollisionEnter (Collision col)
	{			
		Debug.Log ("Hit main player");
		if(col.gameObject.tag == "Enemy")
		{
			
			Time.timeScale = 0;
			RenderSettings.ambientIntensity = 0.4f;
		}
	}
}
