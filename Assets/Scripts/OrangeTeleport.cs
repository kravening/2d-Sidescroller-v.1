using UnityEngine;
using System.Collections;

public class OrangeTeleport : MonoBehaviour {

	// Use this for initialization
	public LevelManager levelManager;
	public int delay;
	// Use this for initialization
	void Start () {
		levelManager = FindObjectOfType<LevelManager>();
		levelManager.currentOrangePortal = this.gameObject;
	}
	
	// Update is called once per frame
	void Update () {

		/*if (Input.GetKey (KeyCode.R)) {
		{
			Destroy(gameObject);
		}*/
		
	}
	
	void OnTriggerEnter2D(Collider2D other) {

		if (other.tag == "PortalWalls") {
			Debug.Log("Orange hit portal wall");
		}

		if (other.name == "Player") 
		{
			if(delay == 0){
			Debug.Log ("Touching Orange Portal");
			levelManager.OrangeToBlue();

			}
		}



	}

 public	IEnumerator coolDown(){
 		yield return new WaitForSeconds(2);
		delay = 0;

	}
}
