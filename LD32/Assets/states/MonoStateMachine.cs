using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

public class MonoStateMachine : MonoBehaviour {
    public void DoTransition(State from, State to) {
        GetComponentsInChildren<State>().ToList().ForEach((state) => {
            state.enabled = false;
        });
        to.enabled = true;
    }
	
	public void DoTransition(State to) {
        GetComponentsInChildren<State>().ToList().ForEach((state) => {
            state.enabled = false;
        });
        to.enabled = true;
    }
}

public abstract class State: MonoBehaviour{
	
}