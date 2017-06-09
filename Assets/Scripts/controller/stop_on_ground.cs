using UnityEngine;
using System.Collections;

public class stop_on_ground : MonoBehaviour {

	public LayerMask groundLayer;
	
	public GameObject groundCheck;
	public float distToGround;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
		distToGround = transform.position.y - groundCheck.transform.position.y;	
		bool ground = isGrounded();

		Animator animator = this.gameObject.GetComponent<Animator>();
		Rigidbody2D rig = this.gameObject.GetComponent<Rigidbody2D>();

		if(animator != null) {
			animator.speed = Game.Data.globalSpeed;
			animator.SetBool("Grounded", ground);
		}

		if(!ground && !Game.Data.Paused && rig != null) {
			rig.AddForce(Physics2D.gravity * Game.Data.globalSpeed);
		}
	}

	bool isGrounded() {
		RaycastHit2D hit = Physics2D.Raycast(this.transform.position, new Vector2(0,-1), distToGround, groundLayer);
		if(hit.collider != null) {
			this.transform.position = new Vector2(this.transform.position.x, hit.point.y + distToGround);
			Rigidbody2D rig = this.gameObject.GetComponent<Rigidbody2D>();
			if(rig != null) {
				rig.velocity = new Vector2(0,0);
			}
			return true;
		} else {
			return false;
		}
	}
}
