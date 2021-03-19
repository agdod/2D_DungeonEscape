using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class MainMenu : MonoBehaviour
{
	[SerializeField] private Image _fillImage;
	[SerializeField] private RectTransform _loading;

	public void StartButton()
	{
		Debug.Log("Start buttone pressed.");
		_loading.gameObject.SetActive(true);
		StartCoroutine(AsyncLoadGame());
		// Add loading bar.
	}

	public void MenuButton()
	{
		Debug.Log("Menu buttone pressed.");
	}

	public void QuitButton()
	{
		Debug.Log("Quit button pressed.");
		Application.Quit();
	}

	IEnumerator AsyncLoadGame()
	{
		AsyncOperation asyncLoad = SceneManager.LoadSceneAsync("Game");
		while (!asyncLoad.isDone)
		{
			_fillImage.fillAmount = asyncLoad.progress;
			yield return new WaitForEndOfFrame();
		}
	}
}
