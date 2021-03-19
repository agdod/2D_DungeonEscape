using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpikeDamage : MonoBehaviour
{
	private void OnTriggerEnter2D(Collider2D other)
	{
		if (other.tag == "Player")
		{
			if (other.TryGetComponent(out Player player))
			{
				player.FatalDamage();
			}
		}
	}
}
