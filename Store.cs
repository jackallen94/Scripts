using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Store : MonoBehaviour {


	public Transform colourPanel;

	// Use this for initialization
	void Start () {


		InitShop ();

	}
	
	// Update is called once per frame
	void Update () {
		
	}



	private void InitShop()
	{

		// make sure assigned references
		if (colourPanel == null) {

			Debug.Log ("Nothing Assigned in Inspector");

			// find children add onclick event

			int i = 0;
			foreach (Transform colourChildren in colourPanel) // for every child in colourpanel
			{
				int currentIndex = i;
				Button myButton = colourChildren.GetComponent<Button> ();

			}
		}
			


	}


	// buttons for store
	public void OnPlayClick()
	{



	}




	public void OnShopClick() {



	}
}
