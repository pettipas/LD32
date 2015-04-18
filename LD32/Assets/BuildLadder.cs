using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class BuildLadder : MonoBehaviour {

	public GameObject section;
	public List<GameObject> rungs = new List<GameObject>();
	public int nums;
	public float spacing;

	[ContextMenu("Build")]
	public void Build(){
		rungs.ForEach(x=>{
			GameObject.DestroyImmediate(x.gameObject);
		});
		rungs.Clear();
		for(int i = 0; i < nums;i++){
			GameObject g = Instantiate(section,Vector3.zero,Quaternion.identity) as GameObject;
		
			g.transform.parent = transform;
			g.transform.position = new Vector3(0,i,0);
			rungs.Add(g);
		}
	}
}
