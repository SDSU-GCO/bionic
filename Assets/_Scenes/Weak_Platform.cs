using UnityEngine;
using System.Collections;
public class Weak_Platform : MonoBehaviour {
	
	
	int timer;
	bool breaking;
	
	// Use this for initialization
	void Start () {
		timer = 20;
		breaking = false;
	}
	
	// Update is called once per frame
	void Update () {
		if(breaking){
			timer--;
		}
		if(timer <= 0){
			Destroy(this.gameObject);
			Destroy(this);
		}
	}
	void OnCollisionEnter2D(Collision2D other)
	{
		breaking = true;
	}
}