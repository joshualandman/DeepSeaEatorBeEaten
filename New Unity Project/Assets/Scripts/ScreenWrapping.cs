using UnityEngine;
using System.Collections;

public class ScreenWrapping : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {

		Vector3 newPosition = transform.position;
		
		if(newPosition.x > 20)
		{
			newPosition.x = -20f;
		}
		else if(newPosition.x < -20)
		{
			newPosition.x = 20f;
		}
		
		transform.position = newPosition;
	
	}
}
