using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OpenGate : MonoBehaviour
{
	private void OnTriggerEnter2D(Collider2D other)
	{
		if (other.tag == "Player" && other.GetComponent<Player>().HasKey == true )
		{
			if (TryGetComponent(out Animator anim))
			{
				anim.SetTrigger("OpenGate");
			}
		}
	}
}
