using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class menu : MonoBehaviour {

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		if (Input.GetKeyDown("q")) {
			Debug.Log ("enter hit");

			SceneManager.LoadScene("GameScene");
			Time.timeScale = 1;
		}
//		if (Input.GetKeyDown("l")) {Debug.Log("Pressed L");}
	}
}
