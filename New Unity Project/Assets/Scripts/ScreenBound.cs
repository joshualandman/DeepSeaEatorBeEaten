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
			GetComponent<Player>().velocity.x = 0;
		}
		else if(newPosition.x < -37.5)
		{
			newPosition.x = -37.5f;
			GetComponent<Player>().velocity.x = 0;
		}

		transform.position = newPosition;

	}

	void OnCollisionEnter2D(Collision2D other)
	{
		//Stop the player's velocity if they hit the top or bottom
		if(other.gameObject.name == "sea-bed" || other.gameObject.name == "top-sea")
		{
			GetComponent<Player>().velocity.y = 0;
		}
	}
}
