using UnityEngine;
using System.Collections;

public class OneWaySwitch : MonoBehaviour {

	public GameObject activateThoseNow;

	public void OnTriggerEnter(Collider other){
		Hero h = other.transform.GetComponent<Hero>();
		if(h){
			activateThoseNow.SetActive(true);
		}
	}
}
