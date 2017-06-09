using UnityEngine;
using System.Collections;

public class player_controller_script : MonoBehaviour {
	
	public LayerMask groundLayer;
	
	public GameObject groundCheck;
	public float distToGround;

	public LayerMask enemyLayer;

	// Use this for initialization
	void Start () {

	}
	
	// Update is called once per frame
	void Update () {

		distToGround = transform.position.y - groundCheck.transform.position.y;	
		bool ground = isGrounded();
		Game.Data.Mecha.Animator.SetBool("Grounded", ground);
		if(!ground && !Game.Data.Paused && !Game.Data.bullet) {
			Game.Data.Mecha.RigidBody.AddForce(Physics2D.gravity * Game.Data.globalSpeed);
		}

		if(Game.Data.Mecha.aiming) {
			if(Input.touchCount > 0) {
				if(Input.GetTouch(0).phase == TouchPhase.Began) {
					if(!Game.Data.bullet) {
						if(Input.GetTouch(0).position.x > Screen.width/2) {

							GameObject target = null;

							GameObject mira = GameObject.FindGameObjectWithTag("mira");
							if(mira != null) {
								mira_script mir = mira.GetComponent<mira_script>();
								if(mir != null) {
									target = mir.target;
								}
							}

							if(target != null)  {

								if(Game.Data.Mecha.timeToResetCombo > 0) {

									if(Game.Data.Mecha.combo == 2) {
										Game.Data.Mecha.Animator.SetBool("Charging3", true);
										Game.Data.Mecha.wasGrounded = ground;
										Game.Data.Mecha.timeToResetCombo = 1;
										Game.Data.shake = 0.2f;
									}else if(target.transform.position.y > Game.Data.Mecha.Root.transform.position.y) {
										Game.Data.Mecha.Animator.SetBool("Charging1", true);
										Game.Data.Mecha.wasGrounded = ground;
										Game.Data.Mecha.timeToResetCombo = 1;
									} else {
										Game.Data.Mecha.Animator.SetBool("Charging2", true);
										Game.Data.Mecha.wasGrounded = ground;
										Game.Data.Mecha.timeToResetCombo = 1;
									}
								} else {
									Game.Data.Mecha.Animator.SetBool("Charging", true);
									Game.Data.Mecha.wasGrounded = ground;
									Game.Data.Mecha.timeToResetCombo = 1;
								}
							}
						}
					}
				}
			}
			
			if(Input.GetKeyDown(KeyCode.Z)) {

				GameObject target = null;
				
				GameObject mira = GameObject.FindGameObjectWithTag("mira");
				if(mira != null) {
					mira_script mir = mira.GetComponent<mira_script>();
					if(mir != null) {
						target = mir.target;
					}
				}
				
				if(target != null)  {
					
					if(Game.Data.Mecha.timeToResetCombo > 0) {
						
						if(Game.Data.Mecha.combo == 2) {
							Game.Data.Mecha.Animator.SetBool("Charging3", true);
							Game.Data.Mecha.wasGrounded = ground;
							Game.Data.Mecha.timeToResetCombo = 1;
							Game.Data.shake = 0.2f;
						}else if(target.transform.position.y > Game.Data.Mecha.Root.transform.position.y) {
							Game.Data.Mecha.Animator.SetBool("Charging1", true);
							Game.Data.Mecha.wasGrounded = ground;
							Game.Data.Mecha.timeToResetCombo = 1;
						} else {
							Game.Data.Mecha.Animator.SetBool("Charging2", true);
							Game.Data.Mecha.wasGrounded = ground;
							Game.Data.Mecha.timeToResetCombo = 1;
						}
					} else {
						Game.Data.Mecha.Animator.SetBool("Charging", true);
						Game.Data.Mecha.wasGrounded = ground;
						Game.Data.Mecha.timeToResetCombo = 1;
					}
				}
			}
		}
		
		if(Game.Data.Mecha.recovery) {
			SpriteRenderer ren = Game.Data.Mecha.Root.gameObject.GetComponent<SpriteRenderer>();
			if(ren != null) {
				Color col = ren.color;
				col.a = 0.5f;
				ren.color = col;
			}
		} else {
			SpriteRenderer ren = Game.Data.Mecha.Root.gameObject.GetComponent<SpriteRenderer>();
			if(ren != null) {
				Color col = ren.color;
				col.a = 1;
				ren.color = col;
			}
		}
	}

	bool isGrounded() {
//		if(Game.Data.Mecha.RigidBody.velocity.y <= 0) {
			RaycastHit2D hit = Physics2D.Raycast(this.transform.position, new Vector2(0,-1), distToGround, groundLayer);
			if(hit.collider != null) {
				this.transform.position = new Vector2(this.transform.position.x, hit.point.y + distToGround);
				Game.Data.Mecha.RigidBody.velocity = new Vector2(0,0);
				Debug.DrawLine(this.transform.position, groundCheck.transform.position,Color.red);
				return true;
			} else {
				Debug.DrawLine(this.transform.position, groundCheck.transform.position,Color.green);
				return false;
			}
//		} else {
//			return false;
//		}

	}

	public void Attack() {
		if(Game.Data.Mecha.target != null) {

			Game.Data.Mecha.combo++;

			bullet_enemy_script bullet = Game.Data.Mecha.target.GetComponent<bullet_enemy_script>();
			robot_destrroy_script destroy = Game.Data.Mecha.target.GetComponent<robot_destrroy_script>();
			if(bullet != null) {
				bullet.Enter();
			} else  if(destroy != null) {
				if(SoundController.Data != null) {
					int ran = Random.Range(0,3);
					switch(ran) {
					case 0:
						SoundController.Data.AudioSources["espada_som_1"].Play();
						break;
					case 1:
						SoundController.Data.AudioSources["espada_som_2"].Play();
						break;
					case 2:
						SoundController.Data.AudioSources["espada_som_3"].Play();
						break;
					}
					
				}
				destroy.Explode();
			} else {
				if(SoundController.Data != null) {
					int ran = Random.Range(0,3);
					switch(ran) {
					case 0:
						SoundController.Data.AudioSources["espada_som_1"].Play();
						break;
					case 1:
						SoundController.Data.AudioSources["espada_som_2"].Play();
						break;
					case 2:
						SoundController.Data.AudioSources["espada_som_3"].Play();
						break;
					}
					
				}
				Destroy(Game.Data.Mecha.target.gameObject);
				Game.Data.Mecha.target = null;
			}
		}
		if(!Game.Data.Mecha.wasGrounded) {
			Game.Data.Mecha.RigidBody.velocity = new Vector2(0, 25);
		}
	}

	public void OnTriggerEnter2D(Collider2D coll) {
		if(coll.gameObject.tag  == "inimigo" && !Game.Data.Mecha.invencible && !Game.Data.Mecha.recovery) {
			Game.Flash();
			Game.Data.Mecha.health -= 1;
			Game.Data.Mecha.recovery = true;
			Game.Data.Mecha.timeRecovery = 2;
			Game.Data.Mecha.combo = 0;
			Game.Data.shake = 0.4f;
		}
	}
}
