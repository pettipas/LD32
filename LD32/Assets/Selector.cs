﻿using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class Selector : MonoBehaviour {

	public GameObject curser;
	public Transform hitObject;

	public GameObject testDropPrefab;

	public void Update(){
		Camera main = Camera.main;
		if(main == null){
			return;
		}

		Ray ray = main.ScreenPointToRay(Input.mousePosition);
		RaycastHit hit;
		if(Physics.Raycast(ray,out hit)) {
			Vector3 mPos = hit.point;
			if(curser)curser.transform.position = mPos;


			hitObject = hit.transform;
		}



	}
}
