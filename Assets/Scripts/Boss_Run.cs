using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Boss_Run : StateMachineBehaviour
{

	public float speed = 2.5f; //speed of the boss
	public float attackRange = 3f; //attack range
	public Transform player; //transform player so that the other animations are visible
	Rigidbody2D myRB; //rigidbody is active
	bossController boss; //calls the bossController class when required

    // OnStateEnter is called when a transition starts and the state machine starts to evaluate this states
    override public void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
		if(GameObject.FindGameObjectWithTag("Player") != null){ //makes sure that the player is alive. if not, the level restarts as normal
		player = GameObject.FindGameObjectWithTag("Player").transform; 
		}
		myRB = animator.GetComponent<Rigidbody2D>();
		boss = animator.GetComponent<bossController>();

	
}

	// OnStateUpdate is called on each Update frame between OnStateEnter and OnStateExit callbacks
	override public void OnStateUpdate(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
	{
		boss.LookAtPlayer();  //makes sure that the player is alive. if not, the level restarts as normal
		if(player == null){
			return;
		}
		Vector2 target = new Vector2(player.position.x, myRB.position.y);
		Vector2 newPos = Vector2.MoveTowards(myRB.position, target, speed * Time.fixedDeltaTime);
		myRB.MovePosition(newPos);

		if (Vector2.Distance(player.position, myRB.position) <= attackRange)
		{
			animator.SetTrigger("Attack");
		}
	}

	// OnStateExit is called when a transition ends and the state machine finishes evaluating this state
	override public void OnStateExit(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
	{
		animator.ResetTrigger("Attack");
	}
}
