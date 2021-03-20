using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Animator))]
public class InteracterableObject : MonoBehaviour, IDamageable
{
	[SerializeField] private Animator _anim;
	[SerializeField] private int _defense;

	public int Defense
	{
		get { return _defense; }
	}

	[HideInInspector]
	public int Health { get; set; }

	private void Start()
	{
		_anim = GetComponent<Animator>();
	}

	public void Damage()
	{
		_anim.SetTrigger("BreakIt");
	}


}
