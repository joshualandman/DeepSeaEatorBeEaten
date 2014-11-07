using UnityEngine;
using System.Collections;

public class EnemyMovement : MonoBehaviour {

	public float xSpeed = 0;
	public float ySpeed = 0;

	// Use this for initialization
	void Start () {

		xSpeed = Random.Range (-.1f, .1f);
		ySpeed = Random.Range (-.1f, .1f);
	
	}
	
	// Update is called once per frame
	void Update () {

		Vector2 veloc = rigidbody2D.velocity;

		Vector3 newPosition = transform.position;

		if (newPosition.x > 20 || newPosition.x < -20)
		{
			veloc.x = -veloc.x;
		}

		if (newPosition.y > 10 || newPosition.y < -10)
		{
			veloc.y = -veloc.y;
		}

		newPosition.x += xSpeed;
		newPosition.y += ySpeed;

		transform.position = newPosition;
	}
}
