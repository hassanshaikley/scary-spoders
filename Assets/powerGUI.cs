using UnityEngine;
using System.Collections;

public class powerGUI : MonoBehaviour {
	public Texture powerTexture;

	void Update() {
		Debug.Log (flashlight.power);
	}
	
	void OnGUI () {
		// Make a background box
		if (flashlight.power >= 80) {
			GUI.Box (new Rect (2, 2, 25, 90), powerTexture);
		}
		if (flashlight.power >= 60) {
			GUI.Box (new Rect (2, 17, 25, 90), powerTexture);
		}
		if (flashlight.power >= 40) {
			GUI.Box (new Rect (2, 32, 25, 90), powerTexture);
		}
		if (flashlight.power >= 20) {
			GUI.Box (new Rect (2, 47, 25, 90), powerTexture);
		}
		if (flashlight.power >= 5) {
			GUI.Box (new Rect (2, 62, 25, 90), powerTexture);
		}

	}
}