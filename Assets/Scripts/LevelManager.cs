using UnityEngine;
using System.Collections;

public class LevelManager : MonoBehaviour {

	public GameObject currentCheckpoint;
	public GameObject currentOrangePortal;
	public GameObject currentBluePortal;
	private PlayerController player;
	private PortalBlue portalB;
	private PortalOrange portalO;

	// Use this for initialization
	void Start ()
	{
		player = FindObjectOfType<PlayerController>();
	
	}
	
	// Update is called once per frame
	void Update ()
	{
	
	}

	public void RespawnPlayer()
	{
		player.transform.position = currentCheckpoint.transform.position;
		Debug.Log ("respawned");
	}

	public void BlueToOrange()
	{
		Debug.Log(currentBluePortal);
		GetComponent<AudioSource>().Play();
		currentBluePortal = GameObject.FindWithTag("BluePortal");
		player.transform.position = currentOrangePortal.transform.position;
		currentOrangePortal.GetComponent<OrangeTeleport>().delay = 1;
		StartCoroutine(coolDown());

		Debug.Log ("blue");

	}

	public void OrangeToBlue()
	{
	
		Debug.Log(currentBluePortal);
		GetComponent<AudioSource>().Play();
		currentBluePortal = GameObject.FindWithTag("BluePortal");
		player.transform.position = currentBluePortal.transform.position;
		currentBluePortal.GetComponent<BlueTeleport>().delay = 1;
		StartCoroutine(coolDown());
		Debug.Log ("Orange");

	}

	public	IEnumerator coolDown(){
		yield return new WaitForSeconds(1);
		currentBluePortal.GetComponent<BlueTeleport>().delay = 0;
		currentOrangePortal.GetComponent<OrangeTeleport>().delay = 0;
		
	}
}
