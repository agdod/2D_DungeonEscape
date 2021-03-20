using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public enum AttackType
{
	Regular = 1,
	Boost = 2,
	Flame = 3
}

[System.Serializable]
public class Inventory : MonoBehaviour
{
	[SerializeField] private bool _castleKey, _regularSword, _boosterSword, _flameSword, _bootsOfFlight;
	[SerializeField] private AttackType _attackType;

	public AttackType Sword
	{
		get { return _attackType; }
	}

	public bool CastleKey
	{
		get { return _castleKey; }
		set { _castleKey = value; }
	}

	public bool RegularSword
	{
		get { return _regularSword; }
		set
		{
			_regularSword = value;
			if (value)
			{
				_attackType = AttackType.Regular;
			}
		}
	}

	public bool BoosterSword
	{
		get { return _boosterSword; }
		set
		{
			_boosterSword = value;
			if (value)
			{
				_attackType = AttackType.Boost;
			}
		}
	}

	public bool FlameSword
	{
		get { return _flameSword; }
		set
		{
			_flameSword = value;
			if (value)
			{
				_attackType = AttackType.Flame;
			}
		}
	}

	public bool BootsOfFlight
	{
		get { return _bootsOfFlight; }
		set { _bootsOfFlight = value; }
	}

	private void Start()
	{
		_attackType = AttackType.Regular;
	}
}
