using UnityEngine;
using System.Collections;

public class Battery : MonoBehaviour 
{
	public int initialBatteries;
	int batteryLife;
	// Use this for initialization
	void Start () 
	{
		batteryLife = 40 * initialBatteries;
	}

	// Decrease batterylife by specified amount and adjust batteries accordingly
	public void Decrement(int dec)
	{
		batteryLife -= dec;
	}

	// Add additional batteries
	public void addBattery(int bat)
	{
		batteryLife += bat * 40;
	}

	public int BatteryLife()
	{
		return batteryLife;
	}
}
