using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rotate_object : MonoBehaviour {

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		float angle;
		angle= GameObject.Find("Sphere").GetComponent<SceneManeger>().Angle;
		transform.eulerAngles = new Vector3(10, angle, 0);

	}
}
