using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class GenerateEnemies : MonoBehaviour {

	//Used to get the scale of the player when spawning new enemies
	public GameObject player;
	//Used as prefabs to generate enemies from
	public GameObject newEnemy1;
	public GameObject newEnemy2;
	public GameObject newEnemy3;
	public GameObject newEnemy4;

	public GameObject background;
	
	//Lists for all enemy prefabs and a List for the different sizes that enemies can be generated as
	List<GameObject> objects = new List<GameObject>();
	List<float> sizes = new List<float>();

	//A List for all of the current enemies on the screen
	List<GameObject> currentClones = new List<GameObject>();

	//A counter to determine if all other enemies should have their sizes reduced
	public float eatenCounter;

	public float timeCount;

	// Use this for initialization
	void Start () {
		//Adds all of the enemies prefabs to the List for prefabs
		objects.Add(newEnemy1);
		objects.Add(newEnemy2);
		objects.Add(newEnemy3);
		objects.Add(newEnemy4);
		
		//Adds all of the sizes for enemies to the List for sizes
		sizes.Add(1f);
		sizes.Add(2f);
		sizes.Add(3f);
		sizes.Add(4f);

		eatenCounter = 0;

		timeCount = 0;

		background = player.GetComponent<ScreenBound> ().background;
	}
	
	// Update is called once per frame
	void Update() {
		


		removeNull();

		if (timeCount == 80)
		{
			//An if statement to make spawning a fish between size 1 and 3 happen more often
			if(Random.Range(0,1f) < .8f)
			{
				int index = Random.Range (0, 2);
				
				SpawnEnemy (objects [index], sizes [index]);
			}
			else //Spawn a size 4 fish at a reduced rate
			{
				SpawnEnemy (objects[3], sizes[3]);
			}
			
		
			timeCount = 0;
		}

		timeCount++;
	}
	
	//A method to spawn an enemy
	void SpawnEnemy(GameObject gameObject, float size)
	{

		//A placeholder for the enemy that will be spawned
		GameObject clone;

		//The placeholder for the location to spawn
		Vector3 location = new Vector3 ();

		//Gets the scale of the player
		Vector3 baseScale = player.transform.localScale;

		//And if statement to decide which side of the screen to spawn on
		if (Random.Range(0f, 1f) > .5f)
		{
			Debug.Log ("Start Right");

			//Set the location for new enemy
			location = new Vector3(background.renderer.bounds.max.x,Random.Range(background.renderer.bounds.min.y + 3, background.renderer.bounds.max.y - 3),0);

			//create the new enemy
			clone = (GameObject) Instantiate(gameObject, location, new Quaternion());

			//Set which direction the fish should move
			clone.GetComponent<EnemyMovement>().moveLeft = true;

			//Makes the enemy rotated so they face to the left
			//clone.transform.rotation = new Quaternion(0,0,0,1);

			if(baseScale.x < 0f)
			{
				baseScale.x *= -1f;
			}
		}
		else
		{
			Debug.Log ("Start Left");

			//Set the location for new enemy
			location = new Vector3(background.renderer.bounds.min.x + gameObject.transform.localScale.x,Random.Range(background.renderer.bounds.min.y + 3, background.renderer.bounds.max.y - 3),0);
			
			//create the new enemy
			clone = (GameObject) Instantiate(gameObject, location, new Quaternion());

			//Set which direction the fish should move
			clone.GetComponent<EnemyMovement>().moveLeft = false;

			//Makes the enemy rotated so they face to the left
			//clone.transform.rotation = new Quaternion(0,180,0,1);

			if(baseScale.x > 0f)
			{
				baseScale.x *= -1f;
			}
		}

		//Sets the new enemy GameObject to active so that it will move and be seen
		clone.SetActive(true);
		
		//Sets the headSize and body size to  equal the float size, which is the appropriate size for that particular enemy prefab
		clone.GetComponent<Enemy>().headSize = size;
		clone.GetComponent<Enemy>().bodySize = size;

		//Sets the scale of the new enemy to a proportion of the player based on the float size
		clone.transform.localScale = new Vector3(baseScale.x * (size/15), baseScale.y * (size/15), baseScale.z * (size/15));
		
		//Adds the new enemy to the List for current enemies
		currentClones.Add(clone);

	}

	//A method to reduce the sizes of the enemies on screen
	public void ReduceSize()
	{
		//Checks to make sure all null enemies have been removed
		removeNull();

		//Goes through currentClones to reduce head and body size
		foreach(GameObject obj in currentClones)
		{
			if(obj.GetComponent<Enemy>().bodySize > 1)
			{
				obj.GetComponent<Enemy>().bodySize -= (1f/5);
				obj.GetComponent<Enemy>().headSize -= (1f/5);
			}
		}
	}

	//A method to remove all null enemies in currentClone
	public void removeNull()
	{
		//A for loop to remove enemies from the List currentClones if it is destroyed
		for(int i = 0; i < currentClones.Count; i++)
		{
			if(currentClones[i] == null)
			{
				currentClones.Remove(currentClones[i]);
			}
		}
	}
}
