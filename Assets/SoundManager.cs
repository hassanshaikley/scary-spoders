using UnityEngine;
using System.Collections;

public class SoundManager : MonoBehaviour {

	public AudioSource efxSource;
	public AudioSource aggroSound;


	public static SoundManager instance = null;

	void Awake () {
		if (instance == null)
			instance = this;
		else if (instance != this) {
			Destroy (gameObject);
		}
		DontDestroyOnLoad (gameObject);
	}

	public void PlaySingle(AudioClip clip){
		efxSource.clip = clip;
		efxSource.Play ();
	}
}
