using UnityEngine;
using System.Collections;
public class Elevator : MonoBehaviour {
	
	
	float starty;
	float endy;
	bool ison;
	
	// Use this for initialization
	void Start () {
		starty = transform.position.y;
		endy = starty + 50;
		ison = false;
	}
	
	// Update is called once per frame
	void Update () {
		if(ison && (transform.position.y < endy)){
			transform.position += transform.up * 2 * Time.deltaTime;
		}
		else if(!ison && (transform.position.y > starty)){
			transform.position -= transform.up * 2 * Time.deltaTime;
		}
	}
	void OnCollisionEnter2D(Collision2D other)
	{
		ison = true;
	}
	void OnCollisionExit2D(Collision2D other)
	{
		ison = false;
	}	
}