using UnityEngine;
using System.Collections;

public class RestartButton : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	void OnGUI()
	{
		if(GUI.Button(new Rect((Screen.width / 2) - 157, (Screen.height / 2) + 80, 314f, 85f),"Restart"))
		{
			Application.LoadLevel("testMenu");
		}
	}
}
