using UnityEngine;
using System.Collections;

public class Projectile : MonoBehaviour {

	public Rigidbody rigidbody;

	public void Fire(Transform lp){
		rigidbody.AddForce(lp.forward*10.0f,ForceMode.Impulse);
		StartCoroutine(WaitThenDestroy());
	}

	public void OnCollisionEnter(Collision other){
		if(other.transform.GetComponent<Hero>()){
			Destroy(gameObject);
			other.transform.GetComponent<Vitality>().TakeHit();
		}

		if(other.transform.parent != null && other.transform.parent.GetComponent<Barrier>()){
			Destroy(gameObject);
		}
	}

	public IEnumerator WaitThenDestroy(){
		yield return new WaitForSeconds(10);
		if(gameObject){
			Destroy(gameObject);
		}
	}
}
