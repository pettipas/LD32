using UnityEngine;
using System.Collections;

public class SmallProjectile : MonoBehaviour {
	
	public Rigidbody rigidbody;
	
	public void Fire(Transform lp){
		rigidbody.AddForce(lp.forward*15.0f,ForceMode.Impulse);
	}
	
	public void OnCollisionEnter(Collision other){
		if(other.transform.GetComponent<Hero>()){
			other.transform.GetComponent<Vitality>().TakeHit();
		}
		Destroy(gameObject);
	}

}
