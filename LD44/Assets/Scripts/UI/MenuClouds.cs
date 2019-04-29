using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[ExecuteInEditMode]
public class MenuClouds : MonoBehaviour
{

	public float minX;
	public float maxX;

	public float SpeedScale;

    // Update is called once per frame
    void Update()
    {
        foreach(Transform t in transform){
			t.Translate(Vector3.right * t.position.z * SpeedScale);
			if (t.localPosition.x > maxX)
				t.localPosition -= (minX - maxX) * Vector3.left;
		}
    }

	private void OnDrawGizmosSelected()
	{
		Gizmos.color = Color.red;
		Gizmos.DrawLine(transform.position + Vector3.right * minX, transform.position + Vector3.right * maxX);
	}
}
