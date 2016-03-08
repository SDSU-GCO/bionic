using UnityEngine;
using System.Collections;

public class Item_Ammo : MonoBehaviour 
{
	void OnTriggerEnter2D(Collider2D collider)
	{
		if (collider.gameObject.tag == "Player") 
		{
			collider.gameObject.GetComponent<Battery> ().addBattery (1);
			Destroy (gameObject);
		}
	}
}
