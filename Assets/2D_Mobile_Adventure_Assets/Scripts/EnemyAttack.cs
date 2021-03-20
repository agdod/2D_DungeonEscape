using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyAttack : MonoBehaviour
{
	// Varible so attack damage can only be dealt once per attack.
	private bool _canDealDamage;
	private Animator _anim;

	private void Start()
	{
		_anim = GetComponentInParent<Animator>();
	}

	private void Update()
	{
		if (_anim.GetCurrentAnimatorStateInfo(0).IsName("Attack") || _anim.GetCurrentAnimatorStateInfo(0).IsName("AcidShot"))
		{
			return;
		}
		// on exit set candealdamge to true.
		else
		{
			_canDealDamage = true;
		}
	}

	private void OnTriggerEnter2D(Collider2D other)
	{

		if (other.TryGetComponent(out IDamageable hit))
		{
			// Check if Player is dead.
			// If dead stop attacking.
			if (other.TryGetComponent(out Player player))
			{
				if (player.isDead)
				{
					_canDealDamage = false;
					Enemy enemy = GetComponentInParent<Enemy>();
					if (enemy != null)
					{
						enemy.StopAttacking();
					}
				}
			}
			// Debug.Log(this.name + " hit the " + other.name);
			if (_canDealDamage)
			{
				// One hit per attack.
				_canDealDamage = false;
				hit.Damage();
			}
		}

	}

}
