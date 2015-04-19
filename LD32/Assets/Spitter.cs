using UnityEngine;
using System.Collections;

public class Spitter : MonoBehaviour {

	public Transform body;
	public GameObject projPrefab;
	public Transform launchPoint;
	public Animator spitter;
	public float power;
	public Transform player;

	public void OnEnable(){
		player = EntryPoint.StaticHero.transform;
		StartCoroutine(SpitSpikes());
		body = transform.Find ("body");
	}

	public void Update(){

		if(player == null){
			return;
		}
		Vector3 dir = (player.position - transform.position).normalized;
		dir = new Vector3(dir.x,0,dir.z);
		body.forward = dir;
	}

	public IEnumerator SpitSpikes(){
		spitter.Play("spit",0,0);
		GameObject p = Instantiate(projPrefab,launchPoint.transform.position,Quaternion.identity) as GameObject;
		p.GetComponent<SmallProjectile>().Fire(launchPoint,power);
		yield return new WaitForSeconds(1);
		spitter.Play("spit",0,0);
		GameObject p2 = Instantiate(projPrefab,launchPoint.transform.position,Quaternion.identity) as GameObject;
		p2.GetComponent<SmallProjectile>().Fire(launchPoint,power);
		yield return new WaitForSeconds(1);
		spitter.Play("spit",0,0);
		GameObject p3 = Instantiate(projPrefab,launchPoint.transform.position,Quaternion.identity) as GameObject;
		p3.GetComponent<SmallProjectile>().Fire(launchPoint,power);
		yield return new WaitForSeconds(1);
		spitter.Play("rest_from_spitting");
		yield return new WaitForSeconds(5);
		StartCoroutine(SpitSpikes());
	}
}
