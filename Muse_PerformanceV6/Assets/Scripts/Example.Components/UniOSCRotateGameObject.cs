/*
* UniOSC
* Copyright © 2014-2015 Stefan Schlupek
* All rights reserved
* info@monoflow.org
*/
using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using System;
using OSCsharp.Data;
using UnityStandardAssets.ImageEffects;

namespace UniOSC{

	/// <summary>
	/// Rotates (localRotation) the hosting game object.
	/// For every axis you have a separate OSC address to specify
	/// </summary>
//	[AddComponentMenu("UniOSC/RotateGameObject")]
	public class UniOSCRotateGameObject :  UniOSCEventTarget {

		#region public
		[HideInInspector]
		public Transform transformToRotate;

		public string D_Address = "/muse/elements/delta_absolute";
		public string T_Address = "/muse/elements/theta_absolute";
		public string A_Address = "/muse/elements/alpha_absolute"; 
		public string B_Address = "/muse/elements/beta_absolute";
		public string G_Address = "/muse/elements/gama_absolute";
		public string GY_Address = "/muse/acc";
		public float Dx,Tx,Ax,Bx,Gx,GYx,GYy;
//		public float x_RotationFactor;
//		public float y_RotationFactor;
//		public float z_RotationFactor;
		#endregion

		#region private
//		private Vector3 eulerAngles;
//		private Quaternion rootRot;

//		private Quaternion rx,ry,rz;
		#endregion


		void Awake(){

		}

		public override void OnEnable(){
			_Init();
			base.OnEnable();
		}

		private void _Init(){
			
			//receiveAllAddresses = false;
			_oscAddresses.Clear();
			if(!_receiveAllAddresses){
				_oscAddresses.Add(D_Address);
				_oscAddresses.Add(T_Address);
				_oscAddresses.Add(A_Address);
				_oscAddresses.Add(B_Address);
				_oscAddresses.Add(G_Address);
				_oscAddresses.Add(GY_Address);
			}
//			cx=0f;cy=0f;cz=0f;
//			if(transformToRotate == null){
//				Transform hostTransform = GetComponent<Transform>();
//				if(hostTransform != null) transformToRotate = hostTransform;
//			}
//			
//			rootRot = transformToRotate.localRotation;
		}
	

		public override void OnOSCMessageReceived(UniOSCEventArgs args){
		
			if(transformToRotate == null) return;

			OscMessage msg = (OscMessage)args.Packet;

			if(msg.Data.Count <1)return;
			if(!( msg.Data[0] is System.Single))return;

			float value = (float)msg.Data[0];

			if(String.Equals(args.Address,D_Address))Dx = value;
			if(String.Equals(args.Address,T_Address))Tx = value;
			if(String.Equals(args.Address,A_Address))Ax = value;
			if(String.Equals(args.Address,B_Address))Bx = value;
			if(String.Equals(args.Address,G_Address))Gx = value;


			if (String.Equals (args.Address, GY_Address)) {
				GYy = (float)msg.Data[1];
				GYx = (float)msg.Data[0];
			}

//			GYx = GYx.Remap(-0.6f,0.6f,0.5f,2.5f);
//
//			GameObject.Find("SymbolGenerator").GetComponent<Reveal_Symbol>().Rotation = GYy * 50;
//
//			GameObject.Find("SymbolGenerator").GetComponent<Reveal_Symbol>().Delat = Dx * 100;
//			GameObject.Find("SymbolGenerator").GetComponent<Reveal_Symbol>().Theta = Tx * 100;
//			GameObject.Find("SymbolGenerator").GetComponent<Reveal_Symbol>().Alpha = Ax * 100;
//			GameObject.Find("SymbolGenerator").GetComponent<Reveal_Symbol>().Beta =  Bx * 100;




		}


	}

}