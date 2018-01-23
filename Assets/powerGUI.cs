using UnityEngine;
using System.Collections;

public class powerGUI : MonoBehaviour {
	public Texture powerTexture;
	public Texture batteryTexture;


	void Start() {

	}
	void Update() {
	}
	
	void OnGUI () {
//		// Make a background box
////		GUI.DrawTexture(new Rect(5, 5, 25, 25), powerTexture, ScaleMode.ScaleToFit, true);
//		GUI.DrawTexture(new Rect(5, -5, 55, 120), batteryTexture, ScaleMode.ScaleToFit, true);
//

		if (flashlight.power >= 80) {
			GUI.DrawTexture(new Rect(10, 10, 25, 25), powerTexture, ScaleMode.ScaleToFit, true);

		}
		if (flashlight.power >= 60) {
			GUI.DrawTexture(new Rect(10, 25, 25, 25), powerTexture, ScaleMode.ScaleToFit, true);
		}
		if (flashlight.power >= 40) {
			GUI.DrawTexture(new Rect(10, 40, 25, 25), powerTexture, ScaleMode.ScaleToFit, true);
		}
		if (flashlight.power >= 20) {
			GUI.DrawTexture(new Rect(10, 55, 25, 25), powerTexture, ScaleMode.ScaleToFit, true);
		}
		if (flashlight.power >= 5) {
			GUI.DrawTexture(new Rect(10, 70, 25, 25), powerTexture, ScaleMode.ScaleToFit, true);
		}

		GUIStyle style1 = new GUIStyle();
		style1.normal.textColor = Color.gray;

		GUI.Box(new Rect(10, 95, 20, 10), "" + flashlight.power.ToString("0") + "%", style1);

	}
}