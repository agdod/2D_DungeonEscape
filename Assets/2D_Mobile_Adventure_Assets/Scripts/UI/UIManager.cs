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
        get { 
            if (_instance == null)
            {
                Debug.Log("UIManager instance is null.");
                
			}
            return _instance; 
        }
	}

    [SerializeField] private TMP_Text _gemCount;
    [SerializeField] private Image _selectionImg;

	private void Awake()
	{
        _instance = this;
	}

    public void UpdateGemCount(int gems)
	{
        _gemCount.text = "" + gems + " G";
	}

    public void UpdateSelection(RectTransform rectTrans)
	{
        _selectionImg.rectTransform.anchoredPosition = rectTrans.anchoredPosition;
	}
}
