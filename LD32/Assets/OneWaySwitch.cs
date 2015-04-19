using UnityEngine;
using System.Collections;

public class OneWaySwitch : MonoBehaviour {

	public GameObject activateThoseNow;
	public SmoothOperator cameraView;

	public float orthographicSize;
	public void OnTriggerEnter(Collider other){
		Hero h = other.transform.GetComponent<Hero>();
		if(h){
			activateThoseNow.SetActive(true);
		}

		DoTHing();
	}

	[ContextMenu("Test")]
	public void DoTHing(){
		if(cameraView != null && orthographicSize != 0){
			cameraView.targetFov = orthographicSize;
			Debug.Log (cameraView.targetFov + "was set" );
		}

	}
}
