using UnityEngine;
using System.Collections;

public class player_charge_state : StateMachineBehaviour {

	public GameObject target;
	public GameObject shadow;


	 // OnStateEnter is called when a transition starts and the state machine starts to evaluate this state
	override public void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex) {
		Game.Data.Mecha.invencible = true;
		animator.SetBool("Charging", false);
		animator.SetBool("Charging1", false);
		animator.SetBool("Charging2", false);
		animator.SetBool("Charging3", false);
		GameObject mira = GameObject.FindGameObjectWithTag("mira");
		if(mira != null) {
			mira_script mir = mira.GetComponent<mira_script>();
			if(mir != null) {
				target = mir.target;
			}
			Game.Data.Mecha.target = target;
		} else {
			animator.SetBool("Break", true);
		}

	}

	// OnStateUpdate is called on each Update frame between OnStateEnter and OnStateExit callbacks
	override public void OnStateUpdate(Animator animator, AnimatorStateInfo stateInfo, int layerIndex) {

		Game.Spawn(shadow, Game.Data.Mecha.Root.transform.position, Quaternion.identity);

		Vector3 res = Vector3.Lerp(animator.gameObject.transform.position, target.gameObject.transform.position, 0.15f);
		Game.Data.Mecha.Root.transform.position = res;

		if(Vector3.Distance(Game.Data.Mecha.Root.transform.position, target.transform.position) < 3) {
			animator.SetBool("Attack", true);
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
