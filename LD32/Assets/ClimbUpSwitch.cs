using UnityEngine;
using System.Collections;

public class ClimbUpSwitch : MonoBehaviour {

	public Hero hero;

	public void OnTriggerEnter(Collider other){
		Hero hero = other.GetComponent<Hero>();
		if(hero){
			this.hero = hero;
		}
	}
	public void OnTriggerExit(Collider other){
		Hero hero = other.GetComponent<Hero>();
		if(hero){
			this.hero = null;
		}
	}

	void Update(){
		if(!hero){
			return;
		}

		ClimbUpDownState climb = hero.GetComponent<ClimbUpDownState>();
		StateData data = hero.GetComponent<StateData>();

		if(Input.GetAxis("Vertical") < 0 
		   && hero.transform.position.y < transform.position.y
		   ){
			data.Height = transform.position.y;
			hero.StopClimb();
			return;
		}

		if(Input.GetAxis("Vertical") > 0 
		   && !climb.enabled
		   ){
			//snap to ladder
			Vector3 pos = hero.transform.position;
			Vector3 switchPos = transform.position;
			hero.transform.position = new Vector3(switchPos.x,pos.y,switchPos.z);
			hero.StartClimb();
		}

	}

}
