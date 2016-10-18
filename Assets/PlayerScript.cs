using UnityEngine;
using System.Collections;
//using UnityEngine.SceneManagement;

public class PlayerScript : MonoBehaviour {

	public Canvas canvas;
	public Light flashlight;

	// Use this for initialization
	void Start () {
		RenderSettings.ambientIntensity = 0.0f;

	}

	float timeLeft = 120.0f;


	void Update()
	{
		timeLeft -= Time.deltaTime;
		if(timeLeft < 0)
		{
			Debug.Log ("Try");
			Time.timeScale = 0;
			RenderSettings.ambientIntensity = 3.2f;
			canvas.enabled = true;

		}
	}
	void OnCollisionEnter (Collision col)
	{			
		Debug.Log ("Hit main player");
		if(col.gameObject.tag == "Enemy")
		{
			
			Time.timeScale = 0;
			RenderSettings.ambientIntensity = 0.8f;
			RenderSettings.ambientLight = Color.red;
			canvas.enabled = true;
			flashlight.enabled = false;


		}
	}
}
