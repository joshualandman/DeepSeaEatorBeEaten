using UnityEngine;
using System.Collections;

public class Player : MonoBehaviour {

	public float bodySize;
	public float headSize;

	//Vectors and a float to handle movement
	public Vector3 acceleration;
	public Vector3 velocity;
	float drag;

	//A float to hold the score the player has earned
	public float score;

	// Use this for initialization
	void Start () 
	{
		//Set score to zero
		score = 0.0f;

		//Set the default value of Velocity and the permanent values of acceleration and drag
		velocity = new Vector3(0f,0f,0f);
		acceleration = new Vector3((.008f * transform.localScale.x),(.008f * transform.localScale.y),0f);
		drag = .001f;
	}
	
	// Update is called once per frame
	void Update () {

		//Move horizontally
		if(Input.GetKey(KeyCode.A) || Input.GetKey(KeyCode.LeftArrow))
		{
			//Make the player face to the left
			transform.rotation = new Quaternion(0,0,0,1);
			//Increase velocity to move to the left
			velocity.x -= acceleration.x; 

		}
		if(Input.GetKey(KeyCode.D) || Input.GetKey(KeyCode.RightArrow))
		{
			//Make the player face to the right
			transform.rotation = new Quaternion(0,180,0,1);
			//Increase velocity to move to the right
			velocity.x += acceleration.x;
		}
		//Move vertically
		if(Input.GetKey(KeyCode.W) || Input.GetKey(KeyCode.UpArrow))
		{
			//Increase the velocity to move up
			velocity.y += acceleration.y; 
			
		}
		if(Input.GetKey(KeyCode.S) || Input.GetKey(KeyCode.DownArrow))
		{
			//Increase the velocity to move down
			velocity.y -= acceleration.y;
		}

		//Move based on current velocity
		transform.position += velocity;

		//Applies a drag for the horizontal movement
		if(velocity.x > 0)
		{
			velocity.x -= drag;
		}
		else if(velocity.x < 0)
		{
			velocity.x += drag;
		}

		//Applies a drag for the vertical movement
		if(velocity.y > 0)
		{
			velocity.y -= drag;
		}
		else if(velocity.y < 0)
		{
			velocity.y += drag;
		}

		//DEBUGGING
		//Debug.Log ("transform right is " + transform.right + "   horizontal is " + horizontal);


	}
}