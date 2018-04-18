using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Destroy : MonoBehaviour {

	void onCollisionEnter(Collision col)
	{
		if(col.gameObject.tag == "bomb")

		{
			Destroy(gameObject);

		}

	}


}
