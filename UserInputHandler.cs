using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UserInputHandler : MonoBehaviour {

	public delegate void TapAction (Touch t);
	public static event TapAction OnTap;      // creating a tap event

	public float tapMaxMovement = 50f; // maximum amount a touch can move in pixels

	private Vector2 movement; // calculates how far we have moved

	private bool tapGestureFailed = false; // will be set to true if user moves finger too far

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update ()
	{

		if (Input.touchCount > 0) { // if statement to check and see is there any touches now

			Touch touch = Input.touches [0]; //setting an array to check all touches on the screen (only focusing on a single touch so position the array at the start being 0) 

			if (touch.phase == TouchPhase.Began) // finger first touches the screen
			{ 
				movement = Vector2.zero;
			} else if (touch.phase == TouchPhase.Moved || touch.phase == TouchPhase.Stationary) {
				movement += touch.deltaPosition; // increment the amount the touch has moved, deltaPosition is the amount of pixels the touch has move since the last check

				if (movement.magnitude > tapMaxMovement)
					tapGestureFailed = true; // if movement is too much then set tapgesture to true 
			} 

			else {
				if (!tapGestureFailed) { // check if moved too much
					if (OnTap != null)
						OnTap (touch); // if it did not fail 
				}

				tapGestureFailed = false; // otherwise set to false (boolean controls this)

			}
		}

	}

}




	


		
	
			
