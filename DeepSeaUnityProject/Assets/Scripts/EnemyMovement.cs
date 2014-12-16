using UnityEngine;
using System.Collections;

public class EnemyMovement : MonoBehaviour {
	public Vector3 velocity;
	public Vector3 acceleration;
	float maxSpeed;
	float minDist;

	//A boolean to say which direction the enemy should try to swim
	public bool moveLeft;

	//Player to seek or run away from
	public GameObject player;

	// Use this for initialization
	void Start ()
	{
		//Swim to the left
		if(moveLeft)
		{
			//Makes the enemy move to the left
			velocity = new Vector3(-.12f * transform.localScale.y,0,0);
		}
		else //Swim to the right
		{
			//Makes then enemy move to the right
			velocity = new Vector3(.12f * transform.localScale.y,0,0);
		}
		
		//control variables
		acceleration = new Vector3(0,0);

		maxSpeed = 0.15f * transform.localScale.y;

		player = GameObject.Find ("Player");
	}
	
	// Update is called once per frame
	void Update ()
	{
		Swim ();

		if(GetComponent<Enemy>().headSize < player.GetComponent<Player>().headSize)
		{
			Evade();
		}
		else if(GetComponent<Enemy>().headSize > player.GetComponent<Player>().headSize)
		{
			//Debug.Log(GetComponent<Enemy>().headSize);
			//Debug.Log(player.GetComponent<Player>().headSize);

			//Start trying to seek
			//Debug.Log(GetComponent<Enemy>().transform.position);
			Seek();
		}

		if(velocity.x > 0f)
		{
			if(moveLeft)
			{
				moveLeft = !moveLeft;
				Vector3 scale = transform.localScale;
				scale.x *= -1f;
				transform.localScale = scale;
			}
		}
		else if(velocity.x < 0f)
		{
			if(!moveLeft)
			{
				moveLeft = !moveLeft;
				Vector3 scale = transform.localScale;
				scale.x *= -1f;
				transform.localScale = scale;
			}
		}
	}

	void Swim()
	{
		velocity += acceleration;

		//Move the enemy
		transform.position += velocity;

		//An if statement to tell when to destroy an enemy whose swam off the background
		if(transform.position.x < GameObject.Find("Main Camera").GetComponent<GenerateEnemies>().background.renderer.bounds.min.x|| transform.position.x > GameObject.Find("Main Camera").GetComponent<GenerateEnemies>().background.renderer.bounds.max.x)
		{
			//Destroy this Gameobject of it swims off screen
			Destroy(transform.gameObject);

			//remove this enemy from the list currentClones in GenerateEnemies
			GameObject.Find ("Main Camera").GetComponent<GenerateEnemies> ().removeNull ();
		}
	}

	//Seek the player
	void Seek()
	{
		//Find the distance from the enemy to the player
		float diffX = player.transform.position.x - transform.position.x;
		float diffY = player.transform.position.y - transform.position.y;

		float dist = Mathf.Sqrt (diffX * diffX + diffY * diffY);

		//Set the minimum distance to the player when to start seeking
		minDist = player.transform.localScale.y * 5;

		//An if statement to see when to seek
		if( dist < minDist)
		{
			//Set the velocity
			Vector3 desired = Vector3.Normalize (player.transform.position - transform.position) * maxSpeed;
			Vector3 steer = desired - velocity;
			velocity += steer;
		}
	}

	void Evade()
	{
		//Find the distance from the enemy to the player
		float diffX = player.transform.position.x - transform.position.x;
		float diffY = player.transform.position.y - transform.position.y;
		
		float dist = Mathf.Sqrt (diffX * diffX + diffY * diffY);

		//Set the minimum distance to the player when to start seeking
		minDist = player.transform.localScale.y * 5;

		//An if statement to see when to seek
		if( dist < minDist)
		{
			//Set the velocity
			Vector3 desired = Vector3.Normalize (player.transform.position - transform.position) * (maxSpeed);
			desired *= -1;
			Vector3 steer = desired - velocity;
			velocity += steer;
		}
	}
}