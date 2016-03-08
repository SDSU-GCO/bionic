using UnityEngine;
using System.Collections;

public class Battery : MonoBehaviour 
{
	public int batteries;
	int batteryLife;
	// Use this for initialization
	void Start () 
	{
		batteryLife = 40 * batteries;
	}
	
	public void Decrement(int dec)
	{
		batteryLife -= dec;
		if (batteryLife % 40 == 0) 
		{
			batteries--;
		}
	}
	public void addBattery(int bat)
	{
		batteries += bat;
		batteryLife += bat * 40;
	}
}
