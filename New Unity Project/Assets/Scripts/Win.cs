using UnityEngine;
using System.Collections;

public class Win : MonoBehaviour {
	// Update is called once per frame
	void Update()
	{
		RaycastHit2D hit = Physics2D.Raycast(Camera.main.ScreenToWorldPoint(Input.mousePosition),Vector2.zero);

		//if the mouse is over a button
		if(hit.collider != null)
		{
			//restart the game
			if(hit.collider.name == "Play") //hover
			{
				if(Input.GetMouseButtonDown(0)) //click
				{
					Application.LoadLevel("test");
				}
			}
			//go to main menu
			if(hit.collider.name == "Menu") //hover
			{
				if(Input.GetMouseButtonDown(0)) //click
				{
					Application.LoadLevel("Menu");
				}
			}
		}
	}//ends:Update
}
