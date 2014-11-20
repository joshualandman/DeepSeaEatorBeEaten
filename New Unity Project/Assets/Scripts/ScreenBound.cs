using UnityEngine;
using System.Collections;

public class ScreenBound : MonoBehaviour {


	public float maxX;
	public float minX;
	public float maxY;
	public float minY;

	public GameObject background;

	//Sets the min and max of x and y
	void Start()
	{
		maxX = background.renderer.bounds.max.x - 20f;
		minX = background.renderer.bounds.min.x + 20f;
		maxY = background.renderer.bounds.max.y - .5f;
		minY = background.renderer.bounds.min.y + .5f;

	}

	//Change the background
	void ChangeBackground()
	{
		maxX = background.renderer.bounds.max.x - 20f;
		minX = background.renderer.bounds.min.x + 20f;
		maxY = background.renderer.bounds.max.y - .5f;
		minY = background.renderer.bounds.min.y + .5f;
	}
	
	// Update is called once per frame
	void Update () {
	
		Vector3 newPosition = transform.position;

		//Check to see if the player has gone to the horizontal limits of the background and stops him and set his vertical velocity to zero
		if(newPosition.x > maxX)
		{
			newPosition.x = maxX;
			GetComponent<Player>().velocity.x = 0;
		}
		else if(newPosition.x < minX)
		{
			newPosition.x = minX;
			GetComponent<Player>().velocity.x = 0;
		}

		//Check to see if the player has gone to the vertical limits of the background and stops him and set his vertical velocity to zero
		if(newPosition.y > maxY)
		{
			newPosition.y = maxY;
			GetComponent<Player>().velocity.y = 0;
		}
		else if(newPosition.y < minY)
		{
			newPosition.y = minY;
			GetComponent<Player>().velocity.y = 0;
		}

		//Set the players new position
		transform.position = newPosition;
	}
}
