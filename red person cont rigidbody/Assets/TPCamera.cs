using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TPCamera : MonoBehaviour
{
	public Transform target;
	public float distance = 5.0f;
	public float xSpeed = 120.0f;
	public float ySpeed = 120.0f;

	public float yMinLimit = -20f;
	public float yMaxLimit = 80f;

	public float distanceMin = .5f;
	public float distanceMax = 15f;

	private Rigidbody Rigidbody;

	float x = 0.0f;
	float y = 0.0f;

	// Use this for initialization
	void Start()
	{
		Vector3 angles = transform.eulerAngles;
		x = angles.y;
		y = angles.x;

		Rigidbody = GetComponent<Rigidbody>();

		// Make the rigid body not change rotation
		if (Rigidbody != null)
		{
			Rigidbody.freezeRotation = true;
		}

		adjustedCameraClipPoints = new Vector3[5];
		desiredCameraClipPoints = new Vector3[5];
	}

	void LateUpdate()
	{
		if (target)
		{
			x += Input.GetAxis("Mouse X") * xSpeed * distance * 0.02f;
			y -= Input.GetAxis("Mouse Y") * ySpeed * 0.02f;

			y = ClampAngle(y, yMinLimit, yMaxLimit);

			Quaternion rotation = Quaternion.Euler(y, x, 0);

			distance = Mathf.Clamp(distance - Input.GetAxis("Mouse ScrollWheel") * 5, distanceMin, distanceMax);

			RaycastHit hit;
			if (Physics.Linecast(target.position, transform.position, out hit))
			{
				distance = hit.distance - 2;
			}
			Vector3 negDistance = new Vector3(0.0f, 0.0f, -distance);
			Vector3 position = rotation * negDistance + target.position;

			transform.rotation = rotation;
			transform.position = position;
		}
	}

	public LayerMask collisionLayer;
	public bool colliding = false;
	public Vector3[] adjustedCameraClipPoints;
	public Vector3[] desiredCameraClipPoints;
	public void UpdateCameraClipPoints(Vector3 cameraPosition, Quaternion atRotation, ref Vector3[] intoArray)
	{

	}

	bool CollisionDetectedAtClipPoints(Vector3[] clipPoints, Vector3 fromPosition)
	{

	}


	public float GetAdjustedDistanceWithRayFrom(Vector3 from)
	{

	}

	public void CheckColliding(Vector3 targetPosition)
	{

	}

	public static float ClampAngle(float angle, float min, float max)
	{
		if (angle < -360F)
			angle += 360F;
		if (angle > 360F)
			angle -= 360F;
		return Mathf.Clamp(angle, min, max);
	}

}
