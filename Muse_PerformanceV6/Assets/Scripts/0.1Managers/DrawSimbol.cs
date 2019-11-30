using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using System.Linq;


public class DrawSimbol : MonoBehaviour {

	public List<GameObject> objects1 = new List<GameObject>();
	public GameObject object1;
	
	public Transform[] target;
	public Transform bestTarget;
	public float speed;

	public int caseSwitch;
	int time;
	int timeR = 22; 

	float rotationleft=720;
	public float rotationspeed=50;

	public bool New_list;
	public bool ReadyToMove;

	 Vector3 LastPos;
	 Vector3 CurentPos;

	float SetDis;
	public float TargetDis;
	 
	public bool ZaxisUp;

	public bool NewObject;

	void Start () {
		CreateList ();
		TargetList ();
		ItereteList ();
		caseSwitch=1;
	}

	void Update () {
		
		
		GetClosestEnemy (target);
		ItereteList ();
		TargetDis = Vector3.Distance(this.gameObject.transform.position, object1.gameObject.transform.position);

		
	
		switch (caseSwitch) {
		case 1:
			NewObject = false;
			Move (1);
			break;
		case 2:
			NewObject = true;
			Move (2);
			break;
		case 3:
			SetDis = 4F;
			if (TargetDis > SetDis){
				Move (3);
				rotationleft=1440;
				NewObject = true;
				
			}else{
				NewObject = false;
				Circle();
			}
			break;
		case 4:
			SetDis = 2F;
			if (TargetDis > SetDis){
				Move (3);
				NewObject = true;
				rotationleft=360;
			}else{
				Circle();
				NewObject = false;
				
			}


			break;
		}



		if (objects1.Count == 0) {
			NewObject = true;
			CreateList ();
			TargetList ();
			caseSwitch = caseSwitch + 1;
		} else {
			New_list = false;
//			NewObject = false;

		}

		if (caseSwitch==5) {
			New_list = true;

			caseSwitch=1;

		}
		
	}
	
	
	
	
	void Circle(){
		if(ReadyToMove){
		Move (1);
		}else{Move (4);}
	}
	
	
	


	void ItereteList(){
		for (int i = 0; i < target.Length; ++i) { 
			if(bestTarget==target[i]){
				object1=objects1[i];
				float Dist = Vector3.Distance(this.gameObject.transform.position, object1.gameObject.transform.position);
				
				if (Dist<0.1F && time>timeR ){
					ReadyToMove=false;
					objects1.RemoveAt(i);
		
					TargetList();
					time=0;

				}else{time ++;}
			}
		}
	}

//	void ItereteList(){
//		for (int i = 0; i < objects1 .Count; ++i) { 
//
//			if (bestTarget == target [i]) {
//				object1 = objects1 [i];
//
//				if (TargetDis<0.2F && time>timeR){
//					ReadyToMove=false;
//					objects1.RemoveAt(i);
//					TargetList();
//				}else{time ++;}
//
//			}
//		}
//	}


	void Move(int Type){
		float step = speed * Time.deltaTime;
//		if(gameObject.GetComponent<SendString> ().IM){
		switch (Type) {
		case 1:
			transform.position = Vector3.MoveTowards (this.gameObject.transform.position, object1.transform.position, step * 10);
			break;

		case 2:
			transform.position = Vector3.RotateTowards (this.gameObject.transform.position, object1.transform.position, (speed * Time.deltaTime), 0.1F);
			break;

		case 3:
			transform.position = Vector3.RotateTowards (this.gameObject.transform.position, object1.transform.position, (speed * Time.deltaTime), 0.1F);
			float Dist = Vector3.Distance (this.gameObject.transform.position, object1.gameObject.transform.position);
			Vector3 TargetPosition = object1.transform.position;
			float move = Dist * Time.deltaTime;
			this.gameObject.transform.position = Vector3.MoveTowards (this.gameObject.transform.position, TargetPosition, move);
			break;
		case 4:

			float rotation=rotationspeed*Time.deltaTime;
			if (rotationleft > rotation)
			{
				ReadyToMove=false;
				rotationleft-=rotation;
			}
			else
			{

				rotation=rotationleft;
				rotationleft=0;
				ReadyToMove=true;
			}
			transform.RotateAround(object1.transform.position, Vector3.up,rotation);
			break;
		}

			


//		}


	}
	
	
	void CreateList(){
		objects1 = GameObject.FindGameObjectsWithTag ("FD").ToList();
		
		
	}
	
	void TargetList(){
		target =new Transform[objects1.Count];
		for (int i = 0; i < objects1.Count; ++i) {
			target [i] = objects1[i].transform;
		}
	}
	
	
	Transform GetClosestEnemy (Transform[] enemies)
	{
		bestTarget = null;
		float closestDistanceSqr = Mathf.Infinity;
		Vector3 currentPosition = transform.position;
		foreach(Transform potentialTarget in enemies)
		{
			Vector3 directionToTarget = potentialTarget.position - currentPosition;
			float dSqrToTarget = directionToTarget.sqrMagnitude;
			if(dSqrToTarget < closestDistanceSqr)
			{
				closestDistanceSqr = dSqrToTarget;
				bestTarget = potentialTarget;
			}
		}
		
		return bestTarget;
	}
	
}