using UnityEngine;
using System.Collections;

public class Item_AutoUpgrade : MonoBehaviour 
{
	void OnTriggerEnter2D(Collider2D collider)
	{
		if (collider.gameObject.tag == "Player") 
		{
			collider.gameObject.GetComponent<FoxWeapon> ().unlock(1);
			Destroy (gameObject);
		}
	}
}
