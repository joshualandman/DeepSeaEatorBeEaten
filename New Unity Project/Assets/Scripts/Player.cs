using UnityEngine;
using System.Collections;

public class Player : MonoBehaviour {

	public float bodySize;
	public float headSize;

	//Vectors and a float to handle movement
	public Vector3 acceleration;
	public Vector3 velocity;
	public float drag;

	public float maxYVelocity;
	public float maxXVelocity;

	//A float to hold the score the player has earned
	public float score;

	bool facingRight = false;

	// Use this for initialization
	void Start () 
	{
		//Set score to zero
		score = 0.0f;

		//Set the default value of Velocity and the permanent values of acceleration and drag
		velocity = new Vector3(0f,0f,0f);
		acceleration = new Vector3((.002f * transform.localScale.x),(.001f * transform.localScale.y),0f);
		drag = .00001f;

		maxYVelocity = .5f;
		maxXVelocity = .1f;
	}

	void FixedUpdate()
	{
		Swimming ();

		float move = Input.GetAxis ("Horizontal");

		if(move < 0 && !facingRight)
			Flip();
		else if(move > 0 && facingRight)
			Flip();
	}

	void Flip()
	{
		facingRight = !facingRight;
		Vector3 theScale = transform.localScale;
		theScale.x *= -1;
		transform.localScale = theScale;
	}

	void Swimming()
	{
		//Move horizontally
		if(Input.GetKey(KeyCode.A) || Input.GetKey(KeyCode.LeftArrow))
		{
			if(velocity.x >= -maxXVelocity)
			{
				//Increase velocity to move to the left
				velocity.x -= acceleration.x;
			}
		}
		if(Input.GetKey(KeyCode.D) || Input.GetKey(KeyCode.RightArrow))
		{
			if(velocity.x <= maxXVelocity)
			{
				//Increase velocity to move to the right
				velocity.x += acceleration.x;
			}
		}
		//Move vertically
		if(Input.GetKey(KeyCode.W) || Input.GetKey(KeyCode.UpArrow))
		{
			if(velocity.y <= maxYVelocity)
			{
				//Increase the velocity to move up
				velocity.y += acceleration.y; 
			}
		}
		if(Input.GetKey(KeyCode.S) || Input.GetKey(KeyCode.DownArrow))
		{
			if(velocity.y >= -maxYVelocity)
			{
				//Increase the velocity to move down
				velocity.y -= acceleration.y; 
			}
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
	}


}