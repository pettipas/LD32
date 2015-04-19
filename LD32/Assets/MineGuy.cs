using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class MineGuy : MonoBehaviour {

	public float timer;
	public Transform body;
	public CharacterController ctrl;
	public Animator mineAnimator;
	public List<Transform> waypoints = new List<Transform>();
	public Transform walkTarget;
	public GameObject projPrefab;
	public bool turretMode;
	public Transform player;
	public Transform launchPoint;
	public int index = 0;
	public void Start(){
		StartCoroutine(GoToWayPoint());
	}

	public float attackTimer;

	public IEnumerator AttackForTime(){
		attackTimer = 0;
		while(attackTimer < 10.0f){

			Vector3 d = (player.position - transform.position).normalized;
			d = new Vector3(d.x,0,d.z);
			body.transform.forward = d;
			mineAnimator.Play("attack");
			timer+=Time.deltaTime;
			if(timer > 3){
				timer = 0;
				GameObject p = Instantiate(projPrefab,launchPoint.transform.position,Quaternion.identity) as GameObject;
				p.GetComponent<Projectile>().Fire(launchPoint);
			}

			attackTimer+=Time.deltaTime;
			yield return null;
		}

		StartCoroutine(GoToWayPoint());
		yield break;
	}

	public IEnumerator GoToWayPoint(){

		index++;
		if(index >= waypoints.Count){
			index = 0;
		}
		walkTarget = waypoints[index];

		while(Vector3.Distance(walkTarget.position,transform.position) > 1){
			Vector3 dir = (walkTarget.position - transform.position).normalized;
			ctrl.Move(dir *3f*Time.smoothDeltaTime);
			dir = new Vector3(dir.x,0,dir.z);
			body.transform.forward = dir;
			mineAnimator.Play("mineguy");
			yield return null;
		} 
		
		StartCoroutine(AttackForTime());
	}

	public void OnDrawGizmos(){
		waypoints.ForEach(wp=>{
			Gizmos.color = Color.yellow;
			Gizmos.DrawSphere(wp.position,0.3f);
		});
	}
}
