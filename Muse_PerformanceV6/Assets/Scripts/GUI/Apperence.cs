using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Apperence : MonoBehaviour {

	public float CameraPosition;
	public float PlanePosition;

	Vector3 Camera;
	Vector3 Plane;


	// Use this for initialization
	void Start () {

	}
	
	// Update is called once per frame
	void Update () {


		Camera = new Vector3 (0,CameraPosition,0);
		Plane = new Vector3 (0,PlanePosition,0);


//		move (GameObject.Find ("CameraMain"), Camera);


		float step = 20 * Time.deltaTime;

		GameObject.Find ("Pase").transform.position = Vector3.MoveTowards(GameObject.Find ("Pase").transform.position, Plane, step);
		GameObject.Find ("CameraMain").transform.position = Vector3.MoveTowards(GameObject.Find ("CameraMain").transform.position, Camera, step);



		GameObject Reciver = GameObject.Find ("SymbolGenerator");

		float ValueDelat = (Reciver.GetComponent< Reveal_Symbol >().Delat).Remap(-1,0,0,0.19F);
		float ValueTheta = (Reciver.GetComponent< Reveal_Symbol>().Theta).Remap(-1,0,0,0.19F);
		float ValueAlpha = (Reciver.GetComponent< Reveal_Symbol >().Alpha).Remap(-1,0,0,0.19F);
		float ValueBeta  = (Reciver.GetComponent< Reveal_Symbol >().Beta).Remap(-1,0,0,0.19F);
		float ValueGamma = (Reciver.GetComponent< Reveal_Symbol>().Gama).Remap(-1,0,0,0.19F);

//
//		Debug.Log(ValueGamma);
//		if (ValueGamma )
//		{
//			
//		}
			GameObject.Find ("Delta").transform.localScale = new Vector3 (0.003F, ValueDelat, 1F);
			GameObject.Find ("Theta").transform.localScale = new Vector3 (0.003F, ValueTheta, 1F);
			GameObject.Find ("Alpha").transform.localScale = new Vector3 (0.003F, ValueAlpha, 1F);
			GameObject.Find ("Beta").transform.localScale = new Vector3 (0.003F, ValueBeta, 1F);
			GameObject.Find ("Gama").transform.localScale = new Vector3 (0.003F, ValueGamma, 1F);



	}


}
