using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MossGiant : Enemy
{
	[SerializeField] Vector3 _destination;
	
	private Animator _enemyAnim;
	private SpriteRenderer _enemySprite;
	private bool _flip;


	private void Start()
	{
		_enemyAnim = GetComponentInChildren<Animator>();
		if (_enemyAnim == null)
		{
			Debug.LogError("No Aniamtor component found on " + name);
		}

		_enemySprite = GetComponentInChildren<SpriteRenderer>();
		if (_enemySprite == null)
		{
			Debug.LogError("No 2D Sprite Render found on " + name);
		}
		_destination = pointB.position;
	}

	protected override void Update()
	{
		// If idle do nothing.
		if (_enemyAnim.GetCurrentAnimatorStateInfo(0).IsName("Idle"))
		{
			return;
		}
		if (_flip)
		{
			_enemySprite.flipX = !_enemySprite.flipX;
			_flip = false;
		}
		MoveMossGaint();
	}

	void MoveMossGaint()
	{
		// move MoseGiant between points A,B
		float step = speed * Time.deltaTime;
		transform.position = Vector3.MoveTowards(transform.position, _destination, step);
		if (Vector3.Distance(transform.position, _destination) < 0.1f)
		{
			/* On arrival at destination point
			 * Change destination point,
			 * Trigger Idle animation
			 * Set flip to true
			 */
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
	
}
