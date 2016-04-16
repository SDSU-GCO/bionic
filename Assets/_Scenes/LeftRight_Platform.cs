using UnityEngine;
using System.Collections;

public class LeftRight_Platform : MonoBehaviour {
	
	
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
			transform.position += transform.right * 2 * Time.deltaTime;
		}
		else if(timer < 100){
			timer++;
			transform.position -= transform.right * 2 * Time.deltaTime;
		}
		else{
			timer = 0;
		}	
		
	}
}