using UnityEngine;
using System.Collections;
//using UnityEngine.SceneManagement;
//using UnityEngine;
//using System.Collections;
//using UnityEngine.UI;
using UnityEngine.SceneManagement;

//using UnityStandardAssets.Characters.FirstPerson;
using UnityStandardAssets.Characters.FirstPerson;


public class PlayerScript : MonoBehaviour {

	public Canvas canvas;
	public Light flashlight;
	public FirstPersonController FPSC;

	public bool gameOver;

	// Use this for initialization
	void Start () {
//		RenderSettings.ambientIntensity = 0.0f;

		Color color = new Color();
		ColorUtility.TryParseHtmlString ("17181C", out color);

		RenderSettings.ambientSkyColor = Color.black;
		DynamicGI.UpdateEnvironment();
		gameOver = false;

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
			RenderSettings.ambientLight = Color.blue;

//			GameObject.Find ("First Person Controller").GetComponent ("MouseLook").enabled = false;
//			MouseLook StopLook = GameObject.Find("First Person Controller").GetComponent("MouseLook");
////			StopLook.UpdateCursorLock =
////			GetComponent<FirstPersonController>().SendMessage("ToggleInputCursor", true);
////			Cursor.visible = true;
//			StopLook.enabled = false;
			gameOver = true;


		}

		if (gameOver && Input.GetKeyDown ("escape")) {
			SceneManager.LoadScene("GameScene");
			Time.timeScale = 1;

		}
		

	}

	void OnGUI() {

		GUI.Box(new Rect(Screen.width - 50, 10, 50, 20), "" + timeLeft.ToString("0"));

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
//			GameObject.Find("FPSController").GetComponent<FirstPersonController>().enabled = false;

//			FPSController.GetComponent<FirstPersonController>().enabled = false;

			gameOver = true;
		}
	}
}
