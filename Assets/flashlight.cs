using UnityEngine;
using System.Collections;

public class flashlight : MonoBehaviour {

//	public Light flashlight;
	public static double power;
	public AudioSource lightAudio;


	// Use this for initialization
	void Start () {
		power =  100.0;
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
			lightAudio.Play ();
		}
		if (Input.GetMouseButtonDown (0)) {
			if (GetComponent<Light> ().enabled == true) {
				GetComponent<Light> ().enabled = false; 
				lightAudio.Play ();

			} else if ( power > 0 && ! PlayerScript.gameOver){
				GetComponent<Light> ().enabled = true; 
				lightAudio.Play ();

			}
		}
	}
	
}
