using UnityEngine;

public class ThirdPersonCamera : MonoBehaviour
{
	[Header("Settings")]
	public bool m_fLockCursor;
	public float m_fMouseSensitivity = 10;
	public float distFromTarget = 2;
	public Transform target;
	public Vector2 pitchMinMax = new Vector2(-40, 85);

	public float rotationSmoothTime = 8f;
	Vector3 rotationSmoothVelocity;
	Vector3 currentRotation;

	float m_fYaw;
	float m_fPitch;

	private Rigidbody Rigidbody;

	[Header("Collision Vars")]

	[Header("Transparency")]
	public bool changeTransparency = true;
	public MeshRenderer targetRenderer;

	[Header("Speeds")]
	public float moveSpeed = 5;
	public float returnSpeed = 9;
	public float wallPush = 0.7f;

	[Header("Distances")]
	public float closestDistanceToPlayer = 2;
	public float evenCloserDistanceToPlayer = 1;

	[Header("Mask")]
	public LayerMask collisionMask;

	private bool pitchLock = false;

	private void Start()
	{
		if (m_fLockCursor)
		{
			Cursor.lockState = CursorLockMode.Locked;
			Cursor.visible = false;
		}

		Rigidbody = GetComponent<Rigidbody>();

		// Make the rigid body not change rotation
		if (Rigidbody != null)
		{
			Rigidbody.freezeRotation = true;
		}
	}


	private void LateUpdate()
	{

		CollisionCheck(target.position - transform.forward * distFromTarget);
		WallCheck();


		if (!pitchLock)
		{
			m_fYaw += Input.GetAxis("Mouse X") * m_fMouseSensitivity;
			m_fPitch -= Input.GetAxis("Mouse Y") * m_fMouseSensitivity;

			m_fYaw += Input.GetAxis("RightStickX") * m_fMouseSensitivity;
			m_fPitch -= Input.GetAxis("RightStickY") * m_fMouseSensitivity;

			m_fPitch = Mathf.Clamp(m_fPitch, pitchMinMax.x, pitchMinMax.y);
			currentRotation = Vector3.Lerp(currentRotation, new Vector3(m_fPitch, m_fYaw), rotationSmoothTime * Time.deltaTime);
		}
		else
		{

			m_fYaw += Input.GetAxis("Mouse X") * m_fMouseSensitivity;
			m_fPitch = pitchMinMax.y;

			currentRotation = Vector3.Lerp(currentRotation, new Vector3(m_fPitch, m_fYaw), rotationSmoothTime * Time.deltaTime);

		}


		transform.eulerAngles = currentRotation;

		Vector3 e = transform.eulerAngles;
		e.x = 0;

		target.eulerAngles = e;
	}

	private void WallCheck()
	{

		Ray ray = new Ray(target.position, -target.forward);
		RaycastHit hit;

		if (Physics.SphereCast(ray, 0.2f, out hit, 0.7f, collisionMask))
		{
			pitchLock = true;
		}
		else
		{
			pitchLock = false;
		}

	}

	private void CollisionCheck(Vector3 retPoint)
	{

		RaycastHit hit;

		if (Physics.Linecast(target.position, retPoint, out hit, collisionMask))
		{

			Vector3 norm = hit.normal * wallPush;
			Vector3 p = hit.point + norm;

			TransparencyCheck();

			if (Vector3.Distance(Vector3.Lerp(transform.position, p, moveSpeed * Time.deltaTime), target.position) <= evenCloserDistanceToPlayer)
			{


			}
			else
			{
				transform.position = Vector3.Lerp(transform.position, p, moveSpeed * Time.deltaTime);
			}

			return;

		}


		FullTransparency();

		transform.position = Vector3.Lerp(transform.position, retPoint, returnSpeed * Time.deltaTime);
		pitchLock = false;

	}

	private void TransparencyCheck()
	{

		if (changeTransparency)
		{

			if (Vector3.Distance(transform.position, target.position) <= closestDistanceToPlayer)
			{

				Color temp = targetRenderer.sharedMaterial.color;
				temp.a = Mathf.Lerp(temp.a, 0.2f, moveSpeed * Time.deltaTime);

				targetRenderer.sharedMaterial.color = temp;


			}
			else
			{

				if (targetRenderer.sharedMaterial.color.a <= 0.99f)
				{

					Color temp = targetRenderer.sharedMaterial.color;
					temp.a = Mathf.Lerp(temp.a, 1, moveSpeed * Time.deltaTime);

					targetRenderer.sharedMaterial.color = temp;

				}

			}

		}

	}

	private void FullTransparency()
	{
		if (changeTransparency)
		{
			if (targetRenderer.sharedMaterial.color.a <= 0.99f)
			{

				Color temp = targetRenderer.sharedMaterial.color;
				temp.a = Mathf.Lerp(temp.a, 1, moveSpeed * Time.deltaTime);

				targetRenderer.sharedMaterial.color = temp;

			}
		}
	}
}
