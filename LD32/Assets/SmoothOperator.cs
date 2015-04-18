using UnityEngine;
using System.Collections;

public class SmoothOperator : MonoBehaviour {

	public Transform ourHero;
	Vector3 dampingVelocity;
	void Update () {
		if(ourHero == null){
			return;
		}
		Vector3 targetPosition = ourHero.position;
		transform.position = Vector3.SmoothDamp(transform.position, new Vector3(targetPosition.x, targetPosition.y, targetPosition.z-5), ref dampingVelocity,0.2f);
	}
}
