using UnityEngine;
using System.Collections;

public class Vitality : MonoBehaviour {

	public int hits;

	public void TakeHit(){
		hits--;
		GetComponent<MaterialFlasher>().FlashForTime(0.5f);
	}

}
