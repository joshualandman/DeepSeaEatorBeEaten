using UnityEngine;
using System.Collections;

public class Eat : MonoBehaviour {

	//declare player and enemy and their size numbers

	float playerNum = 0.0f;
	float enemyNum = 0.0f;

	void Start()
	{

		//set player equal to player and set his size
		playerNum = transform.parent.GetComponent<Player>().bodySize;

	}
	
	void OnCollisionEnter2D(Collision2D other)
	{

		//If the player is colliding into something other than the top-sea or sea-bed gameobject then continue
		if(other.gameObject.name != "top-sea" && other.gameObject.name != "sea-bed")
		{
			//Get the size of the enemy gameobect the player is colliding with
			enemyNum = other.gameObject.GetComponent<Enemy>().bodySize;

			//Debug.Log(enemyNum);

			//loop through the transforms in other
			foreach(Transform target in other.transform)
			{
				//find the child that we want
				if(target.gameObject.name == "body")
				{
					//if enemy is smaller than player, get eaten
					if(enemyNum < playerNum)
					{

						//Debug.Log("Enemy: " + enemyNum + " Player: " + playerNum);
						eatEnemy(target.gameObject);
						Destroy(other.gameObject);
					}
				}

				/*if(enemyHeadNum < playerHeadNum)
				{
					
					Debug.Log("Enemy: " + enemyHeadNum + " Player: " + playerHeadNum);
					eatEnemy(target.gameObject);
					Destroy(other.gameObject);
				}*/
			}
		}
	}
	
	void eatEnemy(GameObject gameobject)
	{
		//Adds the enemy size to the player's score
		transform.parent.gameObject.GetComponent<Player>().score += (int)enemyNum;

		//Adds the enemy size to a counter to determine if all other enemies on the screen should have their size decreased
		//GameObject.Find ("Background").GetComponent<GenerateEnemies>().eatenCounter += enemyNum;

		//Adds the enemy size to a counter to determine if all other enemies on the screen should have their size decreased
		GameObject.Find ("Background").GetComponent<GenerateEnemies> ().ReduceSize ();

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

		//Increase the acceleration of the player as he grows
		GameObject.Find("Player").GetComponent<Player>().drag *=  ((30f + enemyNum) / 30f);
	}
}
