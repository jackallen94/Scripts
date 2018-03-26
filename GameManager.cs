using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI; // using unity user interface

public class GameManager : MonoBehaviour {


	// creating an instance of the game manager so it can be accessed 
	public static GameManager Instance{set;get;} // property

	private const float SLICE_FORCE = 400.0f; // see github for explanation part 19

	private List<Vegetables> veggies = new List<Vegetables> (); //instantiate our vegatables
	public GameObject vegetablesPrefab; // grab the objects that are prefabs of our vegetables object (a prefab allows us to easily create duplicates that store all properties inside the prefab) 

	private float lastSpawn = 1.5f; // subject to change 
	private float normalSpawn = 2.0f;

	public Transform trail; // game component trail

	private Vector3 lastMousePosition;

	private Collider2D[] veggieCollider;   // collider array used to check which collider you hit last frame

	// UI part of game
	private int score;
	private int highScore;
	private int life;
	public Text scoreText;
	public Text highScoreText;
	public Image[] lifepoints;
	public GameObject pauseMenu; // creating new gameobject


	private void Awake()
	{

		Instance = this; // Accessing the instance of the gameManager

	}


	private void Start()
	{

		veggieCollider = new Collider2D[0]; // start the collider at beginning of array which is always 0 
		newGame(); // new game is launched


	}

	private void newGame()
	{
		score = 0;
		life = 3; // when a new game is launched these are the default values
		pauseMenu.SetActive(false);
		Time.timeScale = 1;
		// timescale used for slowing time or slow motion
		// in this case used to stop run time of game
		// time.delta time is essentially being set to 0 

	}

	private void Update()
	{

		//Debug.Log (Input.mousePosition); // debug the mouse position

		if (Time.time - lastSpawn > normalSpawn) { // if the last time a veggie was spawned is greater than the normal spawn time of 2f than spawn a new veggie

			Vegetables v = GetVegetable ();
			float ranX = Random.Range (-1.65f, 1.65f);
			v.startVeggie (Random.Range (1.85f, 2.75f), ranX, -ranX); // picking up the values of startVeggie and giving them values such as velocity which can be seen in vegetables script
			normalSpawn = Time.time; // normalspawn time = running time of the game


		}
	

		if (Input.GetMouseButton (0)) // check if im holding the left click or touch on a device
		{ 
			
			Vector3 pos = Camera.main.ScreenToWorldPoint(Input.mousePosition);       // transferring the screen coordinates using the mouse using unity screentoworldpoint allowing them to show up in our world or game 
			// return vector 3 x and y position
//			Physics2D.RaycastAll(new Vector2(pos.x,pos.y),Camera.main.transform.forward,
			pos.z = -1;
			trail.position = pos;

			Collider2D[] thisFramesVeggie = Physics2D.OverlapPointAll (new Vector2 (pos.x, pos.y), LayerMask.GetMask ("Vegetables"));
			// overlapPointAll returns us a 2d collider array
			// everytime our finger is dragged on the screen check where finger is and check to see was a collider hit that are vegetables
			// if we do hit them then store all of them in an array

			//Debug.Log (Input.mousePosition);
			//Debug.Log((Input.mousePosition - lastMousePosition).sqrMagnitude)) 
			if((Input.mousePosition - lastMousePosition).sqrMagnitude > SLICE_FORCE) 
			{
				// if the sqMagnitude is bigger than 9.0f 3 squared is 9 speed
				foreach (Collider2D c2 in thisFramesVeggie) {
					for (int i = 0; i < veggieCollider.Length; i++) {
						if (c2 == veggieCollider [i]) 
						{
							c2.GetComponent<Vegetables> ().SlicingVeggie();
							//Debug.Log ("Hit");
						}

					}

				}
						// c2 is a collider
				//Debug.Log(c2.name); // debugging hit detection
			}
			
			lastMousePosition = Input.mousePosition;
			veggieCollider = thisFramesVeggie;

	//Physics2D.RaycastAll(new Vector2(camPos.x,camPos.y), Camera.main.transform.forward
//			Physics2D.RaycastAll(new Vector2(pos.x,pos.y),
		}


	}


	private Vegetables GetVegetable() //  this will either get me something that is already isActive seen in our vegetables script or it will create a new instance
	{

		Vegetables v = veggies.Find (x => !x.IsActive); // this was quite difficult basically this looks through the list of veggies to find the first one that is not active, x being the veggie its looking at right now and also setting vegetable to variable v
		// if the veggie is not active right now return the veggie to v field and stop executing. 

		if (v == null) 
		{ // if we haven't been able to find a veggie because they are all being used right now

			v = Instantiate(vegetablesPrefab).GetComponent<Vegetables>(); // create a new instance of a vegetable using a prefab
			veggies.Add(v);
		
		}

		return v; // return vegetables ending our pooling of vegetables saving memory by using prefabs for optimisation purposes.
	}


	public void incrementScore(int scoreAmount)
	{

		score += scoreAmount;
		scoreText.text = score.ToString(); // converting to the current score to a string

		if(score > highScore) // if current score is bigger than highscore
			{
			highScore = score;
			highScoreText.text = "BEST:" + highScore.ToString(); // concatinate so we are displaying best score on screen

			}

	}

	public void loseLife() 
	{
		if (life == 0)
			return;

		life--;
		lifepoints [life].enabled = false;
		if (life == 0)

			Death();

		}
			



	public void Death()
	{
		Debug.Log ("Death");




	}


	public void pauseGame()
	{
		pauseMenu.SetActive(!pauseMenu.activeSelf); // reverse state of pause menu
		Time.timeScale = (Time.timeScale==0) ? 1 : 0 ; // setting the time to 0 as game is paused






	}






}
