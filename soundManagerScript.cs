using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class soundManagerScript : MonoBehaviour {

	public static soundManagerScript Instance{set;get;} //setting and getting the instance of the sound manager

	public AudioSource source;

	public AudioClip[] allSounds; // creating an audioClip array called allSounds for later in case i want to use more than one sound

	private void Start() // making sure the manager is listening for events
	{

		Instance = this; // setting the instance of the object to this
		DontDestroyOnLoad(gameObject); // so when new scene is called the object or audio source in this case will not be destroyed
		SceneManager.LoadScene("Splash");

	}

	public void PlaySound(int soundIndex)
	{

		AudioSource.PlayClipAtPoint (allSounds[soundIndex],transform.position);


	}

}
