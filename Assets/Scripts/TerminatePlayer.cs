using UnityEngine;
using System.Collections;

public class TerminatePlayer : MonoBehaviour {

	public LevelManager levelManager;
	
	// Use this for initialization
	void Start () {
		levelManager = FindObjectOfType<LevelManager>();

	}
	
	// Update is called once per frame
	void Update () {
	
	}

	void OnTriggerEnter2D(Collider2D other) {
		
		if (other.name == "Player") 
		{
			Debug.Log(levelManager);
			levelManager.RespawnPlayer();
			GetComponent<AudioSource>().Play();

		}


		
	}


}
