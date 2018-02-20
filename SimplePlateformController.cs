using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SimplePlateformController : MonoBehaviour {

	[HideInInspector] public bool facingRight = true;
	[HideInInspector] public bool jump = true;
	public float moveForce = 365f;
	public float maxSpeed = 5f;
	public float jumpForce = 1000f;
	public Transform groundCheck;
	private bool grounded = false;
	private Animator anim;
	private Rigidbody2D rb2d;
	private bool hasalreadyjump = false;
	private bool isjumping = false;
	
	// Use this for initialization
	void Awake () {
		anim = GetComponent<Animator>();
		rb2d = GetComponent<Rigidbody2D>();
	}
	
	// Update is called once per frame
	void Update () {
		grounded = Physics2D.Linecast(transform.position, groundCheck.position, 1 << LayerMask.NameToLayer("Ground"));
		if (Input.GetButtonDown("Jump") && grounded == true){
			jump = true;
		}
		if (Input.GetButtonDown("Jump") && grounded == false){
			jump = true;
		}
	}
	

	private void StartJumping(){
		isjumping = true;
		anim.SetTrigger("Jump"); // set in the jump animation for the animator)
		rb2d.AddForce(new Vector2(0f, jumpForce));
	}
	void FixedUpdate(){
		float h = Input.GetAxis("Horizontal");
		anim.SetFloat("Speed", Mathf.Abs(h));
		if (h * rb2d.velocity.x < maxSpeed){
			rb2d.AddForce(Vector2.right * h * moveForce);
		}
		if (grounded == true){
			isjumping = false;
			hasalreadyjump = false;
		}
		if (Mathf.Abs(rb2d.velocity.x) > maxSpeed){ //sign fait 1 si positif ou -1 si negatif)
			rb2d.velocity = new Vector2 (Mathf.Sign(rb2d.velocity.x) * maxSpeed,rb2d.velocity.y);
		}
		if (h> 0 && !facingRight)
			Flip();
		else if (h< 0 && facingRight) // moving to the left && facing right)
			Flip();
		if (jump){
			if (grounded) {
				StartJumping ();
			} else if (!grounded && !hasalreadyjump && isjumping) {
				hasalreadyjump = true;
				StartJumping ();
			} else if (!grounded && !hasalreadyjump) {
				StartJumping ();
			}
			jump = false; // no double jump
		}
		
	}
	
	void Flip(){
		facingRight = !facingRight;
		Vector3 theScale = transform.localScale;
		theScale.x *= -1;
		transform.localScale = theScale;
	}
}
