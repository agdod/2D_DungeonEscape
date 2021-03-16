using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]

public class Player : MonoBehaviour, IDamageable
{
	[Header("Player Inventory")]
	[SerializeField] private int _gems;
	[Space]
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

	[Tooltip("The Sprite Render of the Sword animation")]
	[SerializeField] private SpriteRenderer _swordSprite;
	[Tooltip("The Sprite Renderer of the Player.")]
	[SerializeField] private SpriteRenderer _playerSprite;

	[Tooltip("Script responsible for animation control.")]
	[SerializeField] private PlayAnimation _playerAnimation;

	[Space]
	[SerializeField] private LayerMask _groundLayerMask;

	private float _horizontal;
	private bool _isFaceRight = true;
	private Transform _swordAnimTransform;  // Transfrom of the sword animation componenet

	[SerializeField]
	private bool _lockPlayer;
	[SerializeField]
	private int _health = 4;

	[SerializeField]
	public int Health
	{
		get { return _health; }
		set { _health = value; }
	}

	private bool _isDead;
	public bool isDead
	{
		get { return _isDead; }
	}

	public int Gems
	{
		get
		{
			return _gems;
		}
		set
		{
			_gems = value;
			UIManager.Instance.UpdatePlayerGemCount(_gems);
		}
	}

	public bool LockPlayer
	{
		get { return _lockPlayer; }
		set { _lockPlayer = value; }
	}

	void Start()
	{
		// Do null checks on components
		// no need to nullcheck rigidbody2D as it is a required compnet of this script.
		if (_playerAnimation == null)
		{
			ConsoleOutput("PlayerAniimation");
		}
		if (_playerSprite == null)
		{
			ConsoleOutput("Sprite Renderer");
		}
		_swordAnimTransform = _swordSprite.GetComponent<Transform>();
		UIManager.Instance.UpdatePlayerGemCount(_gems);
		//UIManager.Instance.UpdateLives(_health);
		_isDead = false;
	}

	void Update()
	{
		if (IsGrounded())
		{
			Debug.DrawRay(transform.position, Vector2.down, Color.red);
			MovePlayer();
			if (Input.GetMouseButtonDown(0))
			{
				_playerAnimation.Attack();
			}
		}
	}

	void ConsoleOutput(string comp)
	{
		Debug.LogError(comp + " component not available.");
	}

	private void Flip(float dir)
	{
		// Flip the Parent object -Player GO - to flip both player, and sword sprite

		// dir > 0 player goes right
		if (dir > 0 && !_isFaceRight)
		{
			// Face Right
			//_playerSprite.flipX = false;
			_playerSprite.transform.rotation = Quaternion.Euler(Vector3.zero);
			// Rotate and reposition the sword arc sprite
			/*
			Vector3 pos = _swordAnimTransform.position;
			pos.x = 1.01f;
			_swordAnimTransform.position = pos;
			_swordAnimTransform.rotation = Quaternion.Euler(new Vector3(66, 48, -80));
			*/
			_isFaceRight = true;
		}
		// dir <0 player goes left
		else if (dir < 0 && _isFaceRight)
		{
			// Face left
			_playerSprite.transform.rotation = Quaternion.Euler(new Vector3(0, 180, 0));
			/*_playerSprite.flipX = true;
			_
			// Rotate and reposition the sword arc sprite
			Vector3 pos = _swordAnimTransform.position;
			pos.x = -1.01f;
			_swordAnimTransform.position = pos;
			_swordAnimTransform.rotation = Quaternion.Euler(new Vector3(66, 228, -80));
			*/
			_isFaceRight = false;
		}
	}

	private void MovePlayer()
	{
		// Get horizontal movment
		// if move > 0 then facing right
		//	else if < 0 then facing left

		_horizontal = Input.GetAxisRaw("Horizontal");
		Flip(_horizontal);

		// Check for jump input, jump status , if player isnt locked.
		if (Input.GetKeyDown(KeyCode.Space) && !_lockPlayer)
		{
			// Apply vertical force to player.
			_rigidBody2D.AddForce(new Vector2(0, _jumpForce), ForceMode2D.Impulse);
			// Set animation fro jumping
			_playerAnimation.Jump(true);
		}
		// if player is locked - in the shop - then can only move right
		if (_lockPlayer)
		{
			// Freeze any left movement
			if (_horizontal < 0)
			{
				_horizontal = 0;
			}
		}

		// Perform the movement
		Vector2 currentVelocity = _rigidBody2D.velocity;
		_rigidBody2D.velocity = new Vector2(_horizontal * _speed, currentVelocity.y);
		// Animate the movment
		_playerAnimation.Run(_horizontal);
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

		bool isGrounded = false;

		// If ray hits something.
		if (hit.collider != null)
		{
			// Gather the tolarence for being grounded, via debug
			// Idle hit.distance is distance from player to ground, used for the isGrounded offset
			//Debug.Log("Hit distance tolerance required : " + hit.distance);

			if (hit.distance < _isGroundedOffset)
			{
				// Player is within tolerance to be classed as grounded
				isGrounded = true;
				// Reset jumping aniamtion
				_playerAnimation.Jump(false);
			}
		}
		return isGrounded;
	}

	public void Damage()
	{
		Debug.Log("Player::Damage");
		// remove 1 health
		// update ui display
		// check for dead
		// play death animation
		if (!_isDead)
		{
			_health--;
			Debug.Log("updating ui");
			UIManager.Instance.UpdateLives(_health);
			if (_health < 1)
			{
				// Player is dead!
				_isDead = true;
				_playerAnimation.Death();
			}
		}
	}
}
