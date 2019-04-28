using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[ExecuteInEditMode]
public class Follow : MonoBehaviour
{
	public Transform target;
	public float LerpSpeed;

    // Update is called once per frame
    void Update()
    {
		if(target)
			transform.position = Vector3.Lerp(transform.position,target.position, Time.deltaTime * LerpSpeed);
    }
}
