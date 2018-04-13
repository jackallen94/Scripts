using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Vegetables : MonoBehaviour {

	private const float Gamegravity = 2.0f; // setting a private constant of the gravity to 2 floats so this cannot be changed

	public bool IsActive{set; get;} // if object is not active we can reuse it without having to create new veggie
	public SpriteRenderer sRenderer; // drag and drop the sprite renderer component


	private float verticalVelocity;
	private float speed;


	private bool isSliced = false;

//	private void Start() {
//
//		startVeggie (2.0f, 1, -1); // verticalVelocity of 2.0f, xspeed of 1 and xstart of -1
//	}

	public Sprite[] sprites;// creating an array of sprites
	private int spriteIndex; // index position of the array
	private float lastSpriteUpdate; // last frame sprite updated
	private float spriteUpdateDelta = 0.101f;// time between each frame
	private float rotationSpeed;


	public void startVeggie(float verticalVelocity, float xSpeed, float xStart) // x axis speed and starting position
	{
		IsActive = true; // setting the boolean isActive to true 
		speed = xSpeed;
		this.verticalVelocity = verticalVelocity; // this makes it less confusing setting one parameter to another.

		transform.position = new Vector3(xStart,0,0); // when we start Y is at 0  
		rotationSpeed = Random.Range(-180,180); // random rotation every second between a range of 30 degrees and 180
		isSliced =false; // resetting the veggie
	spriteIndex = 0;
	sRenderer.sprite = sprites[spriteIndex];
	}

	private void Update() 
	{
		if (!IsActive)
			return; // update runs then
		
		verticalVelocity -= Gamegravity * Time.deltaTime; // using the const above allows us to set the gravity for 2.0 floats for all vegetables. 
		transform.position += new Vector3(speed,verticalVelocity,0) * Time.deltaTime; // setting z to 0 and deltatime is the amount of time it takes to complete the last frame 
		transform.Rotate(new Vector3(0,0,rotationSpeed) * Time.deltaTime); // delta time so when we pause game veggie will stop rotating
		if (isSliced) 
		
		{

			if (spriteIndex != sprites.Length-1 && Time.time - lastSpriteUpdate > spriteUpdateDelta) // go and update the sprite
			
			{

				lastSpriteUpdate = Time.time;
				spriteIndex++; // adding in the array starts at 0 and goes up
				sRenderer.sprite = sprites [spriteIndex];
			}

		}


		if (transform.position.y < -15)
		{// if the position of the veggie on the y axis is smaller than -1 then we don't see it
			IsActive = false;
			// ready to reuse the object that is not active
			if (!isSliced)
				GameManager.Instance.loseLife(); // accessing the instance of the gamemanager seen in gamemanager script and calling the lose life function.
		}
	
	}



	public void SlicingVeggie() 
	{
		if (isSliced) // if isSliced is true then return so cannot run twice
			return;
			

		if (verticalVelocity < 0.5f) { // when you slice the vegetable give it a small bump up
			verticalVelocity = 0.5f; // being pushed upwards creating that effect

			speed = speed * 0.5f; // setting the speed of the slice to 0.5floats
			isSliced = true; // set isSliced to true if the veggie is being hit

			soundManagerScript.Instance.PlaySound(1); 

			GameManager.Instance.incrementScore(1); // increment the score by 1 locating the increment score fucntion in the gameManager script
		}

	}













}