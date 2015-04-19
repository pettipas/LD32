using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

public class Hero : MonoBehaviour {


	public List<GameObject> glasses = new List<GameObject>();
	public List<GameObject> hearts = new List<GameObject>();
	public static Hero Instance;
	public Vector3 currentDest;
	protected Movement mvment;
	public Vitality vitality;

	public void Awake(){
		mvment = GetComponent<Movement>();
		SetGlasses();
	}

	void SetGlasses(){
		int index = vitality.hits-1;
		for(int i = 0; i < glasses.Count;i++){
			if(i != index){
				glasses[i].GetComponent<MeshRenderer>().enabled = false;
			}else {
				glasses[i].GetComponent<MeshRenderer>().enabled = true;
			}

			if(i<=index){
				hearts[i].GetComponent<MeshRenderer>().enabled = true;
			}else {
				hearts[i].GetComponent<MeshRenderer>().enabled = false;
			}
		}
	}

	public void Update(){
		SetGlasses();
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

}
