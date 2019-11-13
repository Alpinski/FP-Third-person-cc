using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraCollisions : MonoBehaviour
{
	public float MinimumDistance = 1.0f;
	public float MaximumDistance = 4.0f;
	public float Smooth = 10.0f;
	Vector3 DollyDirection;
	public Vector3 DollyDirAdjusted;
	public float distance;

    // Start is called before the first frame update
    void Awake()
    {
		DollyDirection = transform.localPosition.normalized;
		distance = transform.localPosition.magnitude;
    }

    // Update is called once per frame
    void Update()
    {
		Vector3 desiredCameraPosition = transform.TransformPoint(DollyDirection * MaximumDistance);
		RaycastHit hit;

		if (Physics.Linecast(transform.position, desiredCameraPosition,out hit))
		{
			distance = Mathf.Clamp((hit.distance * 0.87f), MinimumDistance, MaximumDistance);

		}
		else
		{
			distance = MaximumDistance;
		}
		transform.localPosition = Vector3.Lerp(transform.localPosition, DollyDirection * distance, Time.deltaTime * Smooth);

	}
}
