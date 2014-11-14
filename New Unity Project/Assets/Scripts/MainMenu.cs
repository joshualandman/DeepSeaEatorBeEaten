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


		//Main menu GUI
		if(main == true)
		{
			//if the player wants to start the game
			if(GUI.Button(new Rect((Screen.width / 2) - 325, (Screen.height / 2) + 125, 315f, 85f),startButton))
			{
				startClick = true;
			}
			//if the player wants to see the instructions
			else if(GUI.Button(new Rect((Screen.width / 2) + 10, (Screen.height / 2) + 125, 315f, 85f),instructButton))
			{
				instructClick = true;
			}
		}
		//Instructions GUI
		else
		{
			//if the player wants to leave the instructions menu
			if(GUI.Button(new Rect((Screen.width / 2) + 126, (Screen.height / 2) + 235, 165f, 95f),backButton))
			{
				backClick = true;
			}
		}
	}//ends: OnGUI
}
