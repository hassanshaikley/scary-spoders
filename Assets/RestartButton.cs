using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class RestartButton : MonoBehaviour {

public Canvas canvas;
	public void Restart()
	{
		SceneManager.LoadScene("GameScene");
		Time.timeScale = 1;

//			canvas.enabled = false;


	}


}
