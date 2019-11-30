using UnityEngine;
using System.Collections;

public class TargetAssign : MonoBehaviour 
{
	public Vector3 playerPosition;
	public Vector3 distanceDifference;
	public float oldDistance = Mathf.Infinity;
	public float currentDistance;
	public GameObject target;
	public GameObject closest;
	public GameObject[] HazardArray;
	
	void Update () 
	{
		playerPosition = GameObject.Find ("Player").transform.position;
		
		HazardArray = GameObject.FindGameObjectsWithTag("Hazard");
		
		if (HazardArray.Length == 0) return;
		
		foreach (GameObject hazard in HazardArray)
		{
			distanceDifference = hazard.transform.position - playerPosition;
			currentDistance = distanceDifference.sqrMagnitude;
			if (currentDistance < oldDistance)
			{
				closest = hazard;
				target = closest;
				oldDistance = currentDistance;            
			}
		}
		oldDistance = Mathf.Infinity;
	}
}