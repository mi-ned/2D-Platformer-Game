using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//References
//https://www.youtube.com/watch?v=AD4JIXQDw0s
//https://github.com/Brackeys/Boss-Battle
//This animation class is a part of a state machine for the final boss. If the boss enters the 2nd wave of attack (under a threshold) the boss will rage
//here on the enter state, the boss' body goes red, and goes in the same direction as the player
//on the exit state, the boss' invulnerability wanes off
public class Boss_Enrage : StateMachineBehaviour
{
	// OnStateEnter is called when a transition starts and the state machine starts to evaluate this state
	override public void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
	{
		animator.GetComponent<bossHealth>().isInvulnerable = true;
	}

	// OnStateUpdate is called on each Update frame between OnStateEnter and OnStateExit callbacks
	override public void OnStateUpdate(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
	{

	}

	// OnStateExit is called when a transition ends and the state machine finishes evaluating this state
	override public void OnStateExit(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
	{
		animator.GetComponent<bossHealth>().isInvulnerable = false;
	}
}
