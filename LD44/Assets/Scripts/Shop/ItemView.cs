using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(BoxCollider2D))]
public class ItemView : MonoBehaviour
{
	public Item item;
	public GameObject graphics;
	public bool Selected = false;
    private ItemsController itemsController;

	public void Init(Item item, ItemsController itemController)
	{
		this.item = item;
        this.itemsController = itemController;
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
            if(item.itemType == eItemType.Weapon)
            {
                itemsController.SetWeapon((aWeapon)item);
            }
            else if(item.itemType == eItemType.ActiveSpell)
            {
                itemsController.SetActiveSpell((ActiveBloodMagic)item);
            }
            else if(item.itemType == eItemType.PassiveSpell)
            {
                itemsController.SetPassiveSpell((PassiveBloodMagic)item);
            }

            ShopManager.instance.playerHealth.TakeDamage(item.shopCost);
            Clear();
		}
	}

	public void Clear(){
		Destroy(graphics);
	}
}
