using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spider : Enemy
{
	private Vector3 _destination;
	private Animator _enemyAnim;
	private SpriteRenderer _enemySprite;
	private bool _flip;


	private void Start()
	{
		// Get componets for enemy.
		_enemyAnim = GetComponentInChildren<Animator>();
		if (_enemyAnim == null)
		{
			Debug.LogError("No Animator Component found on " + name);
		}
		_enemySprite = GetComponentInChildren<SpriteRenderer>();
		if (_enemySprite == null)
		{
			Debug.LogError("No Sprite Renderer found on " + name);
		}
		_destination = pointB.position;
	}

	protected override void Update()
	{
		EnemyUpdate();
	}

	private void EnemyMovement()
	{
		// Move enemy between points A & B.

		transform.position = Vector3.MoveTowards(transform.position, _destination, speed * Time.deltaTime);
		/* On arrival at destination point
		 * Change destination point,
		 * Trigger Idle animation
		 * Set flip to true
		 */
		if (Vector3.Distance(transform.position, _destination) < 0.1f)
		{
			if (_destination == pointA.position)
			{
				_enemyAnim.SetTrigger("Idle");
				_destination = pointB.position;
				_flip = true;
			}
			else if (_destination == pointB.position)
			{
				_enemyAnim.SetTrigger("Idle");
				_destination = pointA.position;
				_flip = true;
			}
		}		
	}

	private void EnemyUpdate()
	{
		// If enemy is idle, do nothing.
		if (_enemyAnim.GetCurrentAnimatorStateInfo(0).IsName("Idle"))
		{
			return;
		}
		if (_flip)
		{
			_enemySprite.flipX = !_enemySprite.flipX;
			_flip = false;
		}
		EnemyMovement();
	}
}
