using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class DroppedItem : MonoBehaviour {

	bool breaking;
	bool landed;
	public BreakEffect breakEffect;

	public AudioSource slamOne;
	public AudioSource slamTwo;

	public List<AudioSource> notes = new List<AudioSource>();

	public void OnCollisionEnter(Collision collision){

		landed = true;
		notes.GetRandomElement().Play();
		Hero h = collision.transform.GetComponent<Hero>();
		BadGuy bg = collision.transform.GetComponent<BadGuy>();
		DroppedItem di = collision.transform.GetComponent<DroppedItem>();
		if((h || bg || di) && !breaking){
			breaking = true;
			breakEffect.BreakNow();


			slamOne.Play();


			if(collision.relativeVelocity.magnitude > 5){
				if(bg){
					notes.GetRandomElement().Play();
					bg.GetComponent<Vitality>().TakeHit();
				}
			}

			if(collision.relativeVelocity.magnitude > 10){
				if(h){
					notes.GetRandomElement().Play();
					h.GetComponent<Vitality>().TakeHit();
				}
			}
		}
	}

	public void Update(){
		if(landed){
			return;
		}
		float mw = Input.GetAxis("Mouse ScrollWheel");
		if(mw != 0){
			transform.Rotate(Vector3.up * 200.0f * mw * Time.deltaTime);
		}
	}



}


