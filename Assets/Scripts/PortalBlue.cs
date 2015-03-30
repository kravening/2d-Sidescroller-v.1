using UnityEngine;
using System.Collections;

public class PortalBlue : MonoBehaviour {

	public float speed;
	private Rigidbody2D rb2D;
	public GameObject bluePortal;
	public GameObject[] portalArrayBlue;
	private bool portalExists;

	//public LevelManager levelManager;
	
	// Use this for initialization
	void Start () {
		
		rb2D = GetComponent<Rigidbody2D> ();
		//levelManager = FindObjectOfType<LevelManager>();
		
	}
	
	// Update is called once per frame
	void Update () {

		/*if(Input.GetKeyDown(KeyCode.R){
			DestroyPortalBlue();
			Destroy(portalArrayBlue[1]);

		}*/
		
		//portalArray = GameObject.FindGameObjectsWithTag ("OrangePortal");// as GameObject[];
		
	}
	
	void FixedUpdate() {
		
		rb2D.AddRelativeForce (Vector2.up * speed, ForceMode2D.Impulse);
		
		
	}
	
	void OnTriggerEnter2D(Collider2D other){

		if (other.tag == "Walls") {
			Destroy (gameObject);
			
		}
		
		if (other.tag == "PortalWalls") {
			
			Destroy (gameObject);
			portalArrayBlue = GameObject.FindGameObjectsWithTag ("BluePortal");
			Transform tBlue = Instantiate (bluePortal, transform.position, transform.rotation) as Transform;

			if(portalArrayBlue[0].tag == "BluePortal")
			{
				DestroyPortalBlue();
			}
		}
	}
	
	void DestroyPortalBlue(){
		
		Destroy(portalArrayBlue[0]);
		
	}

}
