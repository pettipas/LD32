using UnityEngine;
using System.Collections;

public class TakeDamageState : State {
	
	public StateData stateData;
	public float slideDistance;
	public Vector3 start;
	float _acceleration;
	public State ctrl;
	public Vector3 slideDir;
	public CharacterController characterController;
	public Vector3 potentialPosition;
	public NavMeshAgent navMeshAgent;
	protected float damage;


	public float Damage{
		set{
			damage = value;
		}
		get{
			return damage;
		}
	} 

	public void OnEnable() {
		slideDir = stateData.PushDir;

		if(stateData == null){
			stateData = GetComponent<StateData>();
		}
		start = transform.position;
		potentialPosition = start;
		if(characterController == null){
			characterController = GetComponent<CharacterController>();
		}
		if(navMeshAgent) navMeshAgent.enabled = false;
	}

	public void OnDisable(){
		if(navMeshAgent) navMeshAgent.enabled = true;
	}

	public void Renew(){
		start = transform.position;
		potentialPosition = start;
	}

	public void Update() {

		potentialPosition += new Vector3(slideDir.x,0,slideDir.z) *Time.deltaTime * Mathf.Abs(_acceleration+0.5f) *10;

		float poetentialDistance = Vector3.Distance(start, potentialPosition);
		float currentDistance = Vector3.Distance(start, transform.position);

		characterController.Move(new Vector3(slideDir.x,0,slideDir.z) *Time.deltaTime * Mathf.Abs(_acceleration+0.5f) *10);

		_acceleration = 1-currentDistance/slideDistance;
		if(currentDistance>=slideDistance
		   || poetentialDistance >= slideDistance)
		{
			Vitality v = GetComponent<Vitality>();
			if(v)v.TakeHit();
			GetComponent<MonoStateMachine>().DoTransition(this,ctrl);
		}
	}

	public void OnDrawGizmos(){
		Gizmos.DrawSphere(potentialPosition,0.1f);
	}
}
