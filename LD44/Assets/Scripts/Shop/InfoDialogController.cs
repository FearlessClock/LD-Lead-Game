using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class InfoDialogController : MonoBehaviour
{
	public TextMeshProUGUI Description;
	public TextMeshProUGUI Name;
	public Slider Cost;
	public GameObject actionPrompt;

	public void Init(Item item)
	{
		Cost.value = item.shopCost;
		Description.text = item.description;
		Name.text = item.name;
		actionPrompt.SetActive(true);
		gameObject.SetActive(true);
	}

	public void Select(){
		actionPrompt.SetActive(false);
	}

	public void Hide(){
		gameObject.SetActive(false);
	}
}
