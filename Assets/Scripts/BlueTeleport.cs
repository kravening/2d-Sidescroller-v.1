using UnityEngine;
using System.Collections;

public class BlueTeleport : MonoBehaviour {

	public LevelManager levelManager;
	public int delay;
	// Use this for initialization
	void Start () {
		levelManager = FindObjectOfType<LevelManager>();
		levelManager.currentBluePortal = this.gameObject;
		
	}
	
	// Update is called once per frame
	void Update () {

		/*if (Input.GetKey(KeyCode.R)) {
			{
				Destroy(gameObject);
			}*/
	
	}

	void OnTriggerEnter2D(Collider2D other) {

		if (other.tag == "PortalWalls") {
			Debug.Log("Blue hit portal wall");
		}
		
		if (other.name == "Player") 
		{
			if(delay == 0){
			Debug.Log ("Touching Blue Portal");
			levelManager.BlueToOrange();
			}
		}
		
		
		
	}


}
