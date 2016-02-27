using UnityEngine;
using System.Collections;

public class Bullet : MonoBehaviour
{
    public string shooter;
    public float bulletVelocity;
    float timeLeft = 10.0f;
    Rigidbody2D _Rigidbody2D;
	// Use this for initialization
	void Start ()
    {
        _Rigidbody2D = GetComponent<Rigidbody2D>();
        _Rigidbody2D.velocity = new Vector2(bulletVelocity, 0);
    }
	
	// Update is called once per frame
	void Update ()
    {
        timeLeft -= Time.deltaTime;
        if (timeLeft <= 0)
        {
            Destroy(gameObject);
        }
        _Rigidbody2D.velocity = new Vector2(_Rigidbody2D.velocity.x, 0);
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag != shooter)
        {
            Destroy(gameObject);
        }
        
    }
}
