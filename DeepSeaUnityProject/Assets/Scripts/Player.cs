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

	public Animator anim;

	bool facingRight = false;

	// Use this for initialization
	void Start () 
	{
		//Set score to zero
		score = 0.0f;

		//Set animator component
		anim = GameObject.Find("Player").GetComponent<Animator>();

		//Set the default value of Velocity and the permanent values of acceleration and drag
		velocity = new Vector3(0f,0f,0f);
		acceleration = new Vector3((.002f * transform.localScale.x),(.002f * transform.localScale.y),0f);
		drag = .0005f;

		maxYVelocity = .06f;
		maxXVelocity = .06f;
	}

	void FixedUpdate()
	{
		//Make the playe rmove
		Swimming();

		//Get which direction the player wants to move
		float move = Input.GetAxis("Horizontal");

		//Flips the player fish based on the direction the player wants to move
		if(move < 0 && !facingRight)
			Flip();
		else if(move > 0 && facingRight)
			Flip();

		//if the player wins
		if(score >= 60)
			Application.LoadLevel("win");

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
		//Set boolean for animation
		if(velocity.sqrMagnitude > (acceleration*2).sqrMagnitude){
			anim.SetBool("swimming", true);
		}
		else{
			anim.SetBool("swimming", false);
		}

		
		//Move based on current velocity
		transform.position += velocity;
		
		//Applies a drag for the horizontal movement
		if(velocity.x > 0)
		{ velocity.x -= drag; }
		else if(velocity.x < 0)
		{ velocity.x += drag; }
		
		//Applies a drag for the vertical movement
		if(velocity.y > 0)
		{ velocity.y -= drag; }
		else if(velocity.y < 0)
		{ velocity.y += drag; }
	}

	//Method to end bite animation, called through the animator component
	public void endBiteAnim(){
		anim.SetBool("hasEaten", false);
	}
}