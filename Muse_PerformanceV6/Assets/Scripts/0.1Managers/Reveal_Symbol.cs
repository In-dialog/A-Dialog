
	using UnityEngine;
	using System.Collections;

	public class Reveal_Symbol : MonoBehaviour {
		GameObject Object1;
		GameObject Object2;
		GameObject Object3;
		GameObject Object4;

		GameObject Reciver;

		GameObject OSCReciver;
		GameObject Group;

		Vector3 PositionA;
		Vector3 PositionB;
		Vector3 PositionC;
		Vector3 PositionD;

		public float speed;
		public float Rotation;


		public float Delat=0;
		public float Theta=0;
		public float Alpha=0;
		public float Beta=0;
		public float Gama=0;


	public float RowDelat,RowTheta,RowAlpha,RowBeta,RowGama;

		public float Delat_Relative , Theta_Relative , Alpha_Relative, Beta_Relative, Gama_Relative;


		float  [] SavedValue = {0,0,0,0,0};


		public float smoothingValue = 0.2f;
		public int filterLength = 3; //you could change it in inspector

	private LowPassFilter filterX,filterY,filterXX,filterYY,filterG;
		


		private LowPassFilter FileterRotate;

		public float TresholdAxiX=0;
		public float TresholdAxiY=0;


		// Use this for initialization
		void Start () {
			Object1 = GameObject.Find ("Object1");
			Object2 = GameObject.Find ("Object2");
			Object3 = GameObject.Find ("Object3");
			Object4 = GameObject.Find ("Object4");
			Group = GameObject.Find ("Points");
			Reciver = GameObject.Find ("OSCReciver");
			/////////
			filterX = new LowPassFilter (smoothingValue);
			filterY = new LowPassFilter (smoothingValue);
			filterXX = new LowPassFilter (smoothingValue);
			filterYY = new LowPassFilter (smoothingValue);
			filterG = new LowPassFilter (smoothingValue);

			/////////	
			FileterRotate = new LowPassFilter (smoothingValue);


		}

void Update () {
		

//		Calculate Averall intensety
	
	Delat_Relative = filterX.NextStep (Time.deltaTime,(Reciver.GetComponent< UniOSC.OSC_Data >().Delta));
	Theta_Relative = filterY.NextStep (Time.deltaTime, (Reciver.GetComponent< UniOSC.OSC_Data > ().Theta));
	Alpha_Relative = filterXX.NextStep (Time.deltaTime, (Reciver.GetComponent< UniOSC.OSC_Data > ().Alpha));
	Beta_Relative  = filterYY.NextStep (Time.deltaTime,(Reciver.GetComponent< UniOSC.OSC_Data >().Beta));
	Gama_Relative  = filterG.NextStep (Time.deltaTime,(Reciver.GetComponent< UniOSC.OSC_Data >().Gamma));

			float DelatTemp = 0;
			DelatTemp = Delat_Relative / (Delat_Relative + Theta_Relative + Alpha_Relative + Beta_Relative + Gama_Relative );
			if (float.IsNaN (DelatTemp) ) {DelatTemp = 1;} else {DelatTemp = DelatTemp;}
			if (DelatTemp > 1 || DelatTemp < -1) {DelatTemp = SavedValue [0];}else {SavedValue[0] = DelatTemp;}
			Delat = DelatTemp;
			float DeltaDraw = DelatTemp.Remap(-0.3f,1,0,TresholdAxiX);



			float ThetaTemp = 0;
			ThetaTemp = Theta_Relative / (Delat_Relative + Theta_Relative + Alpha_Relative + Beta_Relative + Gama_Relative );
			if (ThetaTemp > 1 || ThetaTemp < -1) {ThetaTemp = SavedValue [1];}else {SavedValue[1] = ThetaTemp;}
			if (float.IsNaN (ThetaTemp) ) {ThetaTemp = 1;} else {ThetaTemp = ThetaTemp;}
			Theta = ThetaTemp;
			float ThetaDraw = ThetaTemp.Remap(-0.3F,1,0,TresholdAxiY);


			float AlphaTemp = 0;
		    AlphaTemp = Alpha_Relative / (Delat_Relative + Theta_Relative + Alpha_Relative + Beta_Relative + Gama_Relative );
			if (float.IsNaN (DelatTemp) ) {DelatTemp = 1;} else {DelatTemp = DelatTemp;}
			if (AlphaTemp > 1 || AlphaTemp < -1) {AlphaTemp = SavedValue [2];}else {SavedValue[2] = AlphaTemp;}
			Alpha = DelatTemp;
			float AlphaDraw = AlphaTemp.Remap(-0.3f,1,0,TresholdAxiX);


			float BetaTemp = 0;
	    	BetaTemp = Beta_Relative / (Delat_Relative + Theta_Relative + Alpha_Relative + Beta_Relative + Gama_Relative );
			if (float.IsNaN (BetaTemp) ) {BetaTemp = 1;} else {BetaTemp = BetaTemp;}
			if (BetaTemp > 1 || BetaTemp < -1) {BetaTemp = SavedValue [3];}else {SavedValue[3] = BetaTemp;}
			Beta = BetaTemp;

			float GamaTemp = Gama_Relative / (Delat_Relative + Theta_Relative + Alpha_Relative + Beta_Relative + Gama_Relative );
			if (GamaTemp > 1 || GamaTemp < -1) {GamaTemp = SavedValue [4];}else {SavedValue[4] = GamaTemp;}
			if (float.IsNaN (GamaTemp) ) {GamaTemp = 1;} else {GamaTemp = GamaTemp;}
			Gama = GamaTemp;
			float Gamma = GamaTemp.Remap(-0.5f,1,0.1F,2);
			
//			//		Calculate Averall intensety.

		RowDelat = (filterX.NextStep (Time.deltaTime,(Reciver.GetComponent< UniOSC.OSC_Data >().Delta))).Remap(0,120,0,TresholdAxiX);
		RowTheta = (filterY.NextStep (Time.deltaTime,(Reciver.GetComponent< UniOSC.OSC_Data >().Delta))).Remap(0,120,0,TresholdAxiY);
		RowAlpha = (filterXX.NextStep (Time.deltaTime,(Reciver.GetComponent< UniOSC.OSC_Data >().Alpha))).Remap(0,120,0,TresholdAxiX);
		RowBeta  = (filterY.NextStep (Time.deltaTime,(Reciver.GetComponent< UniOSC.OSC_Data >().Beta))).Remap(0,120,0,TresholdAxiY);
		RowGama = (filterYY.NextStep (Time.deltaTime,(Reciver.GetComponent< UniOSC.OSC_Data >().Gamma))).Remap(0,120,0,TresholdAxiY);


		Rotation = FileterRotate.NextStep (Time.deltaTime,(Reciver.GetComponent< UniOSC.OSC_Data >().AY));
		PositionA = new Vector3 (RowDelat*Delat,0,0);
		PositionB = new Vector3 (0,0,RowTheta*Theta);
		PositionC = new Vector3 (RowAlpha*(-1)*Alpha,0,0);
		PositionD = new Vector3 (0,0,RowBeta*(-1)*Beta);
			move (Object1, PositionA);
			move (Object2, PositionB);
			move (Object3, PositionC);
			move (Object4, PositionD);
			Group.transform.RotateAround (Vector3.zero, Vector3.up, Rotation * Time.deltaTime);

	}
		void move(GameObject Obj,Vector3 Target){
			float step = speed * Time.deltaTime;
			Obj.transform.position = Vector3.MoveTowards(Obj.transform.position, Target, step);
		}




	}
