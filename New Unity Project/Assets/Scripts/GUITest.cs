using UnityEngine;
using System.Collections;

public class GUITest : MonoBehaviour {

	//insert player to use
	public Player player;

	void OnGUI()
	{
		GUI.Box ( new Rect (10, 20, 200, 90), "Player:"); // display player
		GUI.Label ( new Rect (20, 50, 200, 20), "Score: " + player.score); // display number of pillow

		if(player.score >= 50)
		{
		
			GUI.Box ( new Rect ((Screen.width/2) - 100, (Screen.height/2) + 45, 200, 90), "You Won!"); // display player
		
		}
	}
}
