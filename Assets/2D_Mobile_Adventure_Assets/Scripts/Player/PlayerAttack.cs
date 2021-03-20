using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAttack : MonoBehaviour
{
	// Varible so attack damage can only be dealt once per attack.
	private bool _canDealDamage;
	private Animator _anim;
	private Player _player;

	private void Start()
	{
		_anim = GetComponentInParent<Animator>();
		_player = GetComponentInParent<Player>();
	}

	private void Update()
	{
		if (_anim.GetCurrentAnimatorStateInfo(0).IsName("Attack_Swing") || _anim.GetCurrentAnimatorStateInfo(0).IsName("Fire_Swing"))
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
			// Debug.Log(this.name + " hit the " + other.name);
			if (_canDealDamage)
			{
				// One hit per attack.
				_canDealDamage = false;
				// Check enemy defense Rank.
				Debug.Log("enemy defense is at : " + hit.Defense);
				Debug.Log("Player Attack is at : " + _player.Attack);
				if (hit.Defense < _player.Attack)
				{
					hit.Damage();
				}
			}
		}
	}

}
