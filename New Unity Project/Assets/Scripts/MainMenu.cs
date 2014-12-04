using UnityEngine;
using System.Collections;

public class MainMenu : MonoBehaviour {

	//control variables
	bool main = true;

	//menue textures
	public SpriteRenderer start;
	public SpriteRenderer instruct;

	//enemy sprites
	public SpriteRenderer fangtooth;
	public SpriteRenderer copepod;

	//sets instructions as invisible to start
	void Awake()
	{
		//instructions and enemy sprites start out invisible
		instruct.color = new Color(1f,1f,1f,0f);
		fangtooth.color = new Color(1f,1f,1f,0f);
		copepod.color = new Color(1f,1f,1f,0f);
	}

	// Update is called once per frame
	void Update()
	{
		RaycastHit2D hit = Physics2D.Raycast(Camera.main.ScreenToWorldPoint(Input.mousePosition),Vector2.zero);

		//screen size = 1276x735
		//if the mouse is over a button
		if(hit.collider != null)
		{
			//main menu
				//start the game
			if(hit.collider.name == "Start") //hover
			{
				if(Input.GetMouseButtonDown(0)) //click
				{
					Application.LoadLevel("test");
				}
			}
				//show instructions
			if(main == true && hit.collider.name == "Instructions") //hover
			{
				if(Input.GetMouseButtonDown(0)) //click
				{
					start.color = new Color(1f,1f,1f,0f);
					instruct.color = new Color(1f,1f,1f,1f);
					fangtooth.color = new Color(1f,1f,1f,1f);
					copepod.color = new Color(1f,1f,1f,1f);
					main = false;
				}
			}
			//instructions
				//switch back to menu
			if(main == false && hit.collider.name == "Back") //hover
			{
				if(Input.GetMouseButtonDown(0)) //click
				{
					start.color = new Color(1f,1f,1f,1f);
					instruct.color = new Color(1f,1f,1f,0f);
					fangtooth.color = new Color(1f,1f,1f,0f);
					copepod.color = new Color(1f,1f,1f,0f);
					main = true;
				}
			}
		}
	}//ends:Update
}