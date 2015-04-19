using UnityEngine;
using System.Collections;

public class DroppedItem : MonoBehaviour {

	bool breaking;
	bool landed;
	public BreakEffect breakEffect;
	public void OnCollisionEnter(Collision collision){

		landed = true;
		Hero h = collision.transform.GetComponent<Hero>();
		BadGuy bg = collision.transform.GetComponent<BadGuy>();
		DroppedItem di = collision.transform.GetComponent<DroppedItem>();
		if((h || bg || di) && !breaking){
			breaking = true;
			breakEffect.BreakNow();

			if(collision.relativeVelocity.magnitude > 5){
				if(bg){
					bg.GetComponent<Vitality>().TakeHit();
				}

			}

			if(collision.relativeVelocity.magnitude > 10){
				if(h){
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
