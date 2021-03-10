using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Enemy : MonoBehaviour
{

	[Header("Common Stats.")]
	[SerializeField] protected int health;
	[SerializeField] protected int speed;
	[SerializeField] protected int gems;
	[Space]
	[Header("Waypoints")]
	[SerializeField] protected Transform pointA;
	[SerializeField] protected Transform pointB;

	

	protected abstract void Update();

	

	public virtual void Attack()
	{
		Debug.Log("BaseAttackCalled");
	}

	

}
