using UnityEngine;
using System.Collections;

public class GenerateEnemies : MonoBehaviour {

	float time = 0;

	public GameObject newEnemy;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {

		time++;
		if(time > 120)
		{
			time = 0;

			Instantiate(newEnemy, new Vector3(Random.Range(-17f, 17f), Random.Range(-10f,10f), 0), new Quaternion(0,0,0,0));

		}
		
	}
}
