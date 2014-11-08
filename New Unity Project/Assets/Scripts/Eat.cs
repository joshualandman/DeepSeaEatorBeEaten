using UnityEngine;
using System.Collections;

public class Eat : MonoBehaviour {

	GameObject player;
	GameObject enemy;
	float playerNum;
	float enemyNum;

	void Start()
	{
		player = GameObject.Find("Player");
		playerNum = player.GetComponent<Player>().bodySize;
	}
	
	void OnCollisionEnter2D(Collision2D other)
	{		
		enemy = GameObject.Find(other.gameObject.name);
		enemyNum = other.gameObject.GetComponent<EnemyMovement>().bodySize;

		foreach(Transform target in other.transform)
		{
			if(target.gameObject.name == "body")
			{
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
		Vector3 newScale = transform.parent.localScale;
		
		newScale.x = newScale.x * 1.06f;
		newScale.y = newScale.y * 1.06f;
		
		transform.parent.localScale = newScale;
	}
}
