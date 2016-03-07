using UnityEngine;
using System.Collections;

public class Enemy : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	// to update timers
	void Update () {
		// call fox detection
	}

	// to update physics
	void FixedUpdate(){	
		// call move
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
			
	// move
		// enemy moves in the direction it srarted facing
		// if enemy collides with object tagged "vertical wall"
			// reserve movement direction and continue moving in that direction
		
}