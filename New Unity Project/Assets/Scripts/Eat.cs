using UnityEngine;
using System.Collections;

public class Eat : MonoBehaviour {

	//declare player and enemy and their size numbers
	GameObject player;
	GameObject enemy;
	float playerNum = 0.0f;
	float enemyNum = 0.0f;

	void Start()
	{
		//Set initial value of enemy
		enemy = new GameObject ();

		//set player equal to player and set his size
		player = GameObject.Find("Player");
		playerNum = player.GetComponent<Player>().bodySize;

	}
	
	void OnCollisionEnter2D(Collision2D other)
	{

		//set enemy equal to enemy and set his size
		enemy = GameObject.Find(other.gameObject.name);

		//If the player is colliding into something other than the top-sea or sea-bed gameobject then continue
		if(enemy.name != "top-sea" && enemy.name != "sea-bed")
		{
			//Get the size of the enemy gameobect the player is colliding with
			enemyNum = enemy.GetComponent<Enemy>().bodySize;

			//loop through the transforms in other
			foreach(Transform target in other.transform)
			{
				//find the child that we want
				if(target.gameObject.name == "body")
				{
					//if enemy is smaller than player, get eaten
					if(enemyNum < playerNum)
					{
						eatEnemy(target.gameObject);
						Destroy(other.gameObject);
					}
				}
			}
		}
	}
	
	void eatEnemy(GameObject gameobject)
	{
		//Adds the enemy size to the player's score
		transform.parent.gameObject.GetComponent<Player>().score += enemyNum;

		//Adds the enemy size to a counter to determine if all other enemies on the screen should have their size decreased
		GameObject.Find ("Background").GetComponent<GenerateEnemies>().eatenCounter += enemyNum;

		//save player scale
		Vector3 newScale = transform.parent.localScale;

		//enlarge scale by rel num
		newScale.x = newScale.x * ((30f + enemyNum) / 30f);
		newScale.y = newScale.y * ((30f + enemyNum) / 30f);

		//change player's scale to new scale
		transform.parent.localScale = newScale;

		//Scale the camera's view
		GameObject.Find ("Main Camera").camera.orthographicSize *= ((30f + enemyNum) / 30f);

		//Increase the acceleration of the player as he grows
		GameObject.Find("Player").GetComponent<Player>().acceleration *=  ((30f + enemyNum) / 30f);
	}
}
