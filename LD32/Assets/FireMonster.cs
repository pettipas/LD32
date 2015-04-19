using UnityEngine;
using System.Collections;

public class FireMonster : MonoBehaviour {

	public CharacterController ctrl;
	public Transform walkTarget;
	public Transform body;
	public Animator fireAnimator; 
	public ParticleSystem particleSystem;

	public float lockHeight;

	public void Awake(){
		Hero hero = GameObject.FindObjectOfType<Hero>();
		walkTarget = hero.transform;
		StartCoroutine(Seek (5));
		particleSystem.enableEmission = false;
		fireAnimator.Play("hop");
		lockHeight = transform.position.y;
	}
	float walkTimer = 0;
	public IEnumerator Seek(float seekTime){
		walkTimer = 0;
		fireAnimator.Play("hop");
		while(walkTimer < seekTime){
			Vector3 dir = (walkTarget.position - transform.position).normalized;
			ctrl.Move(dir *1.5f*Time.smoothDeltaTime);
			dir = new Vector3(dir.x,0,dir.z);
			body.transform.forward = dir;
			walkTimer+=Time.deltaTime;
			yield return null;
		} 
		StartCoroutine(BlowFire());
		yield break;
	}

	public IEnumerator Run(float runTime){
		walkTimer = 0;
		fireAnimator.Play("hop");
		while(walkTimer < runTime){
			Vector3 dir = (transform.position - walkTarget.position).normalized;
			dir = new Vector3(dir.x,0,dir.z);
			ctrl.Move(dir *1.5f*Time.smoothDeltaTime);
			body.transform.forward = dir;
			walkTimer+=Time.deltaTime;
			yield return null;
		} 
		StartCoroutine(Seek(2));
		yield break;
	}

	public IEnumerator BlowFire(){
		fireAnimator.Play("fire");
		particleSystem.simulationSpace = ParticleSystemSimulationSpace.World;
		particleSystem.enableEmission = true;

		Ray ray = new Ray(transform.position,body.transform.forward);


		RaycastHit[] hits = Physics.SphereCastAll(ray,1.5f,5);

		foreach(RaycastHit rh in hits){
			Hero hero = rh.transform.GetComponent<Hero>();
			if(hero){
				hero.transform.GetComponent<Vitality>().TakeHit();
			}
		}
		yield return new WaitForSeconds(2);
		hits = Physics.SphereCastAll(ray,1,5);
		
		foreach(RaycastHit rh in hits){
			Hero hero = rh.transform.GetComponent<Hero>();
			if(hero){
				hero.transform.GetComponent<Vitality>().TakeHit();
			}
		}

		yield return new WaitForSeconds(1);
		particleSystem.enableEmission = false;
		if(Random.value > 0.7f){
			StartCoroutine(Run (3));
		}else {
			StartCoroutine(Seek (5));
		}
	}

	public void LateUpdate(){
		transform.position = new Vector3(transform.position.x,lockHeight,transform.position.z);
	}
}
