using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShopManager : MonoBehaviour
{
	public static ShopManager instance;

	public ItemView[] itemsSlots;

	public InfoDialogController infoUI;
	public GameObject confirmationUI;

	public Item[] itemsInShop;

    public HealthController playerHealth;

	private void Awake()
	{
		instance = this;
		InitShop(1, FindObjectOfType<ItemsController>());
        playerHealth = FindObjectOfType<HealthController>();

    }

	/*
	private void Update()
	{
		if (Input.GetKeyDown(KeyCode.Space))
			InitShop(1, null);
	}*/

	public void InitShop(int round, ItemsController itemsController){
		List<Item> availableItems = new List<Item>();

		//TODO : Fill the list with the appropriate items
		// But for now just take first ones
		availableItems.AddRange(itemsInShop);
		int availableCount = availableItems.Count;
		for (int i = 0; i < itemsSlots.Length && i < availableCount; i++)
		{
			// TODO : Select items depending on drop rate as well as type
			// But for now just take the first ones
			InitSlot(i, availableItems[0], itemsController);
			availableItems.RemoveAt(0);
		}
	}

	public void InitSlot(int slotID, Item item, ItemsController itemController){
		itemsSlots[slotID].Init(item, itemController);
	}

	public void ClearShop(){
		foreach (ItemView itemViewer in itemsSlots)
		{
			itemViewer.Clear();
		}
	}

	public void Display(Item item){
		if(item)
			infoUI.Init(item);
	}

	public void Select(){
		infoUI.Select();
		confirmationUI.SetActive(true);
	}

	public void Hide(){
		infoUI.Hide();
		confirmationUI.SetActive(false);
	}
}
