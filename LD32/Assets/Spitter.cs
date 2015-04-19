using UnityEngine;
using System.Collections;

public class Spitter : MonoBehaviour {

	public GameObject projPrefab;
	public Transform launchPoint;
	public Animator spitter;

	public void Awake(){
		StartCoroutine(SpitSpikes());
	}

	public IEnumerator SpitSpikes(){
		spitter.Play("spit",0,0);
		GameObject p = Instantiate(projPrefab,launchPoint.transform.position,Quaternion.identity) as GameObject;
		p.GetComponent<SmallProjectile>().Fire(launchPoint);
		yield return new WaitForSeconds(1);
		spitter.Play("spit",0,0);
		GameObject p2 = Instantiate(projPrefab,launchPoint.transform.position,Quaternion.identity) as GameObject;
		p2.GetComponent<SmallProjectile>().Fire(launchPoint);
		yield return new WaitForSeconds(1);
		spitter.Play("spit",0,0);
		GameObject p3 = Instantiate(projPrefab,launchPoint.transform.position,Quaternion.identity) as GameObject;
		p3.GetComponent<SmallProjectile>().Fire(launchPoint);
		yield return new WaitForSeconds(1);
		spitter.Play("rest_from_spitting");
		yield return new WaitForSeconds(5);
		StartCoroutine(SpitSpikes());
	}
}
