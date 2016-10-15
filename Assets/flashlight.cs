using UnityEngine;
using System.Collections;

public class flashlight : MonoBehaviour {

//	public Light flashlight;
	public double power = 100.0;

	// Use this for initialization
	void Start () {

	}
	
	// Update is called once per frame
	void Update () {
		if (GetComponent<Light> ().enabled == true) {
			power = power - .1;
		} else {
			if (power <= 99.9) {
				power = power + .1;
			}
		}
		if (Input.GetMouseButtonDown (0)) {
			Debug.Log ("hi");
			if (GetComponent<Light> ().enabled == true) {
				GetComponent<Light> ().enabled = false; 
			} else {
				GetComponent<Light> ().enabled = true; 
			}
		}
	}
	
}
