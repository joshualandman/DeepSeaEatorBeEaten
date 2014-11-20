using UnityEngine;
using System.Collections;

public class EnemyMovement : MonoBehaviour {
	
	public Vector3 velocity;
	public Vector3 acceleration;
	float maxSpeed; 

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
			velocity = new Vector3(-.03f,0,0);
		}
		else //Swim to the right
		{
			//Makes then enemy move to the right
			velocity = new Vector3(.03f,0,0);
		}
		
		//control variables
		acceleration = new Vector3(0,0);

		maxSpeed = 0.1f;
	}
	
	// Update is called once per frame
	void Update ()
	{

		Swim ();

		if(GetComponent<Enemy>().headSize < player.GetComponent<Player>().headSize)
		{
			//Evade();
		}
		else if(GetComponent<Enemy>().headSize > player.GetComponent<Player>().headSize)
		{
			//Debug.Log("Start trying to seek");
			//Start trying to seek
			//Seek();
		}
	}

	void Swim()
	{
		//
		velocity += acceleration;

		//Move the enemy
		transform.position += velocity;

		//An if statement to tell when to destroy an enemy whose swam off screen
		if(transform.position.x < -38 || transform.position.x > 38)
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
		float minDist = transform.localScale.x * 30;

		//An if statement to see when to seek
		if( dist < minDist)
		{
			Debug.Log("Actively seeking");
			//Set the velocity
			acceleration = new Vector3(diffX/20, diffY/20,0);
		}

	}

	void Evade()
	{

	}
}