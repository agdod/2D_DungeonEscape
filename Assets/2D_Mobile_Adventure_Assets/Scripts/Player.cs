using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
public class Player : MonoBehaviour
{
	
	[Header("Player Control Stats")]
	[Space]
	[Tooltip("Value controlling the focre applied on jumping.")]
	[Range(0f, 5f)]
	[SerializeField] private float _jumpForce;
	[Range(0f, 10f)]
	[SerializeField] private float _speed;
	[Tooltip("Allows for error for groud tolerance")]
	[Range(-1.0f, 1.0f)]
	[SerializeField] private float _isGroundedOffset;
	[Space]
	[Header("Player Components.")]
	[Space]
	[Tooltip("The Rigidbody Component of the Player.")]
	[SerializeField] private Rigidbody2D _rigidBody2D;
	[Tooltip("the Sprite Renderer of the Player.")]
	[SerializeField] private SpriteRenderer _spriteRenderer;
	[Tooltip("Script responsible for animation control.")]
	[SerializeField] private PlayAnimation _playAnimation;
	
	[Space]
	[SerializeField] private LayerMask _groundLayerMask;

	private float _horizontal;

	void Start()
	{
		// Do null checks on components
		_rigidBody2D = GetComponent<Rigidbody2D>();
	}

	void Update()
	{
		if (IsGrounded())
		{
			MovePlayer();
		}
	}

	private void Flip(float dir)
	{
		if (dir > 0)
		{
			_spriteRenderer.flipX = false;
		}
		else if (dir < 0)
		{
			_spriteRenderer.flipX = true;
		}
	}

	private void MovePlayer()
	{
		// Get horizontal movment
		_horizontal = Input.GetAxisRaw("Horizontal");
		Flip(_horizontal);
		// if move > 0 then facing right
		//	else if < 0 then facing left

		
		// Check for jump input, jump status
		if (Input.GetKeyDown(KeyCode.Space))
		{
			// Apply vertical force to player.
			_rigidBody2D.AddForce(new Vector2(0, _jumpForce), ForceMode2D.Impulse);
		}
		// Perform the movement
		Vector2 currentVelocity = _rigidBody2D.velocity;
		_rigidBody2D.velocity = new Vector2(_horizontal * _speed, currentVelocity.y);
		// Animate the movment
		_playAnimation.Run(_horizontal);
	}

	private bool IsGrounded()
	{
		// Cast a ray from player downwards to detect ground
		// if hit ray is not null
		//		then check distance of ray to see if player is grounded.
		// else if hit ray is null then player isnt grounded
		//	retrun false.

		// Perfrom Raycast on groundlayer.
		RaycastHit2D hit = Physics2D.Raycast(transform.position, Vector2.down, 1.0f, _groundLayerMask);

		//Debug.DrawRay(transform.position, Vector2.down);
		bool isGrounded = false;

		// If ray hits something.
		if (hit.collider != null)
		{
			// Gather the tolarence for being grounded, via debug
			// Idle hit.distance is distance from player to ground, used for the isGrounded offset
			Debug.Log("Hit distance tolerance required : " + hit.distance);

			if (hit.distance < _isGroundedOffset)
			{
				// Player is within tolerance to be classed as grounded
				isGrounded = true;
			}
		}
		return isGrounded;
	}
}
