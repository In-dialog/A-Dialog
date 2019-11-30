using UnityEngine;
using System;
using System.Linq;
using System.Collections;
using System.Collections.Generic;

public class SceneManeger : MonoBehaviour {

	float DistanceFromOrigin;
	public int OriginalDistance=22;
	public int MaximDistance=290;

	public float Angle;

	public Vector3 Position;

	public float Hight;

	string  Zone;

	public string SendCoordenates ='A' + 0 + "," + 0 +","+ 0;

	char KeyPressed='B';

	public GameObject SfereTT;
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {

		detectPressedKeyOrButton ();

		switch (KeyPressed) {
		
		case 'A':
			Hight = GameObject.Find("SferereTT").GetComponent<SecoundSfere>().DistanceToCenter;
			GetDIstance ();
			GetAngle ();
			Zone="A";
			this.gameObject.GetComponent<DrawSimbol>().enabled = true;
		
		break;

		case 'B':
			this.gameObject.GetComponent<DrawSimbol>().enabled = false;
			ControlManual();
			Zone="B";
		break;

		case 'c':
			Zone="C";
		break;


		}

			

		ComposeString ();

}
	void GetDIstance(){
		Position = this.gameObject.transform.position;
		DistanceFromOrigin = Vector3.Distance(this.gameObject.transform.position, new Vector3(0,0,0));
		DistanceFromOrigin=DistanceFromOrigin*10;
//		DistanceFromOrigin = DistanceFromOrigin .Remap(0,290, 0, 25); 

//		DistanceFromOrigin = DistanceFromOrigin.Remap(0,OriginalDistance, 0, MaximDistance); 

	}

	void GetAngle(){
		if (transform.position.z >= 0 && transform.position.x >= 0 ) {
			Vector3 Stable = new Vector3(0, 0, 12);
			Vector3 ObjPos = this.transform.position;
			Angle = Vector3.Angle(Stable, ObjPos);

		}
		if (transform.position.x >= 0 && transform.position.z <= 0 ) {
			Vector3 Stable = new Vector3(12, 0, 0);
			Vector3 ObjPos = this.transform.position;
			Angle = Vector3.Angle(Stable, ObjPos);
			Angle=Angle+90F;
		}
		if (transform.position.z <= 0 && transform.position.x <= 0 ) {
			Vector3 Stable = new Vector3(0, 0, -12);
			Vector3 ObjPos = this.transform.position;
			Angle = Vector3.Angle(Stable, ObjPos);;
			Angle=Angle+180F;
		}
		
		if (transform.position.x <= 0 && transform.position.z >= 0 ) {
			Vector3 Stable = new Vector3(-12, 0, 0);
			Vector3 ObjPos = this.transform.position;
			Angle = Vector3.Angle(Stable, ObjPos);
			Angle=Angle+270F;
		}
	}

	void ControlManual(){
	
		if (Input.GetKeyDown  (KeyCode.UpArrow)) {
			DistanceFromOrigin++;
		

		} else {
			if (Input.GetKeyDown  (KeyCode.DownArrow)) {
				DistanceFromOrigin--;
			}
		}


		if (Input.GetKeyDown (KeyCode.RightArrow)) {
			Angle++;
		} else {
			if (Input.GetKeyDown (KeyCode.LeftArrow)) {
				Angle ++;
			} 
		}


		if (Input.GetKeyDown (KeyCode.Tab)) {
			Hight++;
		} else {
			if (Input.GetKeyDown(KeyCode.Space)) {
				Hight--;
			} 
		}


//		Debug.Log(Angle);
	}
	

	void ComposeString(){


		Hight = (int)Hight;
		Angle = (int)Angle; 
		DistanceFromOrigin  = (int)DistanceFromOrigin ;

		SendCoordenates = Zone + Angle + "," +DistanceFromOrigin +","+ Hight;
//		Debug.Log(SendCoordenates );
	}



	 void detectPressedKeyOrButton()
	{
		if (Input.GetKey ("a")) {
			KeyPressed='A';	
		}
		if (Input.GetKey ("b")) {
			KeyPressed='B';	
		}
		if (Input.GetKey ("c")) {
			KeyPressed='C';	
		}



//		Debug.Log(KeyPressed);
	}



}
