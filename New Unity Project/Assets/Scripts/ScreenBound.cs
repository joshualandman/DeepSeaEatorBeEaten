using UnityEngine;
using System.Collections;

public class ScreenBound : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
		Vector3 newPosition = transform.position;

		if(newPosition.x > 37.5)
		{
			newPosition.x = 37.5f;
		}
		else if(newPosition.x < -37.5)
		{
			newPosition.x = -37.5f;
		}

		transform.position = newPosition;

	}
}
