using UnityEngine;
using System.Collections;

public class Vitality : MonoBehaviour {

	public AudioSource win;
	public int hits;
	public GameObject death;
	public void TakeHit(){
		hits--;
		GetComponent<MaterialFlasher>().FlashForTime(0.5f);

		if(hits <=0){
			Instantiate(death,transform.position,Quaternion.identity);
			Destroy(gameObject);
		}
	}

	public void GainHealth ()
	{
		win.Play();
		hits++;
	}

}
