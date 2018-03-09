using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour {

	private List<Vegetables> veggies = new List<Vegetables> (); //instantiate our vegatables
	public GameObject vegetablesPrefab; // grab the objects that are prefabs of our vegetables object (a prefab allows us to easily create duplicates that store all properties inside the prefab) 


	private Vegetables GetVegetable() //  this will either get me something that is already isActive seen in our vegetables script or it will create a new instance
	{

		Vegetables v = veggies.Find (x => !x.IsActive); // this was quite difficult basically this looks through the list of veggies to find the first one that is not active, x being the veggie its looking at right now and also setting vegetable to variable v
		// if the veggie is not active right now return the veggie to v field and stop executing. 
	}














}
