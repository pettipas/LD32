using UnityEngine;
using System.Collections;

public class Spawner : MonoBehaviour {

	public float duration;
	public GameObject enemyPrefab;
	public ParticleSystem spawnerSystem;
	public int total;

	public void OnEnable(){
		spawnerSystem.enableEmission = false;
		StartCoroutine(Spawn());
	}

	public IEnumerator Spawn(){
		if(duration == 0){
			duration = 60;
		}
		yield return new WaitForSeconds(duration);
		total--;
		spawnerSystem.enableEmission = true;
		yield return new WaitForSeconds(2);
		Instantiate(enemyPrefab,transform.position,transform.rotation);
		yield return new WaitForSeconds(1);
		spawnerSystem.enableEmission = false;
		if(total > 0){
			StartCoroutine(Spawn());
		}
	}

}
