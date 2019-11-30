using UnityEngine;
using UnityEngine.UI;
//using UnityEngine.SceneManagement;

public class Restart : MonoBehaviour
{
	float GoX,GoY;
	float TeshHold = 45000;

	float Time;
	float LastTime;



	void Update ()
	{
		GameObject Reciver = GameObject.Find ("OSCReciver");

		GoX = Reciver.GetComponent< UniOSC.OSC_Data > ().GyX;
		GoY = Reciver.GetComponent< UniOSC.OSC_Data > ().GyY;

		float Shake = (Mathf.Abs(GoX) * Mathf.Abs(GoY));
		if (Shake > TeshHold) {
			Time++;
			if (Time > 2) {
				Debug.Log ("Restart");
				Application.LoadLevel(Application.loadedLevelName);
			}
		} else {
			Time = 0;
		}


		if( Input.GetKeyDown(KeyCode.R) )
		{
			Application.LoadLevel(Application.loadedLevelName);
		}


		if( Input.GetKeyDown(KeyCode.O) )
		{

			GameObject.Find ("UICamera").GetComponent<Camera>().cullingMask ^= 1 << LayerMask.NameToLayer("UIOptions");
			GameObject.Find ("CameraMain").GetComponent<Camera>().cullingMask ^= 1 << LayerMask.NameToLayer("UIOptions");


		}
		if( Input.GetKeyDown(KeyCode.P) )
		{
			GameObject.Find ("UICamera").GetComponent<Camera>().cullingMask ^= 1 << LayerMask.NameToLayer("Display");
			GameObject.Find ("CameraMain").GetComponent<Camera>().cullingMask ^= 1 << LayerMask.NameToLayer("Display");



		}



		if (Input.GetKeyDown (KeyCode.J)) {

		GameObject.Find ("CameraMain").GetComponent< Funnel.Funnel > ().enabled = !GameObject.Find ("CameraMain").GetComponent< Funnel.Funnel > ().enabled;

		}
	}


	void OnLevelWasLoaded(int level) {
		Debug.Log ("It Has been Done ");

		GameObject.Find ("UICamera").GetComponent<Camera>().cullingMask &=  ~(1 << LayerMask.NameToLayer("UIOptions"));
		GameObject.Find ("UICamera").GetComponent<Camera>().cullingMask &=  ~(1 << LayerMask.NameToLayer("Display"));
		GameObject.Find ("CameraMain").GetComponent<Camera>().cullingMask ^= 1 << LayerMask.NameToLayer("UIOptions");
		GameObject.Find ("CameraMain").GetComponent<Camera>().cullingMask ^= 1 << LayerMask.NameToLayer("Display");


//		float ValueX = PlayerPrefs.GetFloat ("AxisX");

		GameObject.Find ("SliderX").GetComponent<Slider>().value = PlayerPrefs.GetFloat ("AxisX");
		GameObject.Find ("SliderY").GetComponent<Slider>().value = PlayerPrefs.GetFloat ("AxisY");
		GameObject.Find ("SliderSpeed").GetComponent<Slider>().value = PlayerPrefs.GetFloat ("Speed");
		GameObject.Find ("SpliderPlaneControl").GetComponent<Slider>().value = PlayerPrefs.GetFloat ("PlanePosition");
		GameObject.Find ("SpliderCameraControl").GetComponent<Slider>().value = PlayerPrefs.GetFloat ("CameraPosition");





//		Debug.Log (ValueX);



	}




}