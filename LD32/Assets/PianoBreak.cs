using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class PianoBreak : BreakEffect {

	public GameObject wholePiano;
	public List<GameObject> parts = new List<GameObject>();
	public Animator partsAnimator;
	bool called;

	public override void BreakNow ()
	{
		if(!called){
			called = true;
			transform.parent = null;
			wholePiano.GetComponent<Renderer>().enabled = false;
			wholePiano.GetComponent<BoxCollider>().enabled = false;
			parts.ForEach(p=>{
				p.GetComponent<Renderer>().enabled = true;
				p.AddComponent<Rigidbody>();
				p.AddComponent<BoxCollider>();
			});
			StartCoroutine(FadeAndDestroy());
		}
	}

	public IEnumerator FadeAndDestroy(){
		yield return new WaitForSeconds(1.0f);
		partsAnimator.Play("fadeout");
		yield return new WaitForSeconds(3.0f);
		Destroy(transform.gameObject);
	}
}
