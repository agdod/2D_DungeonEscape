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
		if (!isDead)
		{
			// if health < 1
			Health -= 1;
			inCombat = true;
			enemyAnim.SetTrigger("Hit");
			enemyAnim.SetBool("InCombat", true);
			if (Health < 1)
			{
				Debug.Log("Dead :: " + transform.name);
				inCombat = false;
				enemyAnim.SetBool("InCombat", false);
				Death();
			}
		}

	}

}
