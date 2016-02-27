using UnityEngine;
using System.Collections;

public class FoxControl : MonoBehaviour
{
    const int RIGHT = 1;
    const int LEFT = -1;
    private Rigidbody2D _Rigidbody2D;
    public Bullet laser;

    public KeyCode jump;
    public KeyCode moveLeft;
    public KeyCode moveRight;
    public float speed;
    public float jumpForce;
    public KeyCode shoot;
    public KeyCode selectFire;
    bool automatic;
    float autoTimeElapsed;
    [SerializeField] private LayerMask m_WhatIsGround;
    private Transform m_GroundCheck;
    private bool m_Grounded;
    const float k_GroundedRadius = .5f;
    private Transform m_CeilingCheck;   // A position marking where to check for ceilings
    const float k_CeilingRadius = .01f; // Radius of the overlap circle to determine if the player can stand up

    int facing;
    // Use this for initialization
    void Start ()
    {
        _Rigidbody2D = GetComponent<Rigidbody2D>();
        m_GroundCheck = transform.Find("GroundCheck");
        m_CeilingCheck = transform.Find("CeilingCheck");
        automatic = false;
        autoTimeElapsed = 0f;
        facing = RIGHT;

    }
    // Update is called once per frame
    void Update ()
    {

        Collider2D[] colliders = Physics2D.OverlapCircleAll(m_GroundCheck.position, k_GroundedRadius, m_WhatIsGround);
        for (int i = 0; i < colliders.Length; i++)
        {
            if (colliders[i].gameObject != gameObject)
                m_Grounded = true;
        }


        //movement
        if (Input.GetKey(jump) && m_Grounded)
        {
            _Rigidbody2D.AddForce(new Vector2(0, jumpForce));
            m_Grounded = false;
        }
        else if (Input.GetKey(moveLeft))
        {
            if (!Input.GetKey(moveRight))
                facing = LEFT;
            _Rigidbody2D.velocity = new Vector2(speed * -1, _Rigidbody2D.velocity.y);
        }
        else if (Input.GetKey(moveRight))
        {
            if (!Input.GetKey(moveLeft))
                facing = RIGHT;
            _Rigidbody2D.velocity = new Vector2(speed, _Rigidbody2D.velocity.y);
        }
        //stop moving
        if (Input.GetKeyUp(moveLeft))
        {
            _Rigidbody2D.velocity = new Vector2(0, _Rigidbody2D.velocity.y);
        }
        if (Input.GetKeyUp(moveRight))
        {
            _Rigidbody2D.velocity = new Vector2(0, _Rigidbody2D.velocity.y);
        }

        //select fire
        if (Input.GetKeyDown(selectFire))
        {
            automatic = !automatic;
        }
        
        //automatic laser
        if (automatic && Input.GetKey(shoot))
        {
            autoTimeElapsed += Time.deltaTime;
            if (autoTimeElapsed >= 0.09f)
            {
                autoTimeElapsed = 0f;
                Bullet _laser = Instantiate(laser, transform.position, transform.rotation) as Bullet;
                _laser.bulletVelocity = facing * 80f;
                _laser.shooter = "Player";
            }
        }
        if (Input.GetKeyDown(shoot) && !automatic)
        {
            Bullet _laser = Instantiate(laser, new Vector3(transform.position.x + facing *(transform.lossyScale.x * 4f), transform.position.y, transform.position.y), transform.rotation) as Bullet;
            _laser.bulletVelocity = facing * 80f;
            _laser.shooter = "Player";
        }

    }
}
