using UnityEngine;
using System.Collections;

public class Movement : State {

	public CharacterController ctrl;
	public float speed = 2;
	public StateData data;
	public GameObject body;
	public State takeDamage;

	public Animator bodyAnimation;

	void Awake () {
		data = GetComponent<StateData>();
		ctrl = GetComponent<CharacterController>();
	}
	
	void Update () {

		if(data.Direction != Vector3.zero){
			bodyAnimation.Play("walk");
		}else{
			bodyAnimation.Play("rest");
		}

		ctrl.Move(new Vector3(data.Direction.x,0,data.Direction.z) * speed * Time.deltaTime);

		if(data.Direction.normalized != Vector3.zero){
			body.transform.forward = data.Direction.normalized;
		}

	}

	void LateUpdate(){
		transform.position = new Vector3(transform.position.x,data.Height,transform.position.z);
	}
}
