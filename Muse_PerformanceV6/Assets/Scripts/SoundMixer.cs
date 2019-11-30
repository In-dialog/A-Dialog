using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;

public class SoundMixer : MonoBehaviour {
	GameObject SymbolGenerator;
	public AudioMixer masterMixer;



	// Use this for initialization
	void Start () {
		SymbolGenerator	= GameObject.Find ("SymbolGenerator");
	}

	void  Update () {
		float GamaVolume = (SymbolGenerator.GetComponent< Reveal_Symbol> ().Gama).Remap(-1,1,-25,0);
		masterMixer.SetFloat ("LowPass", GamaVolume);

		float DelatVolume = (SymbolGenerator.GetComponent< Reveal_Symbol> ().Beta).Remap(-1,1,-30,0);
		masterMixer.SetFloat ("HighPass", DelatVolume);

			float ThetaVolume = (SymbolGenerator.GetComponent< Reveal_Symbol> ().Theta).Remap(-1,1,-30,5);
		masterMixer.SetFloat ("MidPass", ThetaVolume);
	}




}
