using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Skeleton :Enemy
{
	protected override void Init()
	{
		base.Init();
		destination = pointB.position;
	}
}
