using UnityEngine;
using System.Collections;

public class ClimbUpDownState : State {

	public StateData data;
	public float speed = 1;
	[SerializeField]protected Transform body;
	public Animator bodyAnimation;

	public void OnEnable()
	{
		body.transform.forward = body.transform.parent.forward;
		if(data == null){
			data = GetComponent<StateData>();
		}
	}

	void Update () {

		if(data.Direction != Vector3.zero){
			bodyAnimation.Play("climb");
		}else{
			bodyAnimation.Play("rest");
		}

		transform.Translate(new Vector3(0,data.Direction.z,0) * speed * Time.deltaTime);
	}
}
