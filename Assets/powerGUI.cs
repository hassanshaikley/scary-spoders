using UnityEngine;
using System.Collections;

public class powerGUI : MonoBehaviour {
	public Texture powerTexture;

	void Update() {
	}
	
	void OnGUI () {
		// Make a background box
//		GUI.DrawTexture(new Rect(5, 5, 25, 25), powerTexture, ScaleMode.ScaleToFit, true);

		if (flashlight.power >= 80) {
			GUI.DrawTexture(new Rect(5, 0, 25, 25), powerTexture, ScaleMode.ScaleToFit, true);

		}
		if (flashlight.power >= 60) {
			GUI.DrawTexture(new Rect(5, 15, 25, 25), powerTexture, ScaleMode.ScaleToFit, true);
		}
		if (flashlight.power >= 40) {
			GUI.DrawTexture(new Rect(5, 30, 25, 25), powerTexture, ScaleMode.ScaleToFit, true);
		}
		if (flashlight.power >= 20) {
			GUI.DrawTexture(new Rect(5, 45, 25, 25), powerTexture, ScaleMode.ScaleToFit, true);
		}
		if (flashlight.power >= 5) {
			GUI.DrawTexture(new Rect(5, 60, 25, 25), powerTexture, ScaleMode.ScaleToFit, true);
		}

	}
}