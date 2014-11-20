using UnityEngine;
using System.Collections;

public class Restart : MonoBehaviour {
	//button texture
	public Texture2D endButton;

	void OnGUI()
	{
		//restart the game
		if(GUI.Button(new Rect(220,427,414f,142f),endButton))
		{
			Application.LoadLevel("testMenu");
		}
	}
}