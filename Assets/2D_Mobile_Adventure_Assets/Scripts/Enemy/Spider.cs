using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spider : Enemy , IDamageable
{
	[Header("Attackable")]
	[Tooltip("The Projectile that the enemy will attack with")]
	[SerializeField] private GameObject _projectile;
	[Space]
	[Tooltip("Starting point of Projectile.")]
	[SerializeField] private Transform _origin;
	
	public int Health {
		get { return health; }
		set { health = value; }
	}
	
	protected override void Init()
	{
		base.Init();
		destination = pointB.position;
	}

	protected override void EnemyMovement()
	{
		// For now do nothign dont move.
	}

	public void Damage()
	{
		Health--;
		if (Health < 1)
		{
			Debug.Log("Death::Spider");
			Destroy(gameObject);
		}
	}

	public override void Attack()
	{
		base.Attack();
		// Instantiate the AcidEffect.
		Instantiate(_projectile, _origin.position, Quaternion.identity);
	}

}
