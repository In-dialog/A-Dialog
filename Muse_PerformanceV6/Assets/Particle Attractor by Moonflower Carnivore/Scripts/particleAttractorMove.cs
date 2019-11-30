using System.Collections;
using UnityEngine;
using System.Collections.Generic;

[RequireComponent(typeof(ParticleSystem))]
public class particleAttractorMove : MonoBehaviour {
	ParticleSystem ps;
	ParticleSystem.Particle[] m_Particles;

//	public Transform [] target;
	public List<Transform> target = new List<Transform>();
	public float speed = 5f;

	public List<float> CurentIntensety = new List<float>();
	public List<float> Procentage = new List<float>();
//	public List<float> NumberAssingOfPoints = new List<float>();
	public List<int> AssingPoints = new List<int>();
//	int AssingPoints;


	public	int PointsLeft1=0;
	public	int StartCount=0;

	int PointsLeft2;
	int PointsLeft3;


	public float MaxIntensety = 100;

	int numParticlesAlive;

	int time;
	float RandoNumber;


	public float degreesPerSecond = 15.0f;
	public float amplitude = 0.5f;
	public float frequency = 1f;

	Vector3 posOffset = new Vector3 ();
	Vector3 tempPos = new Vector3 ();

	void Start () {
//		CalculateProcentage ();

		ps = GetComponent<ParticleSystem>();
		if (!GetComponent<Transform>()){
			GetComponent<Transform>();
		}
	}
	void Update () {
		
		m_Particles = new ParticleSystem.Particle[ps.main.maxParticles];
		numParticlesAlive = ps.GetParticles(m_Particles);
		AttributePoints ();


		ps.SetParticles(m_Particles, numParticlesAlive);

		time++;
		if (time>700){
			RandoNumber = Random.Range(-5, 5F);
			time = 0;
		}

		CurentIntensety [0] = GameObject.Find("OSCReciver").GetComponent<UniOSC.UniOSCRotateGameObject>().Dx * GameObject.Find("OSCReciver").GetComponent<UniOSC.UniOSCRotateGameObject>().Tx ;
		CurentIntensety [0] = CurentIntensety [0].Remap (-1f, 1.2f, 0f, 50f);
		CurentIntensety [1] =  GameObject.Find("OSCReciver").GetComponent<UniOSC.UniOSCRotateGameObject>().Ax * GameObject.Find("OSCReciver").GetComponent<UniOSC.UniOSCRotateGameObject>().Bx ;
		CurentIntensety [1] = CurentIntensety [1].Remap (-1f, 1.2f, 0f, 50f);

	}


	void AttributePoints(){
		for (int i = 0; i <= target.Count - 1; i++) {
			Procentage [i] = (CurentIntensety [i] / MaxIntensety);
			float[] PrecentageArray = Procentage.ToArray ();
			System.Array.Sort(PrecentageArray);
//			float maxValue = PrecentageArray[target.Count - 1];

		
			if (Procentage [i] == PrecentageArray [target.Count - 1]) {
				float NumberAssingOfPoints = numParticlesAlive * Procentage [i];
				AssingPoints [i] = Mathf.FloorToInt (NumberAssingOfPoints);
				StartCount = AssingPoints [i];
				MoveParticle (target [i], AssingPoints [i], 0);
				PointsLeft1 = numParticlesAlive - AssingPoints[i];

//				Debug.Log ("PointsLeft1    "  +PointsLeft1);
			} else {
				/////////Distribute equaly the number of points. 
				if (Procentage [i] == PrecentageArray [target.Count - 2]) {
					float NumberAssingOfPoints = PointsLeft1 * Procentage [i];
					AssingPoints [i] = Mathf.FloorToInt (NumberAssingOfPoints);
					int AssingedPoints = AssingPoints [i] + StartCount;

					MoveParticle (target [i], AssingedPoints-1, StartCount);
					PointsLeft2 = PointsLeft1 - AssingPoints [i];
//					Debug.Log ("AssingPoints [i]    "  +AssingedPoints);
//				Debug.Log (PointsLeft2);
				}
			
			}


		}

	}
	void MoveParticle(Transform Target,int StopRange,int StartRenge){
//		Debug.Log ("Begining");
//		Debug.Log ("Stop    "  + StopRange);
//		Debug.Log ("Start   " + StartRenge);
//		Debug.Log ("End");
//		;

	



		float step = speed * Time.deltaTime;
		for (int i = StartRenge; i < StopRange; i++) {
			posOffset = Target.position;
			float dist = Vector3.Distance(m_Particles[i].position,Target.position);
//			Debug.Log (dist);
			if (dist >= 2) {
				m_Particles [i].position = Vector3.MoveTowards (m_Particles [i].position, Target.position, step);
			} else {
				tempPos = posOffset;
				tempPos.y += Mathf.Sin (Time.fixedTime * Mathf.PI * frequency) * amplitude+RandoNumber;
				m_Particles [i].position = Vector3.MoveTowards (m_Particles [i].position, tempPos, step);
//				m_Particles [i].position = tempPos;s
			}
		}
	}


}
//float NumberAssingOfPoints = numParticlesAlive * Procentage [i];
//AssingPoints[i] = Mathf.FloorToInt (NumberAssingOfPoints);
//MoveParticle (target [i], AssingPoints[i], 0);
//PointsLeft1 = numParticlesAlive - AssingPoints[i];

//float NumberAssingOfPoints = PointsLeft1 * Procentage [i];
//AssingPoints[i] = Mathf.FloorToInt (NumberAssingOfPoints);
//MoveParticle (target [i], AssingPoints[i], PointsLeft1);
//PointsLeft2 = PointsLeft1 - AssingPoints[i];