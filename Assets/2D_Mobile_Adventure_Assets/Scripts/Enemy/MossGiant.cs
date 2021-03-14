using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MossGiant : Enemy, IDamageable
{
	public int Health
	{
		get { return health; }
		set { health = value; }
	}

	protected override void Init()
	{
		base.Init();
		destination = pointB.position;
	}

	public void Damage()
	{
		// if health < 1
		Health -= 1;
		inCombat = true;
		enemyAnim.SetTrigger("Hit");
		enemyAnim.SetBool("InCombat", true);
		if (Health < 1 && !isDead)
		{
			Debug.Log("Dead :: " + transform.name);
			Death();
		}
	}

}
