using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class soundManagerScript : MonoBehaviour {

	public static soundManagerScript Instance{set;get;} //setting and getting the instance of the sound manager

	public AudioClip[] allSounds; // creating an audioClip array called allSounds for later in case i want to use more than one sound

	private void Wake() // making sure the manager is listening for events (wake)
	{

		Instance = this; // setting the instance of the object to this

	}
}
