using UnityEngine;
using System.Collections;

public class cameraController : MonoBehaviour {
	Transform Target; // target we want camera focused on
	float Distance = 15; 
	float CameraY = 10; // dont use camera compenent as variable

	void  Update (){

		transform.position.z = Target.position.z = Distance;
		transform.position.x = Target.position.x + 5;


	}

	void  LateUpdate (){
		GetComponent.<Camera>().main.transform.position.y = CameraY;
	}
}
