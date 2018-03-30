using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement; // managing scenes to go to another

public class menuManScript : MonoBehaviour {

	public void ToGame() // brings user to the game
	{


		SceneManager.LoadScene("Main");


	}
}
