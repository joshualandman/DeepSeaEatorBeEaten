using UnityEngine;
using System.Collections;

public class EnemyMovement : MonoBehaviour {

	public float xSpeed = 0;
	public float ySpeed = 0;

	// Use this for initialization
	void Start () {
		Vector2 newVelocity = rigidbody2D.velocity;

		newVelocity.x = Random.Range (-3f, 3f);
		newVelocity.y = Random.Range (-2f, 2f);

		rigidbody2D.velocity = newVelocity;
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

		rigidbody2D.velocity = veloc;
	}
}
