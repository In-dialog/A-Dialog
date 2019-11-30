using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using System;
using OSCsharp.Data;


namespace UniOSC{

//[AddComponentMenu("UniOSC/RotateGameObject")]

		public class OSC_Data :  UniOSCEventTarget {



			#region public
			
		public float  Delta, Theta, Alpha, Beta, Gamma, AX, AY, AZ,GyX,GyY,GyZ ;
		public float HorsShoe1, HorsShoe2, HorsShoe3,HorsShoe4;
			#endregion

			#region private
		string delta_absolute = "/muse/elements/delta_absolute";
		string theta_absolute = "/muse/elements/theta_absolute";
		string alpha_absolute = "/muse/elements/alpha_absolute";
		string beta_absolute = "/muse/elements/beta_absolute";
		string gamma_absolute = "/muse/elements/gamma_absolute";
		string acc = "/muse/acc";
		string gyros = "/muse/gyro";
		string Horshoe = "/muse/elements/horseshoe";

		float time;

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
				_oscAddresses.Add(delta_absolute);
				_oscAddresses.Add(theta_absolute);
				_oscAddresses.Add(alpha_absolute);
				_oscAddresses.Add(beta_absolute);
				_oscAddresses.Add(gamma_absolute);
				_oscAddresses.Add(acc);
				_oscAddresses.Add(gyros);
				_oscAddresses.Add(Horshoe);

				}

			}


			public override void OnOSCMessageReceived(UniOSCEventArgs args){


				OscMessage msg = (OscMessage)args.Packet;

				if(msg.Data.Count <1)return;
				if(!( msg.Data[0] is System.Single))return;

			if(msg.Data.Count <1)return;
			if(!( msg.Data[0] is System.Single))return;

			float value = (float)msg.Data[0];

			if (String.Equals (args.Address, delta_absolute))
				Delta = Truncate ((value * 100), 1);
			
				if (String.Equals (args.Address, theta_absolute))
				Theta = Truncate ((value * 100), 1);
	
				if (String.Equals (args.Address, alpha_absolute))
				Alpha = Truncate ((value * 100), 1);

				if (String.Equals (args.Address, beta_absolute))
				Beta = Truncate ((value * 100), 1);

				if (String.Equals (args.Address, gamma_absolute))
				Gamma = Truncate ((value * 100), 1);


				if (String.Equals (args.Address, acc)) {
					AX = (float)msg.Data [0]*100;
					AX = Truncate (AX, 0);
					AY = (float)msg.Data [1]*100;
					AY = Truncate (AY, 0);
					AZ = (float)msg.Data [2]*100;
					AZ = Truncate (AZ, 0);
				}



				if (String.Equals (args.Address, gyros)) {
					GyX = (float)msg.Data [0];
					GyX = Truncate (GyX, 4);
					GyY = (float)msg.Data [1];
					GyY = Truncate (GyY, 4);
					GyZ = (float)msg.Data [2];
					GyZ = Truncate (GyZ, 4);
				}


			if (String.Equals (args.Address, Horshoe)) {
				HorsShoe1 = (float)msg.Data [0];
				HorsShoe1 = Truncate (HorsShoe1, 4);

				HorsShoe2 = (float)msg.Data [1];
				HorsShoe2 = Truncate (HorsShoe2, 4);

				HorsShoe3 = (float)msg.Data [2];
				HorsShoe3 = Truncate (HorsShoe3, 4);

				HorsShoe4 = (float)msg.Data [3];
				HorsShoe4 = Truncate (HorsShoe4, 4);

			}


				
//			float filteredX = filterX.NextStep (Time.deltaTime, Input.acceleration.x);






			}
		public static float Truncate( float value, int digits)
		{
			double mult = Math.Pow(10.0, digits);
			double result = Math.Truncate( mult * value ) / mult;
			return (float) result;
		}

	}
	}