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
	[Header("Shop Layout")]
	[SerializeField] private TMP_Text _shopGemCount;
	[SerializeField] private Image _selectionImg;
	[Space][Header("Player Information")]
	[SerializeField] private TMP_Text _playerGemCount;
	[SerializeField] private Image[] _lives;
	[Space]
	[Header("In Game Message system.")]
	[SerializeField] private RectTransform _dialogBox;
	[SerializeField] private TMP_Text _dialogTxt;

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

	public void UpdateLives(int health)
	{
		// loop through lives
		// hide life
		for (int i = _lives.Length; i > health; i--)
		{
			// Disable lives from "top down"
			_lives[i - 1].gameObject.SetActive(false);
		}
	}

	public void DialogBox(string dialog )
	{
		_dialogBox.gameObject.SetActive(true);
		_dialogTxt.text = dialog;
	}

	public void CloseDialogBox()
	{
		_dialogBox.gameObject.SetActive(false);
	}
}
