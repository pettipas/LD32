using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class GameOver : MonoBehaviour {

	public List<GameObject> letters = new List<GameObject>();

	public void Start(){
		letters.ForEach(l=>{
			l.transform.parent = null;
			l.AddComponent<BoxCollider>();
			l.AddComponent<Rigidbody>();
		});
	}
}
