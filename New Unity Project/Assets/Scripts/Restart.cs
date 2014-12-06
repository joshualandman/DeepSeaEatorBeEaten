using UnityEngine;
using System.Collections;

public class Restart : MonoBehaviour {



	void Start()
	{
		GameObject.Find ("FinalScoreText").GetComponent<TextMesh> ().text = "Final Score: " + GameObject.Find ("GameObject").GetComponent<ScoreKeeper> ().score;
	}

	void Update()
	{
		RaycastHit2D hit = Physics2D.Raycast(Camera.main.ScreenToWorldPoint(Input.mousePosition),Vector2.zero);

		//if the mouse is over a button
		if(hit.collider != null)
		{
			//death screen
				//restart button
			if(hit.collider.name == "Restart")//hover
			{
				if(Input.GetMouseButtonDown(0))//click
				{
					Application.LoadLevel("Menu");
				}
			}
		}
	}
}