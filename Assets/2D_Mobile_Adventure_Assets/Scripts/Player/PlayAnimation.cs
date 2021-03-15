using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayAnimation : MonoBehaviour
{
	[Tooltip("The Animator Component of the Player.")]
	[SerializeField] private Animator _playerAnim;
	[Tooltip("The Animator Component of the Sword.")]
	[SerializeField] private Animator _swordAnim;

	void Start()
	{
		if (_playerAnim == null)
		{
			Debug.Log("No animation Component assigned.Trying to retreive required Component.");
			_playerAnim = GetComponentInChildren<Animator>();
			if (_playerAnim == null)
			{
				Debug.LogError("Unable to retreive the Animator Component.");
			}
		}
	}

	public void Run(float speed)
	{
		_playerAnim.SetFloat("Speed", Mathf.Abs(speed));
	}

	public void Jump(bool canJump)
	{
		_playerAnim.SetBool("IsJumping", canJump);
	}

	public void Attack()
	{
		_playerAnim.SetTrigger("Attacking");
		_swordAnim.SetTrigger("SwordArc");
	}

	public void Death()
	{
		_playerAnim.SetTrigger("Death");
	}
}
