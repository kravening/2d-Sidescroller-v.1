using UnityEngine;
using System.Collections;

public class Doors : MonoBehaviour
{

	private Animator animationController;
	private bool doorIdle;
	private bool playerEnter;

	// Use this for initialization
	void Start ()
	{

		animationController = GetComponent<Animator> ();

		doorIdle = true;
		playerEnter = false;
		
		animationController.SetBool ("DoorIdle", doorIdle);
		animationController.SetBool ("PlayerEnter", playerEnter);


	
	}
	
	// Update is called once per frame
	void Update ()
	{
	
	}

	void OnTriggerEnter2D (Collider2D other)
	{

			doorIdle = false;
			playerEnter = true;

			animationController.SetBool ("DoorIdle", doorIdle);
			animationController.SetBool ("PlayerEnter", playerEnter);

	}

	void OnTriggerExit2D  (Collider2D other)
	{
		doorIdle = true;
		playerEnter = false;
		
		animationController.SetBool ("DoorIdle", doorIdle);
		animationController.SetBool ("PlayerEnter", playerEnter);

	}

}

