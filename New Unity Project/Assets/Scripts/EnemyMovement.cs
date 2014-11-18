using UnityEngine;
using System.Collections;

public class EnemyMovement : MonoBehaviour {
	
	Vector3 velocity = new Vector2(0,0);
	Vector3 acceleration;
	Vector2 pos;
	float maxSpeed;
	float maxForce; 
	float mass = 10f; //arbitrary value will alter acceleration
	public GameObject background;

	//A boolean to say which direction the enemy should try to swim
	public bool moveLeft;

	// Use this for initialization
	void Start ()
	{
		//set initial velocity
		velocity = new Vector3(0,0);
		
		//control variables
		acceleration = new Vector3(0,0);
		pos = transform.position;
		maxSpeed = 0.1f;
		maxForce = 0.1f;
	}
	
	// Update is called once per frame
	void Update ()
	{
		/*CalcSteeringForce();
		velocity += acceleration;
		velocity = Vector2.ClampMagnitude(velocity, maxSpeed);
		pos += velocity;
		transform.position = pos;
		acceleration *= 0;*/
		//Debug.Log(background.renderer.bounds.min.x);

		Swim ();
	}

	void Swim()
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

		//Move the enemy
		transform.position += velocity;

		//An if statement to tell when to destroy an enemy whose swam off screen
		if(moveLeft)
		{
			if(transform.position.x < -37)
			{
				//Destroy this Gameobject of it swims off screen
				Destroy(transform.gameObject);
				//remove this enemy from the list currentClones in GenerateEnemies
				GameObject.Find ("Background").GetComponent<GenerateEnemies> ().removeNull ();
			}
		}
		else
		{
			if(transform.position.x > 37)
			{
				//Destroy this Gameobject of it swims off screen
				Destroy(transform.gameObject);
				//remove this enemy from the list currentClones in GenerateEnemies
				GameObject.Find ("Background").GetComponent<GenerateEnemies> ().removeNull ();
			}
		}


	}
	
	/*void CalcSteeringForce()
	{
		Vector2 force = new Vector2(0,0);
		
		if(Offstage())
		{
			force += Seek(new Vector2(0,0)) * 10;
		}
		
		force = Vector2.ClampMagnitude(force, maxForce);
		acceleration += force/mass;
	}
	
	bool Offstage()
	{
		bool off = false;
		if(transform.position.x < background.renderer.bounds.min.x)
			off = true;
		else if(transform.position.x > background.renderer.bounds.max.x)
			off = true;
		else if(transform.position.y < background.renderer.bounds.min.y)
			off = true;
		else if(transform.position.y > background.renderer.bounds.max.y)
			off = true;
		
		return off;
	}
	
	Vector2 Seek(Vector2 target)
	{
		Vector2 desired;
		desired.x = target.x - transform.position.x;
		desired.y = target.y - transform.position.y;
		desired.Normalize();
		desired = desired * maxSpeed;
		Vector2 steer = desired - rigidbody2D.velocity;
		return steer;
	}*/
}