using UnityEngine;
using System.Collections;

public class ScreenBound : MonoBehaviour {
	public float maxX;
	public float minX;
	public float maxY;
	public float minY;

	public GameObject background;
	public GameObject background2;
	public GameObject darknessOverlay;

	bool backgroundNew;

	//Sets the min and max of x and y
	void Start()
	{
		maxX = background.renderer.bounds.max.x - 20f;
		minX = background.renderer.bounds.min.x + 20f;
		maxY = background.renderer.bounds.max.y - 2.5f * transform.localScale.y;
		minY = background.renderer.bounds.min.y + 2.5f * transform.localScale.y;

		backgroundNew = false;
	}

	//Change the background
	void ChangeBackground()
	{
		maxX = background.renderer.bounds.max.x - 20f;
		minX = background.renderer.bounds.min.x + 20f;
		maxY = background.renderer.bounds.max.y - 2.5f * transform.localScale.y;
		minY = background.renderer.bounds.min.y + 2.5f * transform.localScale.y;
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
		
		if(GameObject.Find("Player").GetComponent<Player>().score == 25 && !backgroundNew)
		{
			NewBackground();
			ChangeBackground();
			backgroundNew = true;
		}
	}

	void NewBackground()
	{
		background.transform.position += new Vector3(0, 0, 3);
		darknessOverlay.transform.position += new Vector3(0, 0, 3);
		GameObject.Find("top-sea").transform.position += new Vector3 (0, 0, 3);
		background = background2;
		GameObject.Find("Main Camera").GetComponent<GenerateEnemies>().background = background;
		GameObject.Find("Main Camera").GetComponent<GenerateBubbles>().background = background;
	}
}