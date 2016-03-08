using UnityEngine;
using System.Collections;


// This handles the selecting and firing of the different weapons
public class FoxWeapon : MonoBehaviour
{
	private FoxControl _fox;
	private Battery _battery;

	const int NUM_WEAPONS = 2;
	enum weaponType { SEMIAUTO, AUTO };
	weaponType selected;
	bool [] unlocked;

	public KeyCode shoot;
	public KeyCode selectSemiAuto;
	public KeyCode selectAuto;

	public Bullet laser;
	float autoTimeElapsed;

	void Start ()
	{
		_fox = GetComponent<FoxControl> ();
		_battery = GetComponent<Battery> ();
		selected = weaponType.SEMIAUTO;
		unlocked = new bool[NUM_WEAPONS];
		unlocked [(int)weaponType.SEMIAUTO] = true;
		for(int i = 1; i < NUM_WEAPONS; i++)
		{
			unlocked[i] = false;
		}
	}

	void Update ()
	{
		// Select weapon
		if (Input.GetKeyDown (selectSemiAuto) && unlocked[(int)weaponType.SEMIAUTO]) 
		{
			selected = weaponType.SEMIAUTO;
		} 
		else if (Input.GetKeyDown (selectAuto) && unlocked[(int)weaponType.AUTO]) 
		{
			selected = weaponType.AUTO;
		}


		// Fire
		// automatic laser
		if (Input.GetKey(shoot) && selected == weaponType.AUTO && _battery.batteries > 0)
		{
			autoTimeElapsed += Time.deltaTime;
			if (autoTimeElapsed >= 0.09f)
			{
				autoTimeElapsed = 0f;
				Bullet _laser = Instantiate(laser, new Vector3(transform.position.x + _fox.getFacing() * (transform.lossyScale.x * 4f), transform.position.y, transform.position.y), transform.rotation) as Bullet;
				_laser.bulletVelocity = _fox.getFacing() * 80f;
				_laser.shooter = "Player";
				_battery.Decrement (1);
			}
		}
		// semiautomatic laser
		if (Input.GetKeyDown(shoot) && selected == weaponType.SEMIAUTO)
		{
			Bullet _laser = Instantiate(laser, new Vector3(transform.position.x + _fox.getFacing() *(transform.lossyScale.x * 4f), transform.position.y, transform.position.y), transform.rotation) as Bullet;
			_laser.bulletVelocity = _fox.getFacing() * 80f;
			_laser.shooter = "Player";
		}
	}

	public void unlock(int weapon)
	{
		unlocked[weapon] = true;
	}
}
