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

	protected Vector3 destination;
	protected Animator enemyAnim;
	protected SpriteRenderer enemySprite;
	protected bool flip;

	private void Start()
	{
		// Important componenets for enemy class. 
		enemyAnim = GetComponentInChildren<Animator>();
		if (enemyAnim == null)
		{
			Debug.LogError("No Animator Component found on " + name);
		}
		enemySprite = GetComponentInChildren<SpriteRenderer>();
		if (enemySprite == null)
		{
			Debug.LogError("No Sprite Renderer found on " + name);
		}
		Init();
	}

	protected virtual void Init()
	{
		// Use for Custom Start Initalistion of enemys.
	}

	protected virtual void Update()
	{
		// If enemy is idle, do nothing.
		if (enemyAnim.GetCurrentAnimatorStateInfo(0).IsName("Idle"))
		{
			return;
		}
		if (flip)
		{
			enemySprite.flipX = !enemySprite.flipX;
			flip = false;
		}
		EnemyMovement();
	}

	protected virtual void EnemyMovement()
	{
		// Enemy Base Movement.
		// Move enemy between points A & B.

		transform.position = Vector3.MoveTowards(transform.position, destination, speed * Time.deltaTime);
		/* On arrival at destination point
		 * Change destination point,
		 * Trigger Idle animation
		 * Set flip to true
		 */
		if (Vector3.Distance(transform.position, destination) < 0.1f)
		{
			if (destination == pointA.position)
			{
				enemyAnim.SetTrigger("Idle");
				destination = pointB.position;
				flip = true;
			}
			else if (destination == pointB.position)
			{
				enemyAnim.SetTrigger("Idle");
				destination = pointA.position;
				flip = true;
			}
		}
	}

	public virtual void Attack()
	{
		Debug.Log("BaseAttackCalled");
	} 

}
