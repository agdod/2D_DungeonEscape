using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Diamond : MonoBehaviour
{
	[SerializeField] private int _gems = 1;

	public int Gems
	{
		get { return _gems; }
		set { _gems = value; }
	}

	private void OnTriggerEnter2D(Collider2D other)
	{
		if (other.tag == "Player")
		{
			if (other.TryGetComponent(out Player player))
			{
				// Collect Gems.
				// Add gems to player Gems.
				player.Gems += _gems;
				Destroy(gameObject);
			}
		}
	}
}
