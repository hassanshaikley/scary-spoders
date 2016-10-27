using UnityEngine;
using System.Collections;

public class LightOffOn : MonoBehaviour {

	public Light light;



	// Use this for initialization
	void Start () {
		InvokeRepeating("fn", 2f, 2F);

	}
	
	// Update is called once per frame
	void Update () {


	}

	void fn() {
		int x = Random.Range(0,3);

		if( x == 0)
			light.enabled = !light.enabled;
	}
}
