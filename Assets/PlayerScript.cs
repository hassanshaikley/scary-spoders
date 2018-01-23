using UnityEngine;
using System.Collections;
//using UnityEngine.SceneManagement;
//using UnityEngine;
//using System.Collections;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

//using UnityStandardAssets.Characters.FirstPerson;
using UnityStandardAssets.Characters.FirstPerson;


public class PlayerScript : MonoBehaviour {

	public Light flashlight;
	public FirstPersonController FPSC;

	public GameObject gameWon; 
	public GameObject gameOverCanvas; 


	public AudioSource gameOverAudio;

	public static bool gameOver;

	// Use this for initialization
	void Start () {
//		RenderSettings.ambientIntensity = 0.0f;

		Color color = new Color();
		ColorUtility.TryParseHtmlString ("17181C", out color);

		RenderSettings.ambientSkyColor = Color.black;
		RenderSettings.skybox.color = Color.black;

		DynamicGI.UpdateEnvironment();
		gameOver = false;



	}

	float timeLeft = 60.0f;



	void Update()
	{
		timeLeft -= Time.deltaTime;
		if(timeLeft < 0)
		{
			Time.timeScale = 0.01f;
			RenderSettings.ambientIntensity = 3.2f;
			RenderSettings.ambientLight = Color.blue;

			gameOver = true;

		}

		if (gameOver && Input.GetKeyDown ("q")) {
			SceneManager.LoadScene("GameScene");
			Time.timeScale = 1;

		}

		if (gameOver && timeLeft <= 0) {
			gameWon.SetActive(true);

		}

	}

	void OnGUI() {
		GUIStyle style1 = new GUIStyle();
		style1.normal.textColor = Color.gray;
		
		GUI.Box(new Rect(Screen.width - 50, 10, 50, 20), "" + timeLeft.ToString("0"), style1);

	}
	void OnCollisionEnter (Collision col)
	{			
		Debug.Log ("Hit main player");
		if(col.gameObject.tag == "Enemy")
		{

			float survivedFor = 60.0f - timeLeft;


			
			Time.timeScale = 0.01f;
			RenderSettings.ambientIntensity = 0.8f;
			RenderSettings.ambientLight = Color.red;
			flashlight.enabled = false;
			gameOverCanvas.transform.Find ("Text").gameObject.GetComponent<Text>().text = "You survived for " + Mathf.RoundToInt(survivedFor) + " seconds. Congratulations. Press q to try again."; 
			gameOverCanvas.SetActive(true);
			gameOverAudio.Play ();
			gameOver = true;
		}
	}
}
