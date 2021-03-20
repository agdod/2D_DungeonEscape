using System.Collections;
using System.Collections.Generic;
using UnityEngine;



public class GameManager : MonoBehaviour
{
	private static GameManager _instance;
	public static GameManager Instance
	{
		get
		{
			if (_instance == null)
			{
				_instance = FindObjectOfType(typeof(GameManager)) as GameManager;
			}
			return _instance;
		}
	}

	private void Start()
	{
		Player = GameObject.FindGameObjectWithTag("Player").GetComponent<Player>();
	}

	private bool _keyToCastle;
	private bool _bootsOfFlight;
	private bool _flameSword;

	public Player Player { get; private set; }

	public bool KeyToCastle
	{
		get { return _keyToCastle; }
		set { _keyToCastle = value; }
	}

	public bool BootsOfFlight
	{
		get { return _bootsOfFlight; }
		set { _bootsOfFlight = value; }
	}

	public bool FlameSword
	{
		get { return _flameSword; }
		set { _flameSword = value; }
	}
}
