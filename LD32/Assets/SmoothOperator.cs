using UnityEngine;
using System.Collections;

public class SmoothOperator : MonoBehaviour {

	public Transform ourHero;
	Vector3 dampingVelocity;
	float refVelocity;
	public Camera dropCam;
	public float targetFov;
	public float targetZOffset;



	public bool anyInput;

	void Update () {


		if(Input.anyKeyDown){
			anyInput = true;
		}

		if(!anyInput){
			return;
		}

		if(ourHero == null){
			return;
		}
		Vector3 targetPosition = ourHero.position;

		dropCam.orthographicSize = Mathf.SmoothDamp(dropCam.orthographicSize,targetFov,ref refVelocity,1);
		transform.position = Vector3.SmoothDamp(transform.position, new Vector3(targetPosition.x, targetPosition.y, targetPosition.z-targetZOffset), ref dampingVelocity,0.2f);
	}
}
