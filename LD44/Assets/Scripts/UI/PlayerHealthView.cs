using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerHealthView : MonoBehaviour
{

	public UnityEngine.UI.Slider slider;
	public FloatVariable hp;
	public TMPro.TextMeshProUGUI counter;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
		slider.value = hp.value;
		counter.text = Mathf.FloorToInt(hp.value).ToString();
    }
}
