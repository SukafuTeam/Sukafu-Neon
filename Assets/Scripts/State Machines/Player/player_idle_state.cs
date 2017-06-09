using UnityEngine;
using System.Collections;

public class player_idle_state : StateMachineBehaviour {
	
	public float jumpForce;

	 // OnStateEnter is called when a transition starts and the state machine starts to evaluate this state
	override public void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex) {
		animator.SetBool("Break", false);	
		Game.Data.Mecha.invencible = false;
	}

	// OnStateUpdate is called on each Update frame between OnStateEnter and OnStateExit callbacks
	override public void OnStateUpdate(Animator animator, AnimatorStateInfo stateInfo, int layerIndex) {

		if(Game.Data.Mecha.Root.transform.position.x > 0) {
			Vector3 pos = Game.Data.Mecha.Root.transform.position;
			pos.x -= 0.5f;
			Game.Data.Mecha.Root.transform.position = pos;
		}

		if(Input.touchCount > 0) {
			if(Input.GetTouch(0).position.x < Screen.width/2) {
				animator.SetBool("Jump", true);
				Game.Data.Mecha.RigidBody.AddForce(new Vector2(0, jumpForce));
			}
		}

		if(Input.GetKeyDown(KeyCode.Space)) {
			animator.SetBool("Jump", true);
			Game.Data.Mecha.RigidBody.AddForce(new Vector2(0, jumpForce));
		}

	}
	
	// OnStateExit is called when a transition ends and the state machine finishes evaluating this state
	//override public void OnStateExit(Animator animator, AnimatorStateInfo stateInfo, int layerIndex) {
	//
	//}

	// OnStateMove is called right after Animator.OnAnimatorMove(). Code that processes and affects root motion should be implemented here
	//override public void OnStateMove(Animator animator, AnimatorStateInfo stateInfo, int layerIndex) {
	//
	//}

	// OnStateIK is called right after Animator.OnAnimatorIK(). Code that sets up animation IK (inverse kinematics) should be implemented here.
	//override public void OnStateIK(Animator animator, AnimatorStateInfo stateInfo, int layerIndex) {
	//
	//}
}


