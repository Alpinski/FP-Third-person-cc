using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class Movement : MonoBehaviour
{
	//Speed variable used in addforce
	public float Speed = 1000f;
	public float SprintSpeed = 1000f;


	//jump vars
	public float Gravity = 19.614f;
	public float JumpPower = 500f;
	private bool DoubleJumpOn;


	//Used to monitor speed
	public float v3Velocity;

	//grounded vars
	private readonly float Radius = 1;


	//speed limiter vars
	private Vector3 CurrSpeed;
	private float CurrSpeedMag;
	private float MaxSpeed = 3f;
	private Vector3 BrakePower;

	//general vars
	private Rigidbody _rigidbody;
	private Vector3 _inputs = Vector3.zero;

	float tempMaxSpeed;
	float tempMovementSpeed;
	// Start is called before the first frame update
	void Awake()
	{
		tempMaxSpeed = MaxSpeed;
		tempMovementSpeed = Speed;

		if (GetComponent<Rigidbody>())
		{
			_rigidbody = GetComponent<Rigidbody>();
		}
		else
		{
			Debug.LogError("Thecharacter needs a rigidbody");
		}
	}

	// Update is called once per frame
	void Update()
	{
		
		Inputs();
		Jump();
		v3Velocity = _rigidbody.velocity.magnitude;
	}

	private void FixedUpdate()
	{
		Turn();
		Move();
	}

	bool GroundCheck()
	{
		RaycastHit hit;
		return Physics.SphereCast(gameObject.transform.position - new Vector3(0f, -0.6f, 0f), Radius, Vector3.down, out hit, 1f);
	}

	private void Inputs()
	{
		_inputs = Vector3.zero;
		_inputs.x = Input.GetAxis("Horizontal");
		_inputs.z = Input.GetAxis("Vertical");
	}
	
	private void Move()
	{
		CurrSpeed.Set(_rigidbody.velocity.x, 0, _rigidbody.velocity.z);

		CurrSpeedMag = Vector3.Magnitude(CurrSpeed);
		

		if (Input.GetButton("Sprint"))
		{
			MaxSpeed *= 2f;
			Speed = SprintSpeed;

		}
		else
		{
			MaxSpeed = tempMaxSpeed;
			Speed = tempMovementSpeed;
		}

		if (CurrSpeedMag > MaxSpeed * MaxSpeed == false)
		{
			_rigidbody.AddRelativeForce(Vector3.zero + _inputs * Speed * Time.fixedDeltaTime, ForceMode.Acceleration);
		}

	}

	private void Jump()
	{
		if (Input.GetButtonDown("Jump") && GroundCheck() == true)
		{
			_rigidbody.AddForce(Vector3.up * JumpPower * Time.fixedDeltaTime, ForceMode.VelocityChange);
			DoubleJumpOn = true;
		}
		else
		{
			if (Input.GetButtonDown("Jump") && DoubleJumpOn)
			{
				DoubleJumpOn = false;
				_rigidbody.AddForce(Vector3.up * JumpPower * Time.fixedDeltaTime, ForceMode.VelocityChange);
			}
		}
		if (_rigidbody.velocity.y < 0 && GroundCheck() == false)
		{
			_rigidbody.AddForce(Vector3.down * Gravity * Time.fixedDeltaTime, ForceMode.Acceleration);
		}
	}

	public Transform cam;
	private void Turn()
	{
		this.transform.rotation = Quaternion.Euler(0, cam.eulerAngles.y, 0);
	}

}
