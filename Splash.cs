using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Splash : MonoBehaviour {

	private Color ranAlpha;
	private float currentAlpha;

	// Use this for initialization
	void Start () {

		ranAlpha = new Color (1, 1, 1, Random.Range (0.3f, 0.5f)); // ran range min & max
		GetComponent<Renderer>().material.color = ranAlpha;
		InvokeRepeating("ReduceAlpha", 0.3f, 0.3f);
	}
	
	// Update is called once per frame
	void ReduceAlpha () {
		currentAlpha = GetComponent<Renderer>().material.color.a;

		if (GetComponent<Renderer>().material.color.a <= 0.1f) {
			Destroy (gameObject);
		} 

		else {

			GetComponent<Renderer>().material.color = new Color (1, 1, 1, currentAlpha - 0.1f);

		}

	}
}


// for creating a splash background code not used.