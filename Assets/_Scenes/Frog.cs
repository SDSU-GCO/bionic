using UnityEngine;
using System.Collections;

public class Frog : MonoBehaviour 
{
	public int facing;
	public LayerMask playerMask;
	public LayerMask wallMask;
	public float range;
	Collider2D[] colliders;
	RaycastHit2D hit;
	// Use this for initialization
	void Start () 
	{
	
	}

	// Update is called once per frame
	void Update () 
	{
		if (Sighted ())
		{

		}
	}

	bool Sighted()
	{
		colliders = Physics2D.OverlapCircleAll(transform.position,range,playerMask);
		if (colliders.Length > 0)
		{
			Debug.Log ("In range");
			hit = Physics2D.Linecast (transform.position, colliders [0].transform.position, wallMask);
			if (hit)
			{
				Debug.Log ("not seen");
				return false;
			} 
			else
			{
				Debug.Log ("seen");	
				return true;
			}
		}
		else
			return false;
	}
}
