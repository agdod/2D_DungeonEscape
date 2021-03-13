using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AcidEffect : MonoBehaviour
{
	// Move right at 3 meters/second
	// Detect player and deal damage (IDamagable)
	// Destroy after 5 seconds.

	[SerializeField] private float _speed;
	[Tooltip("Duration Acid Effet lives.")]
	[SerializeField] private float _duration;

	private void Start()
	{
		Destroy(gameObject, _duration);
	}

	private void Update()
	{
		transform.position += Vector3.right * _speed * Time.deltaTime;
	}

	private void OnTriggerEnter2D(Collider2D other)
	{
		// Check for IDamageable ad cause damage.
		if (other.TryGetComponent(out IDamageable hit))
		{
			hit.Damage();
		}
	}
}
