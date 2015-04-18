using UnityEngine;
using System.Collections;

public class SlideState : State {
	
	public State ctrl;
	public float slideDistance;
	public Vector3 start;
	public StateData stateData;
	public CharacterController characterController;
	float _acceleration;

	public void OnEnable() {
		if(stateData == null){
			stateData = GetComponent<StateData>();
		}
		start = transform.position;
		characterController = GetComponent<CharacterController>();
	}

	void Update () {
		Vector3 dir = stateData.Direction;
		float currentDistance = Vector3.Distance(start, transform.position);
		characterController.Move(new Vector3(dir.x,0,dir.z) *Time.deltaTime * Mathf.Abs(_acceleration+0.3f) *10);
		_acceleration = 1-currentDistance/slideDistance;
		if(currentDistance>=slideDistance){
			GetComponent<MonoStateMachine>().DoTransition(this,ctrl);
		}
	}
	
}
