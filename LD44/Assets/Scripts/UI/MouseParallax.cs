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

	[SerializeField]		public ParallaxLayer[] layers;
	[SerializeField]		public float parallaxScale = 1;
	[SerializeField]		public float lerpSpeed = 2f;
	[System.NonSerialized]	public Vector3 offset = Vector3.zero;
	[System.NonSerialized]	private bool mouseMoved = false;
	[System.NonSerialized]	private Vector3 mouseStartPosition;

    // Start is called before the first frame update
    void Start()
    {
		mouseStartPosition = Input.mousePosition;
		for (int i = 0; i < layers.Length; i++)
		{
			layers[i].startPosition = layers[i].layer.transform.localPosition;
		}
    }

    // Update is called once per frame
    void Update()
    {
		if (Input.mousePosition != mouseStartPosition)	// Detect if the player has used the mouse
			mouseMoved = true;

		if(mouseMoved)
			offset = ((Input.mousePosition / Screen.width) - 0.5f * Vector3.one) * parallaxScale;	// Get the offset from the mouse
		else{
			// TODO : Get the offset depending on the Second joystick or the selected button
		}
		
		offset.z = 0; // We don't want any Z movement

        foreach(ParallaxLayer pl in layers){
			// Update Every layers position depending on the offset. Lerp for sweet smoothness
			pl.layer.localPosition = Vector3.Lerp(pl.layer.localPosition, pl.startPosition + offset * pl.factor,Time.deltaTime * lerpSpeed);
		}
    }
}
