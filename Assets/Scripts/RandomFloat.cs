using UnityEngine;
using System.Collections;

public class RandomFloat : MonoBehaviour {

	public float randomFloatMax = 0f;
	public float randomFloatMin = 0f;

	private Particle particleController;

	// Use this for initialization
	void Start () {

		//particleController = GetComponent<ParticleSystem>;
	
	}
	
	// Update is called once per frame
	void FixedUpdate () {
		Random.Range (randomFloatMin, randomFloatMax);



	
	}
}
