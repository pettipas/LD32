using UnityEngine;
using System.Collections;

public class Hearts : MonoBehaviour {

	public void Update(){
		Ray ray = new Ray(transform.position,transform.up);
		RaycastHit[] hits = Physics.SphereCastAll(ray,1.5f,0.1f);
		foreach(RaycastHit rh in hits){
			Hero hero = rh.transform.GetComponent<Hero>();
			if(hero){
				hero.transform.GetComponent<Vitality>().GainHealth();
				Destroy(gameObject);
			}
		}
	}
}
