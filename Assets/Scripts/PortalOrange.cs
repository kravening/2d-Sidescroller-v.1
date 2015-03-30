using UnityEngine;
using System.Collections;

public class PortalOrange : MonoBehaviour {

	public float speed;
	private Rigidbody2D rb2D;
	public GameObject orangePortal;
	public GameObject[] portalArrayOrange;
	private bool portalExists;
	//private LevelManager levelManager;


	// Use this for initialization
	void Start () {

		rb2D = GetComponent<Rigidbody2D> ();
		//levelManager = FindObjectOfType<LevelManager>();
	
	}
	
	// Update is called once per frame
	void Update () {

		/*if(Input.GetKeyDown(KeyCode.R){
			DestroyPortalOrange();
			Destroy(portalArrayOrange[1]);
			
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
			
			portalArrayOrange = GameObject.FindGameObjectsWithTag ("OrangePortal");
			Transform tOrange = Instantiate (orangePortal, transform.position, transform.rotation) as Transform;

			if(portalArrayOrange[0].tag == "OrangePortal")
			{
				DestroyPortalOrange();
			}

		}
	}

	void DestroyPortalOrange(){
		
		Destroy(portalArrayOrange[0]);
		
	}
}
