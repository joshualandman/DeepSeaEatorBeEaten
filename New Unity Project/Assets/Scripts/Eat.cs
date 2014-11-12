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
		enemyNum = other.gameObject.GetComponent<Enemy>().bodySize;

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
	
	void eatEnemy(GameObject gameobject)
	{
		//save player scale
		Vector3 newScale = transform.parent.localScale;

		//enlarge scale by rel num
		newScale.x = newScale.x * 1.06f;
		newScale.y = newScale.y * 1.06f;

		//change player's scale to new scale
		transform.parent.localScale = newScale;
	}
}
