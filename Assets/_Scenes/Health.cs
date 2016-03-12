using UnityEngine;
using System.Collections;

public class Health : MonoBehaviour
{
    public int maxHealth;
    int health;
	// Use this for initialization
	void Start ()
    {
        health = maxHealth;
	}
	
	// Update is called once per frame
	void Update ()
    {
        if (health <= 0 && gameObject.tag != "Player")
        {
            Destroy(gameObject);
        }
	}

    public void Decrement(int dec) //decrease the health by the specified amount
    {
        health -= dec;
        if (health < 0)
            health = 0;
		Debug.Log (health);
    }

}
