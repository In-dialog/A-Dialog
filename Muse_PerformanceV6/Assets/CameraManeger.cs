using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraManeger : MonoBehaviour {
	public  Canvas options;
	public  Canvas Info;

	public Camera InfoDispaly;
	public Camera GameDisplay;


	// Use this for initialization
	void Start () {
		if (Display.displays.Length > 1) {
			Display.displays [1].Activate ();

			Info.worldCamera = InfoDispaly;
			options.worldCamera = InfoDispaly;
		}else {
			Debug.Log ("Hello|");
						Info.worldCamera = GameDisplay;
						options.worldCamera = GameDisplay;
		}
	}
	// Update is called once per frame
	void Update () {

}
}
