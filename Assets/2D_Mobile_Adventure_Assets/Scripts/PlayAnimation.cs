using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayAnimation : MonoBehaviour
{
    [Tooltip("The Animator Component of the Player.")]
    [SerializeField] private Animator _anim;

    void Start()
    {
        if (_anim == null)
		{
            Debug.Log("No animation Component assigned.Trying to retreive required Component.");
            _anim = GetComponentInChildren<Animator>();
            if (_anim == null)
			{
                Debug.LogError("Unable to retreive the Animator Component.");
			}
		}
    }

    public void Run(float speed)
	{
        _anim.SetFloat("Speed", Mathf.Abs(speed));
    }
}
