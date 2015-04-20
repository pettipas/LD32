using UnityEngine;
using System.Collections;

public class ClimbUpDownState : State {

	public StateData data;
	public float speed = 1;
	[SerializeField]protected Transform body;
	public Animator bodyAnimation;
	public SmoothOperator muchSmooth;
	public AudioSource walk;

	public void OnEnable()
	{
		body.transform.forward = body.transform.parent.forward;
		if(data == null){
			data = GetComponent<StateData>();
		}
		muchSmooth.targetZOffset = 10;
		muchSmooth.targetFov = 10;
	}

	public void OnDisable(){
		muchSmooth.targetZOffset = 5;
		muchSmooth.targetFov = 7;
	}

	void Update () {

		if(data.Direction != Vector3.zero){
			bodyAnimation.Play("climb");

		}else{
			bodyAnimation.Play("rest");
			walk.Stop ();
		}

		if(data.Direction.z > 0 && !walk.isPlaying){
			walk.Play();
		}

		transform.Translate(new Vector3(0,data.Direction.z,0) * speed * Time.deltaTime);
	}
}
