using UnityEngine;
using System.Collections;

public class WayPoint : MonoBehaviour {

	public GameObject[] neighbors;


	public GameObject nextWayPoint(){
		if (Random.Range (0, 100) < 50) {
			return neighbors [0];
		}

		int index = Random.Range (0, neighbors.Length);
//		Debug.Log ("New target acquired : " + neighbors [index]);
		return neighbors [index];
	}
}
