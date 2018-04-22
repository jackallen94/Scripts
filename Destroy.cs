using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Destroy : MonoBehaviour {
	public GameObject Bomb;
//	void OnTriggerEnter2D(Collider2D col) 
//
//	{
//
//		if (col.tag == "Blade") {
//
//
//			Debug.Log ("hit");
//			Destroy (gameObject);
//
//		}


	void OnTriggerEnter2D(Collider2D col)
	{
		if (col.gameObject.tag == "Bomb") {
			Debug.Log ("its working");
  			Destroy (col.gameObject);
			GameManager.Instance.Death ();
		}

	}

//	void OnCollisionEnter2D(Collision2D col)
//	{
//		if (col.gameObject.tag == "Bomb") {
//			Debug.Log ("its working");
//			Destroy (col.gameObject);
//			GameManager.Instance.Death ();
//		}
//
//	}

	}



