using UnityEngine;
using System.Collections;

public class EnemyEat : MonoBehaviour {

	GameObject player;
	float playerNum = 0.0f;
	float headSize = 0.0f;

	// Use this for initialization
	void Start () {
		//set player equal to player and set his size
		player = GameObject.Find("Player");
		playerNum = player.GetComponent<Player>().bodySize;
	}
	
	// Update is called once per frame
	void Update () {
	


	}

	void OnCollisionEnter2D(Collision2D other)
	{
		headSize = GetComponent<Enemy>().headSize;

		if(other.transform.name == "Player")
		{
			
			foreach(Transform target in other.transform)
			{
				Debug.Log("GameObject: " + other.gameObject.name + "   Transform: " + target);
				
				if(target.transform.name == "body")
				{
					//if enemy is smaller than player, get eaten
					if(headSize > playerNum)
					{
						Debug.Log("ADQWEQWEQ");
						//Destroy(player);
					}
				}
			}
		}
	}
}
