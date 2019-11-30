using UnityEngine;

public class MeshDeformerInput : MonoBehaviour {
	
	public float force = 10f;
	public float forceOffset = 0.1f;
	public Vector3 Position;
	public Vector3 Direction;
	void Update () {
//		if (Input.GetMouseButton(0)) {

//		}

		Position = GameObject.FindGameObjectWithTag("GH").transform.position;
		Direction = transform.position - Position;
		HandleInput();
	}

	void HandleInput () {
//		Ray inputRay = Camera.main.ScreenPointToRay(Input.mousePosition);
//		RaycastHit hit;
		Ray inputRay = new Ray(Position, Direction);
		RaycastHit hit;


		if (Physics.Raycast(inputRay, out hit)) {
			MeshDeformer deformer = hit.collider.GetComponent<MeshDeformer>();
			if (deformer) {
				Vector3 point = hit.point;
				point += hit.normal * forceOffset;
				deformer.AddDeformingForce(point, force);
			}
		}
	}
}

//void HandleInput () {
//	Ray inputRay = Camera.main.ScreenPointToRay(Input.mousePosition);
//	RaycastHit hit;
//
//	if (Physics.Raycast(inputRay, out hit)) {
//		MeshDeformer deformer = hit.collider.GetComponent<MeshDeformer>();
//		if (deformer) {
//			Vector3 point = hit.point;
//			point += hit.normal * forceOffset;
//			deformer.AddDeformingForce(point, force);
//		}
//	}
//}
//}