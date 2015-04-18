using UnityEngine;
using System.Collections;

public class StateData : MonoBehaviour {
	
	Vector3 dir;
	Vector3 pushDir;

	public Affiliation affiliation;
	public float height;

	public float Height{
		get {
			return height;
		} set {
			height = value;
		}
	}

	public void ForceDamage(Vector3 dir, float damage){
		pushDir = dir;
		TakeDamageState tdState = GetComponent<TakeDamageState>();
		tdState.Damage = damage;

		if(!tdState.enabled){
			GetComponent<MonoStateMachine>().DoTransition(tdState);
		}else {
			tdState.Renew();
		}
	}

	public void Update(){
		var deltax = Input.GetAxis("Horizontal");
		var deltaz = Input.GetAxis("Vertical");

		Direction = new Vector3(deltax,0,deltaz);
	}

	public Vector3 PushDir{
		get{return pushDir;}
		set{pushDir = value;}
	}
	
	public Vector3 Direction{
		get{return dir;}
		set{dir = value;}
	}
	
	public bool Moving{
		get {
			return (Mathf.Abs(dir.x) > 0 || 
					Mathf.Abs(dir.z) > 0);
		}
	}


}

public enum Affiliation{
	Good,
	Bad
}
