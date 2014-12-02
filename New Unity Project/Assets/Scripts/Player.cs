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
		acceleration = new Vector3((.008f * transform.localScale.x),(.008f * transform.localScale.y),0f);
		drag = .0001f;

		maxYVelocity = .2f;
		maxXVelocity = .3f;
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
			//Increase velocity to move to the left
			velocity.x -= acceleration.x;
			
			//Keep the horizontal velocity to a maximum			
			if(velocity.x < -maxXVelocity)
			{
				velocity.x = -maxXVelocity;
			}
			
		}
		if(Input.GetKey(KeyCode.D) || Input.GetKey(KeyCode.RightArrow))
		{
			//Increase velocity to move to the right
			velocity.x += acceleration.x;
			
			//Keep the horizontal velocity to a maximum			
			if(velocity.x > maxXVelocity)
			{
				velocity.x = maxXVelocity;
			}
		}
		//Move vertically
		if(Input.GetKey(KeyCode.W) || Input.GetKey(KeyCode.UpArrow))
		{
			//Increase the velocity to move up
			velocity.y += acceleration.y; 
			
			//Keep the vertical velocity to a maximum			
			if(velocity.y > maxYVelocity)
			{
				velocity.y = maxYVelocity;
			}
		}
		if(Input.GetKey(KeyCode.S) || Input.GetKey(KeyCode.DownArrow))
		{
			//Increase the velocity to move down
			velocity.y -= acceleration.y; 
			
			//Keep the vertical velocity to a maximum			
			if(velocity.y < -maxYVelocity)
			{
				velocity.y = -maxYVelocity;
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