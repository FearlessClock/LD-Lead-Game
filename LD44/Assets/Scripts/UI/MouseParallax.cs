using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MouseParallax : MonoBehaviour
{
	[System.Serializable]
	public struct ParallaxLayer{
		[SerializeField]		public Transform layer;
		[SerializeField]		public float factor;
		[System.NonSerialized]	public Vector3 startPosition;
	}

	[SerializeField]	public ParallaxLayer[] layers;
	[SerializeField] public float parallaxScale = 1;

    // Start is called before the first frame update
    void Start()
    {
		for (int i = 0; i < layers.Length; i++)
		{
			layers[i].startPosition = layers[i].layer.transform.localPosition;
		}
    }

    // Update is called once per frame
    void Update()
    {
		Vector3 mouseOffset = ((Input.mousePosition / Screen.width) - 0.5f * Vector3.one) * parallaxScale;
		mouseOffset.z = 0;
        foreach(ParallaxLayer pl in layers){
			pl.layer.localPosition = pl.startPosition + mouseOffset * pl.factor;
		}
    }
}
