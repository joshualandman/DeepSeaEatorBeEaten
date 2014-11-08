using UnityEngine;
using System.Collections;

public class Player : MonoBehaviour {

	public float RotationSpeed;
	public float ThrustForce;
	float horizontal = 0;
	float vertical = 0;
	public float bodySize;
	public float headSize;

	// Use this for initialization
	void Start () 
	{
		//Vector2 velocity = new Vector2.zero();
		//Vector2 position = transform.position;
		//Vector2 acceleration = new Vector2(0,1);;
	}
	
	// Update is called once per frame
	void Update () {
	
		horizontal = Input.GetAxis ("Horizontal");
		vertical = Input.GetAxis ("Vertical");

		//rigidbody2D.angularVelocity = -horizontal * RotationSpeed;
		rigidbody2D.AddForce(transform.right * horizontal * ThrustForce);
		rigidbody2D.AddForce(transform.up * vertical * ThrustForce);

		rigidbody2D.drag = .2f;

		//Debug.Log ("Speed is " + rigidbody2D.velocity);


		//if(Input.GetKey

	}
}