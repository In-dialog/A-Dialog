using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SecoundSfere : MonoBehaviour {
	public float DistanceToCenter;
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		DistanceToCenter = Vector3.Distance(this.gameObject.transform.position, new Vector3(0,0,0));
		DistanceToCenter = DistanceToCenter*10;	





		Vector3 position= GameObject.Find("Sphere").GetComponent<SceneManeger>().Position;


		Vector3 pointGreen = Vector3.Lerp(position*(-2), new Vector3(0,0,0), 0.5f);


		transform.position = pointGreen;

	
}
}
