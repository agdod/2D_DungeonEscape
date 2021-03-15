using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MerchantShop : MonoBehaviour
{
	// Display the Merchant ShopUI Interface
	[SerializeField] private GameObject _merchantShop;
	[SerializeField] private int[] _itemCost;
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
				_player = player;
				UIManager.Instance.UpdateShopGemCount(_player.Gems);

				_player.LockPlayer = true;
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

	public void BuyItem()
	{
		// BuyItem 
		// check if player has gems to cover cost
		// do trascation ( subtract gems etc)
		// else cancel sale. - leave shop.
		if (_player.Gems >= _itemCost[_selectedItem])
		{
			// equipItem 
			Debug.Log("Player purchased item " + _selectedItem);
			_player.Gems -= _itemCost[_selectedItem];
			UIManager.Instance.UpdatePlayerGemCount(_player.Gems);
			UIManager.Instance.UpdateShopGemCount(_player.Gems);
		}
		else
		{
			Debug.Log("Not enough funds.");
			_merchantShop.SetActive(false);
			_player.LockPlayer = false;
		}
	}

	public void SelectItem(RectTransform rectTrans)
	{
		UIManager.Instance.UpdateSelection(rectTrans);
		Debug.Log("Item selected : " + rectTrans.name);
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
}
