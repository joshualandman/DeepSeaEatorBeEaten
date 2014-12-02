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
		//Get the head size from the parent gameobject's script Enemy
		headSize = transform.parent.gameObject.GetComponent<Enemy>().headSize;

		//Checks if the colliding GameObject is the Player
		if(other.transform.name == "Player")
		{
			//Goes through each transform object in Player's Collider
			foreach(Transform target in other.transform)
			{
				//Debug.Log("GameObject: " + other.gameObject.name + "   Transform: " + target);

				//Checks if the colliding collider is that of the body
				if(target.transform.name == "Body")
				{
					//if enemy is smaller than player, get eaten
					if(headSize > playerNum)
					{
						//Kill the Player
						//Debug.Log("You Died!!!");

						Application.LoadLevel("end");

						//Destroy(player);
					}
				}
			}
		}
	}
}
