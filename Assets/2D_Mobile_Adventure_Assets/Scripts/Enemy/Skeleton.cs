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
		// Assign Health property to our enemy health.
	}

	public void Damage()
	{
		Debug.Log("Damage!");
		// Subtract 1
		// If health < 1then die (destroy)
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
