using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MossGiant : Enemy
{
	[SerializeField] Vector3 _destination;

	private void Start()
	{
		_destination = pointA.position;
	}

	protected override void Update()
	{
		// move MoseGiant between points A,B
		float step = speed * Time.deltaTime;
		transform.position = Vector3.MoveTowards(transform.position, _destination, step);
		if (Vector3.Distance(transform.position,_destination) <0.1f)
		{
			if (_destination == pointA.position)
			{
				_destination = pointB.position;
			}
			else if (_destination == pointB.position)
			{
				_destination = pointA.position;
			}
		}
	}
}
