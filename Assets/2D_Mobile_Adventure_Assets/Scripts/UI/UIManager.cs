using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class UIManager : MonoBehaviour
{
	private static UIManager _instance;

	public static UIManager Instance
	{
		get
		{
			if (_instance == null)
			{
				_instance = FindObjectOfType(typeof(UIManager)) as UIManager;
			}
			return _instance;
		}
	}

	[SerializeField] private TMP_Text _shopGemCount;
	[SerializeField] private Image _selectionImg;
	[SerializeField] private TMP_Text _playerGemCount;

	private void Awake()
	{
		_instance = this;
	}

	public void UpdateShopGemCount(int gems)
	{
		_shopGemCount.text = "" + gems + " G";
	}

	public void UpdatePlayerGemCount(int gems)
	{
		_playerGemCount.text = "" + gems;
	}

	public void UpdateSelection(RectTransform rectTrans)
	{
		_selectionImg.rectTransform.anchoredPosition = rectTrans.anchoredPosition;
	}

	public void UpdateLives()
	{
		// loop through lives
		// hide life
	}
}
