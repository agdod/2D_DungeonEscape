using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpiderAnimationEvent : MonoBehaviour
{
	// Handle to Spider
	[SerializeField] private Spider _spider;

	public void Fire()
	{
		Debug.Log("Spider::Fire!");
		// Tell spider to fire.
		_spider.Attack();
	}
}
