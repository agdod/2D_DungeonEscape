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

	protected override void Init()
	{
		base.Init();
		destination = pointB.position;
		
	}

	public void Damage()
	{
		// If health < 1 then die (destroy)

		Health -= 1;
		inCombat = true;
		enemyAnim.SetTrigger("Hit");
		enemyAnim.SetBool("InCombat", true);
		if (Health < 1)
		{
			Debug.Log("Dead!.");
			Destroy(gameObject);
		}
	}


}
