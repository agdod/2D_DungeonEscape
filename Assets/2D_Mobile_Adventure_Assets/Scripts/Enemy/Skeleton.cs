using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Skeleton : Enemy, IDamageable
{
	public int Health
	{
		get { return health; }
		set { health = value; }
	}

	public int Defense
	{
		get { return defense; }
	}

	protected override void Init()
	{
		base.Init();
		destination = pointB.position;

	}

	public void Damage()
	{
		// If health < 1 then die (destroy)
		if (!isDead)
		{
			Health -= 1;
			inCombat = true;
			enemyAnim.SetTrigger("Hit");
			enemyAnim.SetBool("InCombat", true);
			if (Health < 1 && !isDead)
			{
				Debug.Log("Dead!.");
				inCombat = false;
				enemyAnim.SetBool("InCombat", false);
				Death();
			}
		}

	}


}
