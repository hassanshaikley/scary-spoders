﻿using UnityEngine;
using System.Collections;

public class flashlight : MonoBehaviour {

//	public Light flashlight;
	public static double power = 100.0;

	// Use this for initialization
	void Start () {

	}
	
	// Update is called once per frame
	void Update () {
		if (GetComponent<Light> ().enabled == true) {
			power = power - .5;
		} else {
			if (power <= 99.5) {
				power = power + .5;
			}
		}
		if (power <= 0) {
			GetComponent<Light> ().enabled = false; 
		}
		if (Input.GetMouseButtonDown (0)) {
			Debug.Log ("hi");
			if (GetComponent<Light> ().enabled == true) {
				GetComponent<Light> ().enabled = false; 
			} else if ( power > 0){
				GetComponent<Light> ().enabled = true; 
			}
		}
	}
	
}
