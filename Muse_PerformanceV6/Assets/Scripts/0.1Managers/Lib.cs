using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Lib : MonoBehaviour {

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
public static class ExtensionMethods {

	public static float Remap (this float value, float from1, float to1, float from2, float to2) {
		return (value - from1) / (to1 - from1) * (to2 - from2) + from2;
	}

	public static Vector2 ToXZ(this Vector3 v3)
	{
		return new Vector2(v3.x, v3.z);
	}

	public static Texture2D toTexture2D(this RenderTexture rTex)
	{
		Texture2D tex = new Texture2D(512, 512, TextureFormat.RGB24, false);
		RenderTexture.active = rTex;
		tex.ReadPixels(new Rect(0, 0, rTex.width, rTex.height), 0, 0);
		tex.Apply();
		return tex;
	}


}