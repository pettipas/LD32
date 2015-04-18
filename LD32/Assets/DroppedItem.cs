using UnityEngine;
using System.Collections;

public class DroppedItem : MonoBehaviour {

	bool breaking;
	public BreakEffect breakEffect;
	public void OnCollisionEnter(Collision collision){
		Hero h = collision.transform.GetComponent<Hero>();
		BadGuy bg = collision.transform.GetComponent<BadGuy>();
		DroppedItem di = collision.transform.GetComponent<DroppedItem>();
		if((h || bg || di) && !breaking){
			breaking = true;
			breakEffect.BreakNow();
		}
	}

}
