using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Vegetables : MonoBehaviour {

	private const float Gamegravity = 2.0f; // setting a private constant of the gravity to 2 floats so this cannot be changed

	public bool IsActive{set; get;} // if object is not active we can reuse it without having to create new veggie
	private float verticalVelocity;
	private float speed;

	public void startVeggie(float verticalVelocity, float xSpeed, float xStart) // x axis speed and starting position
	{
		IsActive = true; // setting the boolean isActive to true 
		speed = xSpeed;
		this.verticalVelocity = verticalVelocity; // this makes it less confusing setting one parameter to another.
		transform.position = new Vector3(xStart,0,0); // when we start Y is at 0  
	}

	private void Update() 
	{
		if (!IsActive)
			return; // update runs then
		
		verticalVelocity -= Gamegravity * Time.deltaTime; // using the const above allows us to set the gravity for 2.0 floats for all vegetables. 
		transform.position += new Vector3(speed,verticalVelocity,0) * Time.deltaTime; // setting z to 0 and deltatime is the amount of time it takes to complete the last frame 
	
		if (transform.position.y < -1) // if the position of the veggie on the y axis is smaller than -1 then we don't see it
			IsActive = false; // ready to reuse the object that is not active
	
	
	}