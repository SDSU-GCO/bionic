using UnityEngine;
using System.Collections;

public class UpDown_Platform : MonoBehaviour {
	
	
	int timer;
	
	
	// Use this for initialization
	void Start () {
		timer = 0;
	}
	
	// Update is called once per frame
	void Update () {
		//Increase timer for current action
		if(timer < 50){
			timer++;
			transform.position += transform.up * 2 * Time.deltaTime;
		}
		else if(timer < 100){
			timer++;
			transform.position -= transform.up * 2 * Time.deltaTime;
		}
		else{
			timer = 0;
		}	
		
	}
}