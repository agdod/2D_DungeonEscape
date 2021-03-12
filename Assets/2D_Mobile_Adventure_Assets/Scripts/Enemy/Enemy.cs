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
	protected bool inCombat;
	protected GameObject player;


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
		player = GameObject.FindGameObjectWithTag("Player");
		Init();
	}

	protected virtual void Init()
	{
		// Use for Custom Start Initalistion of enemys.
	}

	protected virtual void Update()
	{
		// If enemy is idle, do nothing.
		if (enemyAnim.GetCurrentAnimatorStateInfo(0).IsName("Idle") && enemyAnim.GetBool("InCombat") == false)
		{
			return;
		}
		if (flip)
		{
			enemySprite.flipX = !enemySprite.flipX;
			flip = false;
		}

		if (!inCombat)
		{
			EnemyMovement();
		}
		// If enemy is in combat mode check that player is in range
		else if (inCombat && PlayerInRange())
		{
			FacePlayer();
		}
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

	protected virtual void FacePlayer()
	{
		Vector3 direction = player.transform.position - transform.position;
		if (direction.x > 0)
		{
			// Player on right on enemy
			// check which way enemy is facing.
			if (enemySprite.flipX == true)
			{
				// Enemy is facing to the left - Flip the enemy.
				enemySprite.flipX = false;
			}
		}
		else if (direction.x < 0)
		{
			// Player on left of enemy
			if (enemySprite.flipX == false)
			{
				// Enemy is facing right - Flip the enemy
				enemySprite.flipX = true;
			}
		}
	}

	public virtual void Attack()
	{
		Debug.Log("BaseAttackCalled");
	}

	private bool PlayerInRange()
	{
		float distance = Vector3.Distance(transform.position, player.transform.position);
		if (Vector3.Distance(transform.position, player.transform.position) > 2)
		{
			// Player is out of range
			inCombat = false;
			enemyAnim.SetBool("InCombat", false);
			return false;
		}
		else
		{
			return true;
		}
	}
}
