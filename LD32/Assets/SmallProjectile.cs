using UnityEngine;
using System.Collections;

public class SmallProjectile : MonoBehaviour {
	
	public Rigidbody rigidbody;

	public void Fire(Transform lp,float power){
		rigidbody.AddForce(lp.forward*power,ForceMode.Impulse);
	}
	
	public void OnCollisionEnter(Collision other){
		if(other.transform.GetComponent<Hero>()){
			other.transform.GetComponent<Vitality>().TakeHit();
		}
		Destroy(gameObject);
	}

}
