using UnityEngine;

public class MouseFollow : MonoBehaviour
{
	private Vector3 _target;
	public Camera Camera;
	public bool FollowMouse;
	public bool ShipAccelerates;
	public float ShipSpeed = 2.0f;

	public void OnEnable()
	{
//		if (Camera == null)
//		{
//			throw new InvalidOperationException("Camera not set");
//		}
	}

	public void Update()
	{
		if (FollowMouse )
		{
			_target = Camera.ScreenToWorldPoint(Input.mousePosition);
			_target.z = 0;
		}

		var delta = ShipSpeed*Time.deltaTime;
		if (ShipAccelerates)
		{
			delta *= Vector3.Distance(transform.position, _target);
		}

		this.gameObject.transform.position = Vector3.MoveTowards(transform.position, _target, delta);
	}
}