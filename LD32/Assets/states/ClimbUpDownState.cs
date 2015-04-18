using UnityEngine;
using System.Collections;

public class ClimbUpDownState : State {

	public StateData data;
	public float speed = 1;
	[SerializeField]protected Transform body;
	

	public void OnEnable()
	{
		body.transform.forward = new Vector3(0,0,0);
		if(data == null){
			data = GetComponent<StateData>();
		}
	}

	void Update () {
		transform.Translate(new Vector3(0,data.Direction.z,0) * speed * Time.deltaTime);
	}
}
