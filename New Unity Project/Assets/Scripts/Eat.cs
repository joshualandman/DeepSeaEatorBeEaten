using UnityEngine;
using System.Collections;

public class Eat : MonoBehaviour {


	void OnCollisionEnter2D(Collision2D other)
	{
		foreach(Transform target in other.transform)
		{ 

			if(target.gameObject.name == "fangtoothbody")
			{ 
				eatEnemy(target.gameObject);
				Destroy(other.gameObject);
			} 
		}
	}
	
	void eatEnemy(GameObject gameobject)
	{
		Vector3 newScale = transform.parent.localScale;
		
		newScale.x = newScale.x * 1.1f;
		newScale.y = newScale.y * 1.1f;
		
		transform.parent.localScale = newScale;
	}
}
