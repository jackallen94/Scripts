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
		transform.position = new Vector3(xStart,0,0);  
	}

	private void Update() 
	{
		if (!IsActive)
			return;
		
		verticalVelocity -= Gamegravity * Time.deltaTime; // update runs then
}