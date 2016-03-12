using UnityEngine;
using System.Collections;

public class FoxControl : MonoBehaviour
{
	const int RIGHT = 1;
	const int LEFT = -1;
	private Rigidbody2D _Rigidbody2D;

	public KeyCode jump;
	public KeyCode moveLeft;
	public KeyCode moveRight;
	public float speed;
	public float jumpForce;
	[SerializeField] private LayerMask m_WhatIsGround;
	private Transform _GroundCheck;
	private bool _Grounded;
	const float k_GroundedRadius = .5f;
	private Transform _CeilingCheck;   // A position marking where to check for ceilings
	const float k_CeilingRadius = .01f; // Radius of the overlap circle to determine if the player can stand up

	int facing;
	public LayerMask mask;
	// Use this for initialization
	void Start ()
	{
		_Rigidbody2D = GetComponent<Rigidbody2D>();
		_GroundCheck = transform.Find("GroundCheck");
		_CeilingCheck = transform.Find("CeilingCheck");
		facing = RIGHT;
	}
	// Update is called once per frame
	void FixedUpdate ()
	{
		
		Collider2D[] colliders = Physics2D.OverlapCircleAll(_GroundCheck.position, k_GroundedRadius, m_WhatIsGround);
		for (int i = 0; i < colliders.Length; i++)
		{
			if (colliders [i].gameObject != gameObject) 
			{
				_Grounded = true;
			}
		}

		//movement
		if (Input.GetKey (jump) && _Grounded) {
			_Rigidbody2D.AddForce (new Vector2 (0, jumpForce));
			_Grounded = false;
		} else if (Input.GetKey (moveLeft)) {
			if (!Input.GetKey (moveRight))
				facing = LEFT;
			_Rigidbody2D.velocity = new Vector2 (speed * -1, _Rigidbody2D.velocity.y);
		} else if (Input.GetKey (moveRight)) {
			if (!Input.GetKey (moveLeft))
				facing = RIGHT;
			_Rigidbody2D.velocity = new Vector2 (speed, _Rigidbody2D.velocity.y);
		} 
		else 
		{
			_Rigidbody2D.velocity = new Vector2(0, _Rigidbody2D.velocity.y);
		}
		/*
		RaycastHit2D hit = Physics2D.Raycast (transform.position, -Vector2.up, 2, mask);
		if (hit && _Grounded) 
		{
			float slopeAngle = Vector2.Angle (hit.normal, Vector2.up);
			Debug.Log (slopeAngle);
			float currentVel = _Rigidbody2D.velocity.x;
			float slopeVelX = Mathf.Cos (slopeAngle * Mathf.Deg2Rad) * currentVel;
			float slopeVelY = Mathf.Sin (slopeAngle * Mathf.Deg2Rad) * currentVel;

			_Rigidbody2D.velocity = new Vector2(slopeVelX, slopeVelY);
		}*/

	}
	public int getFacing()
	{
		return facing;
	}

}
