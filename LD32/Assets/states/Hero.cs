using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

public class Hero : MonoBehaviour {

	public NavMeshAgent agent;
	public static Hero Instance;
	public Vector3 currentDest;
	protected Movement mvment;
	public float range;

	public void Awake(){
		mvment = GetComponent<Movement>();
	}

	public void Init () {
		Instance = this;
		GetComponent<Movement>().enabled = true;
	}

	public bool AbleToMove{
		get{
			return mvment.enabled;
		}
	}

	public void SetDestination(Vector3 dest){
		currentDest = dest;
	}

	public void StartClimb() {
		MonoStateMachine stateMachine = GetComponent<MonoStateMachine>();
		stateMachine.DoTransition(GetComponent<ClimbUpDownState>());
	}

	public void StopClimb() {
		MonoStateMachine stateMachine = GetComponent<MonoStateMachine>();
		stateMachine.DoTransition(mvment);
	}


	public void OnDrawGizmos(){
		Gizmos.color = Color.cyan;
		Gizmos.DrawWireSphere(transform.position,range);
	}
}
