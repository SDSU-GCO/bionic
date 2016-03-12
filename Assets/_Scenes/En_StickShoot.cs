using UnityEngine;
using System.Collections;

public class En_StickShoot : MonoBehaviour 
{
	public int facing;
	public bool isMoving;
	public float burstSpeed;
	public float sightDistance; 
	public LayerMask mask;
	public Bullet laser;
	public float moveSpeed;
	Rigidbody2D _Rigidbody;
	int playerBlocking; // 0 when true

	int numShots;
	float shotTime; // Time since last shot
	float burstTime; // Time since last burst

	// Use this for initialization
	void Start () 
	{
		numShots = 3;
		shotTime = 1f;
		burstTime = 3f;
		_Rigidbody = gameObject.GetComponent<Rigidbody2D> ();
		playerBlocking = 1;
	}

	// Update is called once per frame
	// to update timers
	void Update () 
	{
		Detect ();
	}

	// to update physics
	void FixedUpdate()
	{
		Move ();
	}

	void Detect()
	{
		RaycastHit2D hit;
		hit = Physics2D.Raycast (transform.position, Vector2.right * facing, sightDistance, mask);
		Debug.DrawRay (transform.position, Vector2.right * facing * sightDistance, Color.green, 10f);
		burstTime += Time.deltaTime;
		if (hit || numShots < 3)
		{
			Fire ();
		}
	}
	// fox detection
	// calculate distance between fox and enemy
	//	float distanceToFox = Distance(Vector2 a, Vector2 b);
	// if in range of the fox and burst-fire rof timer is zero
	// call fire at fox
	// set burst-fire rof timer to two
	// decrement burst-fire rof timer by one (look into proper way to do this)

	// fire at fox
	// initialize shot counter to 0
	// initialize shot rof to 0
	// while shots fired is less than three
	// if shot rof is zero 
	// spawn shot
	// set shot rof to 0.0025 sec
	// increment shot counter by one (look into proper way to do this)
	void Fire()
	{
		if (burstTime >= burstSpeed)
		{
			burstTime = 0f;
			numShots = 0;
			shotTime = 1f;
		}
		shotTime += Time.deltaTime;
		if (shotTime >= 0.175f && numShots < 3)
		{
			shotTime = 0f;
			Bullet _laser = Instantiate(laser, new Vector3(transform.position.x + facing * (transform.lossyScale.x * 4f), transform.position.y, transform.position.z), transform.rotation) as Bullet;
			_laser.bulletVelocity = facing * 15f;
			_laser.shooter = "Enemy";
			numShots++;
		}

	}
	// move
	// enemy moves in the direction it srarted facing
	// if enemy collides with object tagged "vertical wall"
	// reverse movement direction and continue moving in that direction
	void Move()
	{
		_Rigidbody.velocity = new Vector2 (moveSpeed * facing * playerBlocking, _Rigidbody.velocity.y);
	}

	void OnCollisionEnter2D(Collision2D collision)
	{
		if (collision.gameObject.tag == "Wall")
			facing *= -1;
		if (collision.gameObject.tag == "Player")
		{
			playerBlocking = 0;
			Invoke ("Switch", 10);
		}
	}
	void OnTriggerEnter2D(Collider2D collider)
	{
		if (collider.gameObject.tag == "Wall") 
		{
			facing *= -1;
		}
	}
	void Switch()
	{
		playerBlocking = 1;
	}
}