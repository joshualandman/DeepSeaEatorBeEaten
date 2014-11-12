using UnityEngine;
using System.Collections;

public class Enemy : MonoBehaviour {

	//declare player and enemy and their size numbers
	GameObject player;
	GameObject enemy;
	float playerNum = 0.0f;
	public float bodySize;
	public float headSize;
	
	void Start()
	{
		//set player equal to player and set his size
		player = GameObject.Find("Player");
		playerNum = player.GetComponent<Player>().bodySize;
	}

	void OnCollisionEnter2D(Collision2D other)
	{
		if(other.transform.name == "Player")
		{
			foreach(Transform target in other.transform)
			{
				if(target.transform.name == "pBody")
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
