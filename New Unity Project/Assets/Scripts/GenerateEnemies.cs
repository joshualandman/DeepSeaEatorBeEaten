using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class GenerateEnemies : MonoBehaviour {

	float time = 0;
	float scaleMultiplier = 1;

	public GameObject player;

	public GameObject newEnemy1;
	public GameObject newEnemy2;
	public GameObject newEnemy3;
	public GameObject newEnemy4;

	List<GameObject> objects;
	List<float> sizes;

	
	List<GameObject> currentClones;

	// Use this for initialization
	void Start () {

		objects.Add (newEnemy1);
		objects.Add (newEnemy2);
		objects.Add (newEnemy3);
		objects.Add (newEnemy4);

		sizes.Add (1f);
		sizes.Add (2f);
		sizes.Add (3f);
		sizes.Add (4f);
	}
	
	// Update is called once per frame
	void Update () {

		time++;
		if(time > 600)
		{
			time = 0;

			List<int> numberOf =  new List<int>(new int[] { 2, 3, 5 });

			//Debug.Log(numberOf[0]);

			numberOf = ChooseHowMany();

			Debug.Log(objects.Count);

			for(int i = 0; i < objects.Count; i++)
			{
				for(int j = 0; j < numberOf[i]; j++)
				{
					GameObject clone = (GameObject) Instantiate(objects[i], new Vector3(Random.Range(-17f, 17f), Random.Range(-10f,10f), 0), new Quaternion(0,0,0,0));

					clone.SetActive(true);

					clone.GetComponent<Enemy>().headSize = sizes[i];
					clone.GetComponent<Enemy>().bodySize = sizes[i];

					Vector3 baseScale = player.transform.localScale;

					clone.transform.localScale = new Vector3(baseScale.x * (sizes[i]/3), baseScale.y * (sizes[i]/3), baseScale.z * (sizes[i]/3));

					currentClones.Add(clone);
				}
			}
		}
	}

	//
	List<int> ChooseHowMany()
	{
		List<int> numberOf =  new List<int>(new int[] { 2, 3, 5 });
		numberOf.Add (Random.Range (3, 7));
		numberOf.Add (Random.Range (1, 4));
		numberOf.Add (Random.Range (1, 4));
		numberOf.Add (Random.Range (1, 3));

		return numberOf;
	}
}
