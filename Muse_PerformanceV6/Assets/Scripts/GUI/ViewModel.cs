using UnityEngine;
using System.Collections;
using UnityEngine.UI;



public class ViewModel : MonoBehaviour 
{
    public Text IPText;

	void Start(){
		
		string Ip = Network.player.ipAddress;
		IPText.text = Ip;
	}

	public void Slider_TresholdAxiX(float newValue)
    {
		PlayerPrefs.SetFloat ("AxisX", newValue);
		GameObject.Find ("SymbolGenerator").GetComponent< Reveal_Symbol> ().TresholdAxiX = newValue;
//		Debug.Log (newValue);
    }

	public void Slider_TresholdAxiY(float newValue)
	{
		PlayerPrefs.SetFloat ("AxisY", newValue);
		GameObject.Find ("SymbolGenerator").GetComponent< Reveal_Symbol> ().TresholdAxiY = newValue;
	}

	public void Slider_Speed(float newValue)
	{
		PlayerPrefs.SetFloat ("Speed", newValue);
		GameObject.Find ("SymbolGenerator").GetComponent< Reveal_Symbol> ().speed = newValue;
	}



	public void Slider_Camera(float newValue)
	{
		PlayerPrefs.SetFloat ("CameraPosition", newValue);
		GameObject.Find ("manager").GetComponent< Apperence> ().CameraPosition = newValue;
	}

	public void Slider_Plane(float newValue)
	{
		PlayerPrefs.SetFloat ("PlanePosition", newValue);
		GameObject.Find ("manager").GetComponent< Apperence> ().PlanePosition = newValue;
	}






//
//    public void Button_Click()
//    {
//        Debug.Log("Hello, World!");
//
//		GameObject.Find ("CameraMain").GetComponent< Funnel.Funnel >().enabled = !GameObject.Find ("CameraMain").GetComponent< Funnel.Funnel >().enabled;
//    }
////
//    public void Button_String(string msg)
//    {
//        buttonText.text = msg;
//    }
//
//    public void Toggle_Changed(bool newValue)
//    {
//        cube.SetActive(newValue);
//        slider.interactable = newValue;
//    }
//
//    public void Text_Changed(string newText)
//    {
//        float temp = float.Parse(newText);
//        cube.transform.localScale = new Vector3(temp, temp, temp);
//    }

}
