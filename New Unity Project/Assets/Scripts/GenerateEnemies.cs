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
	
	//Lists for all enemy prefabs and a List for the different sizes that enemies can be generated as
	List<GameObject> objects = new List<GameObject>();
	List<float> sizes = new List<float>();

	//A List for all of the current enemies on the screen
	List<GameObject> currentClones = new List<GameObject>();

	//A counter to determine if all other enemies should have their sizes reduced
	public float eatenCounter;

	// Use this for initialization
	void Start () {
		//Adds all of the enemies prefabs to the List for prefabs
		objects.Add (newEnemy1);
		objects.Add (newEnemy2);
		objects.Add (newEnemy3);
		objects.Add (newEnemy4);
		
		//Adds all of the sizes for enemies to the List for sizes
		sizes.Add (1f);
		sizes.Add (2f);
		sizes.Add (3f);
		sizes.Add (4f);

		eatenCounter = 0;
	}
	
	// Update is called once per frame
	void Update () {
		
		//An if statement to tell when to spawn more enemies
		if(CheckEatenAllSmall())
		{
			SpawnWave();
		}

		//A for loop to remove enemies from the List currentClones if it is destroyed
		for(int i = 0; i < currentClones.Count; i++)
		{
			if(currentClones[i] == null)
			{
				currentClones.Remove(currentClones[i]);
			}
		}

		//An if statement to see if enemies should have their sizes decreased
		if(eatenCounter >= 10)
		{
			ReduceSize();
			eatenCounter -= 10;
		}
	}
	
	//A method to generate a wave of new enemies
	void SpawnWave()
	{
		//A List for amount of enemies that should be spawned per size
		List<int> numberOf =  new List<int>();
		//Call ChooseHowMany which populates the List with random numbers
		numberOf = ChooseHowMany();
		
		//A for loop that goes through the List for prefabs
		for(int i = 0; i < objects.Count; i++)
		{
			//A for loop that instantiates a new enemy x number of times, where x = numberOf[i]
			for(int j = 0; j < numberOf[i]; j++)
			{
				//Calls the method SpawnEnemy
				SpawnEnemy(objects[i], sizes[i]);
			}
		}
	}
	
	//A method to spawn an enemy
	void SpawnEnemy(GameObject gameObject, float size)
	{
		//Instantiates a new enemy from the prefab gameObject within the boundary of x = (-17,17) and y = (-10,10)
		GameObject clone = (GameObject) Instantiate(gameObject, new Vector3(Random.Range(-24f, 24f), Random.Range(-13f,13f), 0), new Quaternion(0,0,0,0));
		//Sets the new enemy GameObject to active so that it will move and be seen
		clone.SetActive(true);
		
		//Sets the headSize and body size to  equal the float size, which is the appropriate size for that particular enemy prefab
		clone.GetComponent<Enemy>().headSize = size;
		clone.GetComponent<Enemy>().bodySize = size;
		
		//Gets the scale of the player
		Vector3 baseScale = player.transform.localScale;
		
		//Sets the scale of the new enemy to a proportion of the player based on the float size
		clone.transform.localScale = new Vector3(baseScale.x * (size/3), baseScale.y * (size/3), baseScale.z * (size/3));
		
		//Adds the new enemy to the List for current enemies
		currentClones.Add(clone);
	}

	//A method to get a List of random integers between ranges
	List<int> ChooseHowMany()
	{
		//A List of integers
		List<int> numberOf =  new List<int>();
		//Adds four random numbers to the List
		numberOf.Add (Random.Range (4, 8));
		numberOf.Add (Random.Range (3, 5));
		numberOf.Add (Random.Range (1, 3));
		numberOf.Add (Random.Range (1, 2));
		//Return the List
		return numberOf;
	}

	//A method to reduce the sizes of the enemies on screen
	void ReduceSize()
	{
		foreach(GameObject obj in currentClones)
		{
			obj.GetComponent<Enemy>().bodySize -= 1;
			obj.GetComponent<Enemy>().headSize -= 1;
		}
	}

	//A method to check if all of the size one and two fish have been eaten
	bool CheckEatenAllSmall()
	{
		foreach(GameObject obj in currentClones)
		{
			if(obj.GetComponent<Enemy>().bodySize < 3)
			{
				return false;
			}
		}

		return true;
	}
}
