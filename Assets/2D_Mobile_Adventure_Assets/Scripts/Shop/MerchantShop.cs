using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MerchantShop : MonoBehaviour
{
	// Display the Merchant ShopUI Interface
	[SerializeField] private GameObject _merchantShop;
	private Player _player;
	private int _selectedItem;

	private void Update()
	{
		if (Input.GetKeyDown(KeyCode.Escape))
		{
			_merchantShop.SetActive(false);
			_player.LockPlayer = false;

		}
	}

	private void OnTriggerEnter2D(Collider2D other)
	{
		// Open the shop.
		if (other.tag == "Player")
		{
			if (other.TryGetComponent(out Player player))
			{
				UIManager.Instance.UpdateGemCount(player.Gems);
				_player = player;
				player.LockPlayer = true;
			}
			_merchantShop.SetActive(true);
		}
	}

	private void OnTriggerExit2D(Collider2D other)
	{
		if (other.tag == "Player")
		{
			if (other.TryGetComponent(out Player player))
			{
				player.LockPlayer = false;
			}
			_merchantShop.SetActive(false);
		}
	}

	private void GetSelectedItem(RectTransform rectTrans)
	{
		// Gets the name of the slected button.
		switch (rectTrans.name)
		{
			case "FlameSword_Btn":
				_selectedItem = 0;
				break;
			case "BootOfFlight_Btn":
				_selectedItem = 1;
				break;
			case "KeyToCastle_Btn":
				_selectedItem = 2;
				break;
			default:
				Debug.Log("Corresponding case type for " + rectTrans.name + " not found.");
				break;
		}
	}

	public void SelectItem(RectTransform rectTrans)
	{
		UIManager.Instance.UpdateSelection(rectTrans);
	}


}
