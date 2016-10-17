using UnityEngine;
using System.Collections;

public class WayPoint : MonoBehaviour {

	public GameObject[] neighbors;


	public GameObject nextWayPoint(){
		int index = Random.Range (0, neighbors.Length);
		Debug.Log ("New target acquired : " + neighbors [index]);
		return neighbors [index];
	}
}
