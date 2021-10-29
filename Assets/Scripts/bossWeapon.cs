using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

//References:
//https://www.youtube.com/watch?v=AD4JIXQDw0s
//https://github.com/Brackeys/Boss-Battle
//This class determines how much damage that the boss can do to the player
public class bossWeapon : MonoBehaviour
{
    public float attackDamage; //Sets up the amount of damage that a player can take
	public float enragedAttackDamage; //Sets up the threshold of how much pain the boss can take before he changes behaviour
	public Vector3 attackOffset; //Depending on what behaviour the boss is in, the offset will be set to certain places
	public float attackRange; //Sets up the attack range, depending on how far the player is away from the boss
	public LayerMask attackMask; //Makes sure that the attack mask matches that to the player's mask (i.e. Player)

	public void Attack() { //The first of two attack behaviours, the boss will slash his sword depending on where the player is located
		Vector3 pos = transform.position; //Determines where the player is within the vicinity of the boss.
		pos += transform.right * attackOffset.x;
		pos += transform.up * attackOffset.y;
		Collider2D colInfo = Physics2D.OverlapCircle(pos, attackRange, attackMask); //Depending on how the attack area was set up, the boss will make atacks

		if (colInfo != null) { //if the player gets attacked, the damage gets added to the player. Without this if statement, the player wouldn't feel a single health being dropped
			colInfo.GetComponent<playerHealth>().addDamage(attackDamage); //if the player gets hit, then damage will be added to that player
		}
	}

	public void EnragedAttack() { //The second of two attack behaviours, the boss will slash his sword uncontrollably
		Vector3 pos = transform.position; //Determines where the player is within the vicinity of the boss.
		pos += transform.right * attackOffset.x;
		pos += transform.up * attackOffset.y;
		Collider2D colInfo = Physics2D.OverlapCircle(pos, attackRange, attackMask); //Depending on how the attack area was set up, the boss will make atacks

		if (colInfo != null) { //if the player gets attacked, the damage gets added to the player. Without this if statement, the player wouldn't feel a single health being dropped
			colInfo.GetComponent<playerHealth>().addDamage(enragedAttackDamage); //if the player gets hit, then damage will be added to that player
		}
	}

	void OnDrawGizmosSelected() { //The way in which the attack would work is that the sword would be swinging within the circle that was drawn
		Vector3 pos = transform.position;  //Determines where the player is within the vicinity of the boss.
		pos += transform.right * attackOffset.x;
		pos += transform.up * attackOffset.y;
		Gizmos.DrawWireSphere(pos, attackRange); //The circle would be drawn, and the sword will be swinging within that circle. The circle is movable within the boss
	}
}
