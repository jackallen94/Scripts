using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour {

	private List<Vegetables> veggies = new List<Vegetables> (); //instantiate our vegatables
	public GameObject vegetablesPrefab; // grab the objects that are prefabs of our vegetables object (a prefab allows us to easily create duplicates that store all properties inside the prefab) 

	private void Update()
	{

		if (Time.time - lastSpawn > normalSpawn) { // if the last time a veggie was spawned is greater than the normal spawn time of 2f than spawn a new veggie

			Vegetables v = GetVegetable ();
			//float ranX = Random.Range(-1.5f,1.5f);

			v.startVeggie ();
			normalSpawn = Time.time;


		}



	}

	private float lastSpawn;
	private float normalSpawn = 2.0f;

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














}
