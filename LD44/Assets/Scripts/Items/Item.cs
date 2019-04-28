using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Item : ScriptableObject
{
	public int shopCost;
	public int minRound;
	[TextArea]
	public string description;
	public int dropRate;
	public string[] requirements;

	// View : 
	public GameObject shopPrefab;
	//public GameObject inGamePrefab;
}
