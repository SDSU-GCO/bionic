using UnityEngine;
using System.Collections;

public class CameraFollow : MonoBehaviour
{
    public Transform player;
	// Use this for initialization
	void Start ()
    {
        transform.position = new Vector3(player.position.x, player.position.y, player.position.z - 10);
    }
    
    void Update()
    {
        transform.position = new Vector3(player.position.x, player.position.y, player.position.z - 10); 
    }
}
