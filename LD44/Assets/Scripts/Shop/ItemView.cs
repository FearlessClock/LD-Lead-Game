using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(BoxCollider2D))]
public class ItemView : MonoBehaviour
{
	public Item item;
	public GameObject graphics;
	public bool Selected = false;

	public void Init(Item item)
	{
		this.item = item;
		graphics = Instantiate(item.shopPrefab, transform);
	}

	private void OnTriggerEnter2D(Collider2D collision)
	{
		Selected = false;
		ShopManager.instance.Display(item);
	}

	private void OnTriggerExit2D(Collider2D collision)
	{
		ShopManager.instance.Hide();
	}


	// TODO : Call this when the player atacks the collider
	public void OnBuy(){
		if (!Selected)
		{
			Selected = true;
			ShopManager.instance.Select();
		}
		else
		{
			// TODO : Actually buy the item, IE set the weapon in the player's Weapon controller or the spells
			ShopManager.instance.Hide();
			Clear();
		}
	}

	public void Clear(){
		Destroy(graphics);
	}
}
