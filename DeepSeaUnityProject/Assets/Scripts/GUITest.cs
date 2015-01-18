using UnityEngine;
using System.Collections;

public class GUITest : MonoBehaviour {
	//insert player to use
	public Player player;

	void OnGUI()
	{
		GUI.Box ( new Rect (10, 20, 200, 90), "Player:"); // display player
		GUI.Label ( new Rect (20, 50, 200, 20), "Score: " + player.score); // display number of pillow
	}
}