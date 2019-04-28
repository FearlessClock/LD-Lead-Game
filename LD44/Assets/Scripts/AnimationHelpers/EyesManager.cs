using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/*
 *	To make the Character look at something,
 *	just use EyesManager.SetTarget and give it a transform to follow.
 * */
public class EyesManager : MonoBehaviour
{
	public Follow target;
	private Vector3 targetDefaultPosition; //When not focusing on anything
	public Animator anim;
	private float timeBeforeNextBlink = 1f;
	public float blinkMinTime = 1f;
	public float blinkMaxTime = 10f;
	
    // Start is called before the first frame update
    void Start()
    {
		targetDefaultPosition = target.transform.localPosition;
    }

    // Update is called once per frame
    void Update()
    {
		timeBeforeNextBlink -= Time.deltaTime;
		if (timeBeforeNextBlink < 0)
			Blink();
    }

	public void SetTarget(Transform t){
		target.target = t;
		Blink();
		if (t == null)
			target.transform.localPosition = targetDefaultPosition;
	}

	private void Blink(){
		anim.SetTrigger("Blink");
		timeBeforeNextBlink = Random.Range(blinkMinTime, blinkMaxTime);
	}
}
