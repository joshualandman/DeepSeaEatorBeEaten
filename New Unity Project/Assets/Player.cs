using UnityEngine;
using System.Collections;

public class Player : MonoBehaviour {

	public float RotationSpeed;
	public float ThrustForce;
	public float horizontal;
	public float vertical;

	// Use this for initialization
	void Start () {
	}
	
	// Update is called once per frame
	void Update () {
	
		horizontal = Input.GetAxis ("Horizontal");
		vertical = Input.GetAxis ("Vertical");

		rigidbody2D.angularVelocity = -horizontal * RotationSpeed;
		rigidbody2D.AddForce(transform.up * vertical * ThrustForce);

		rigidbody2D.drag = .2f;

		Debug.Log ("Speed is " + rigidbody2D.velocity);
	}

	void onCollisionEnter2D(Collision2D other)
	{
		if(other.gameObject.tag == "enemy")
		{
			Debug.Log("Collision happened!");
			Eat(other.gameObject);
		}
	}

	void Eat(GameObject gameobject)
	{
		Vector3 newScale = transform.localScale;

		newScale.x = newScale.x * 1.1f;
		newScale.y = newScale.y * 1.1f;

		transform.localScale = newScale;

		Vector3 _other = new Vector3 (Random.Range (-19f, 19f), Random.Range (-9f, 9f), 0);

		gameobject.transform.position = _other;
	}
}
