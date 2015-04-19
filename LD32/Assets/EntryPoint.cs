using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

public class EntryPoint : MonoBehaviour {

	public Hero hero;
	public GameObject boss;
	public GameObject gameOverPrefab;
	public SmoothOperator operatorCam;

	public static Hero StaticHero;

	Vector3 playerLatestPosition;
	public void Awake(){
		StaticHero = hero;
		List<MineGuy> mineGuys = GameObject.FindObjectsOfType<MineGuy>().ToList();

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

	bool restarted;
	public IEnumerator RestartCountDown(){
		yield return new WaitForSeconds(5.0f);
		Application.LoadLevel("main");
	}

	public void Update(){
		if(hero != null){
			playerLatestPosition = hero.transform.position;
		}

		if((hero == null || boss == null) && !restarted){
			restarted = true;
			operatorCam.targetFov = 10;
			Instantiate(gameOverPrefab,playerLatestPosition+=new Vector3(0,20,0),gameOverPrefab.transform.rotation);
			StartCoroutine(RestartCountDown());
		}
	}

}
