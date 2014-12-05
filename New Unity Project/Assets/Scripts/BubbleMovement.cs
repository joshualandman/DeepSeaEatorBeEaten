using UnityEngine;
using System.Collections;

public class BubbleMovement : MonoBehaviour {
	float maxSpeed;
	Vector3 velocity;

	// Use this for initialization
	void Start () {
		velocity = new Vector3(0,.6f * transform.localScale.y,0);
		maxSpeed = 0.15f * transform.localScale.y;
	}
	
	// Update is called once per frame
	void Update () {
		transform.position += velocity;

		//Destroy this Gameobject of it swims off screen
		if(transform.position.y > GameObject.Find("Main Camera").GetComponent<GenerateBubbles>().background.renderer.bounds.max.y + 50)
		{ Destroy(transform.gameObject); }
	}
}