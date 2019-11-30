using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

public class GenerateSymbol : MonoBehaviour {

	public GameObject prefab;
	float Angle=0;
	float Angle1=0;
	float Angle2=90;
	Vector3 center = new Vector3(0,0,0);

	public float Exitment;
	public float Engagement;
	public float Focused;

	public float Calme;
	public float Relax;
	public float UNInterested;

	 float Arraousal;
	 float NonArraousal;

	 float Pleasent;
	 float UnPleasent;


	 float SUM1 = 0;
	 float SUM2 = 0;
	 float SUM3 = 0;
	 float SUM4 = 0;

	public List<float> States1 = new List<float>( );
	public List<float> States11 = new List<float>( );

	public List<float> States2 = new List<float>( );
	public List<float> States22 = new List<float>( );


	void Start() {


		GetData ();

		for (int q=0; q<3; ++q) {
			Angle1=Angle1+22.5F;
			SortDataAndPositionPoints(States1,States11,SUM1,SUM2,q,Angle1); 
			SUM1 = States1[q];
			SUM2 = States11[q];
		}

		for (int p=0; p<3; ++p) {
			Angle2=Angle2+22.5F;
			SortDataAndPositionPoints(States2,States22,SUM3,SUM4,p,Angle2);
			SUM3 = States2[p];
			SUM4 = States22[p];
		}




		Arraousal = (SUM1 + SUM4) / 2;
		NonArraousal = (SUM3 + SUM2) / 2;
		Pleasent = (SUM1 + SUM2) / 2;
		UnPleasent = (SUM3 + SUM4) / 2;

//		CreatePoint (center, Arraousal, 0);
//		CreatePoint (center, NonArraousal, 180);
//		CreatePoint (center, Pleasent, 90);
//		CreatePoint (center, UnPleasent, 270);



	}

	void Update () {
		
		//		if (gameObject.GetComponent<Go_to_object>().New_list){
		
	}





	void GetData(){
		if (States1.Count == 0 && States11.Count == 0&&States11.Count == 0&&States2.Count == 0&&States22.Count == 0) {
			
			States1.Add (Exitment);
			States1.Add (Engagement);
			States1.Add (Focused);
			
			States2.Add (Calme);
			States2.Add (Relax);
			States2.Add (UNInterested);
			
			for (int i=0; i<3; ++i) {
				States11.Add (1);
				States22.Add (1);
			}
			
		}
	}
	void SortDataAndPositionPoints(List<float> List1,List<float> List2,float Sum1,float Sum2,int i,float Angle){

		if (List1 [i] > 30) {
			List1 [i] =  List1 [i].Remap (30, 60, 0, 30);
			List2 [i] = 1;
			CreatePoint (center, List1[i], Angle);
			
		} else {
			
			List2[i] = List1 [i];
			List1 [i] = 1;
			CreatePoint (center, List2 [i], Angle + 180);
		}


//		Sum1 = Sum1 +  List1[i];
//		Sum2 = Sum2 +  List2[i];

	}






	Vector3 RandomCircle ( Vector3 center ,   float radius, float ang){
		Vector3 pos;
		pos.x = center.x + radius * Mathf.Sin(ang * Mathf.Deg2Rad);
		pos.z = center.z + radius * Mathf.Cos(ang * Mathf.Deg2Rad);
		pos.y = center.y;
		return pos;
	}
	
	void CreatePoint(Vector3 center , float radius, float ang){
		Vector3 pos = RandomCircle(center, radius,ang);
		Quaternion rot = Quaternion.FromToRotation(Vector3.forward, center-pos);
		Instantiate(prefab, pos, rot);
	}



}


