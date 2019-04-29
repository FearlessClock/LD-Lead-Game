using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum eItemType { Weapon, ActiveSpell, PassiveSpell }
public abstract class Item : ScriptableObject
{
	public int shopCost;
	public int minRound;
	[TextArea]
	public string description;
	public int dropRate;
	public string[] requirements;

    public eItemType itemType;

	// View : 
	public GameObject shopPrefab;
	//public GameObject inGamePrefab;
}
