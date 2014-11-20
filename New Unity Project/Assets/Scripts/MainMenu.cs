using UnityEngine;
using System.Collections;

public class MainMenu : MonoBehaviour {

	//control variables
	bool startClick = false;
	bool instructClick = false;
	bool backClick = false;
	bool main = true;

	//button textures
	public Texture2D startButton;
	public Texture2D instructButton;
	public Texture2D backButton;

	//menue textures
	public SpriteRenderer start;
	public SpriteRenderer instruct;

	//sets instructions as invisible to start
	void Awake()
	{
		instruct.color = new Color(1f,1f,1f,0f);
	}

	// Update is called once per frame
	void Update ()
	{
		//display main menu
		if(main == true)
		{
			//start the game
			if(startClick == true)
			{
				Application.LoadLevel("test");
			}
			//switch view to instruction screen
			else if(instructClick == true)
			{
				start.color = new Color(1f,1f,1f,0f);
				instruct.color = new Color(1f,1f,1f,1f);
				main = false;
				//makes sure the buttons read as unclicked
				instructClick = false;
				startClick = false;
			}
		}
		//display instructions
		else
		{
			if(backClick == true)
			{
				start.color = new Color(1f,1f,1f,1f);
				instruct.color = new Color(1f,1f,1f,0f);
				main = true;
				//makes sure the button reads as unclicked
				backClick = false;
			}
		}
	}//ends:Update

	void OnGUI ()
	{
		Debug.Log("width: "+ Screen.width+"height: "+Screen.width);
		//Main menu GUI
		if(main == true)
		{
			//if the player wants to start the game
			if(GUI.Button(new Rect(152f,522f,348f,90f),startButton))
			{
				startClick = true;
			}
			//if the player wants to see the instructions
			else if(GUI.Button(new Rect(522f,522f,348f,90f),instructButton))
			{
				instructClick = true;
			}
		}
		//Instructions GUI
		else
		{
			//if the player wants to leave the instructions menu
			if(GUI.Button(new Rect(650f,642.5f,179f,100f),backButton))
			{
				backClick = true;
			}
		}
	}//ends: OnGUI
}