using UnityEngine;
using System.Collections;

public class GenerateBubbles : MonoBehaviour {
	//prefab to make the bubbles from
	public GameObject bubble;
	//Used to get the scale of the player when spawning new bubbles
	public GameObject player;
	public GameObject background;

	Vector3 velocity;

	//control var
	float timepast;

	// Use this for initialization
	void Start()
	{
		timepast = 0;
	}
	
	// Update is called once per frame
	void Update()
	{
		timepast += Time.deltaTime;

		//generates a bubble every 5 seconds
		if(timepast >= 1f)
		{
			//create a bubble
			GameObject clone; //placeholder for bubble
			Vector3 loc;
			Vector3 baseScale = player.transform.localScale; //player's scale
			loc = new Vector3(Random.Range(background.renderer.bounds.min.x + 20,background.renderer.bounds.max.x - 20),
			                  background.renderer.bounds.min.y,
			                  0);
			
			//instantiate the new bubble
			clone = (GameObject) Instantiate(bubble, loc, new Quaternion());

			//Set to active so that it will move and be seen
			clone.SetActive(true);
			
			//Sets the scale of the bubble
			clone.transform.localScale = new Vector3(baseScale.x/20,
			                                         baseScale.y/20,
			                                         baseScale.z/20);

			//reset the counter
			timepast = 0;
		}
	}
}