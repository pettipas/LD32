using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

public class EntryPoint : MonoBehaviour {

	public void Awake(){

		List<MineGuy> mineGuys = GameObject.FindObjectsOfType<MineGuy>().ToList();
		Hero hero = GameObject.FindObjectOfType<Hero>();

		mineGuys.ForEach(x=>{
			x.player =hero.transform;
		});

		List<Barrier> barriers = GameObject.FindObjectsOfType<Barrier>().ToList();
		barriers.ForEach(b=>{
			b.GetComponentsInChildren<BoxCollider>().ToList().ForEach(bc=>{
				bc.isTrigger = false;
			});
		});
	}
}
