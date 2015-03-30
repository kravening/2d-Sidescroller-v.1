using UnityEngine;
using System.Collections;

public class PlayerController : MonoBehaviour
{

	public float moveSpeed;
	public float jumpHeight;
	public Transform groundCheck;
	public float groundCheckRadius;
	public LayerMask whatIsGround;
	public LevelManager levelManager;


	//private Portal portal;
	private bool onGround;
	private bool isIdle;
	private bool isJump;
	private bool isDoubleJump;
	private bool isWalking;
	private bool isRespawn;
	private Animator animationController;

	// Use this for initialization
	void Start ()
	{
		levelManager = FindObjectOfType<LevelManager> ();
		animationController = GetComponent<Animator> ();
	
	}

	void FixedUpdate ()
	{
		onGround = Physics2D.OverlapCircle (groundCheck.position, groundCheckRadius, whatIsGround);
	}
	
	// Update is called once per frame
	void Update ()
	{
		//animations are triggered through a boolean, here it sends either "true" or "false" either of wich can be a trigger but in this case triggering only occurs when it's true
		animationController.SetBool ("isJumping", isJump);
		animationController.SetBool ("isDoubleJump", isDoubleJump);
		animationController.SetBool ("isWalking", isWalking);
		animationController.SetBool ("isIdle", isIdle);
		animationController.SetBool ("isDoubleJump", isDoubleJump);
		animationController.SetBool ("isJumping", isJump);

		if (isDoubleJump == true || isJump == true) {
			isWalking = false;
		}

		if (onGround) { //If colliding with the ground you can either be walking or idle but not jumping, also resets double jump counter
			isDoubleJump = false;
			isJump = false;
			animationController.SetBool ("isRespawn", isRespawn);
		}

		if (Input.anyKeyDown || Input.anyKey) { //reads for a key input
			isIdle = false;

			if (Input.GetKey (KeyCode.Space)) { //runs this part if space is pressed

				if (Input.GetKeyDown (KeyCode.Space) && onGround) { //runs this part if space is pressed and is not touching the ground
					isJump = true;
					GetComponent<Rigidbody2D> ().velocity = new Vector2 (GetComponent<Rigidbody2D> ().velocity.x, jumpHeight);
					animationController.SetBool ("isJumping", isJump);
					GetComponent<AudioSource>().Play();
				}

				if (Input.GetKeyDown (KeyCode.Space) && !isDoubleJump && !onGround) { //runs this part if space is pressed after jumping and is not touching ground
					isJump = false;
					isDoubleJump = true;
					GetComponent<Rigidbody2D> ().velocity = new Vector2 (GetComponent<Rigidbody2D> ().velocity.x, jumpHeight); // this is what makes it jump
					animationController.SetBool ("isDoubleJump", isDoubleJump);
					GetComponent<AudioSource>().Play();
				}

			}


			if (Input.GetKey (KeyCode.A) || Input.GetKey (KeyCode.D)) { //checks if input is either a/d to confirm if player is walking
				isWalking = true;
				animationController.SetBool ("isWalking", isWalking);

				if (Input.GetKey (KeyCode.D)) {
					GetComponent<Rigidbody2D> ().velocity = new Vector2 (moveSpeed, GetComponent<Rigidbody2D> ().velocity.y); //this piece makes the player move right
				}

				if (Input.GetKey (KeyCode.A)) {
					GetComponent<Rigidbody2D> ().velocity = new Vector2 (-moveSpeed, GetComponent<Rigidbody2D> ().velocity.y); //this piece makes the player move left by adding the "-" before movespeed
				}

			} 
		} else { //if no keys are pressed the player is obviously "idle"
			isWalking = false;
			isIdle = true;
		}
	
	}

	void OnTriggerEnter2D (Collider2D other)
	{
		
		if (other.tag == "isKill") {
			isRespawn = true;
			animationController.SetBool ("isRespawn", isRespawn);
			isRespawn = false;
			Debug.Log("banaan");
		}
	}
}
