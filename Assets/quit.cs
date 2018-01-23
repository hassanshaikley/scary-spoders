using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class quit : MonoBehaviour {

	// Use this for initialization
	void Start () {
		
	}

	void Update() {
		if (Input.GetKey("escape"))
			Application.Quit();

	}
}
