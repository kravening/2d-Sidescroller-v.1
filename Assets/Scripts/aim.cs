using UnityEngine;
using System.Collections;

public class aim : MonoBehaviour {
	public Transform firePoint;
	public GameObject bluePortal;
	public GameObject orangePortal;
	public float speed;
	private Transform adjustedAngle;


	//private Portal portal;

	void Update ()
	{


		//rotation
		Vector3 mousePos = Input.mousePosition;
		mousePos.z = 30;
		
		Vector3 objectPos = Camera.main.WorldToScreenPoint (transform.position);
		mousePos.x = mousePos.x - objectPos.x;
		mousePos.y = mousePos.y - objectPos.y;
		
		float angle = Mathf.Atan2(mousePos.y, mousePos.x) * Mathf.Rad2Deg;
		transform.rotation = Quaternion.Euler(new Vector3(0, 0, angle));

		if(Input.GetMouseButtonDown(0)) //left mouse click
		{

			transform.rotation *= Quaternion.Euler(0, 0, -90);
			Instantiate(bluePortal, firePoint.position, transform.rotation);
			GetComponent<AudioSource>().Play();

		}
		
		if(Input.GetMouseButtonDown(1)) //right mouse click
		{
			transform.rotation *= Quaternion.Euler(0, 0, -90);
			Instantiate(orangePortal, firePoint.position, transform.rotation);
			GetComponent<AudioSource>().Play();
			
		}
	}

	//Transform GetTransform(){
	//	return transform;
	//}
}
