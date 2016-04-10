using UnityEngine;
using System.Collections;

public class ZombieMovement : MonoBehaviour {
    //You may consider adding a rigid body to the zombie for accurate physics simulation
    private GameObject wayPoint;
    private Vector3 wayPointPos;
    //This will be the zombie's speed. Adjust as necessary.
    private float speed = 24.0f;
    private float timer = 1.5f;
    void Start()
    {
        //At the start of the game, the zombies will find the gameobject called wayPoint.
        wayPoint = GameObject.Find("wayPoint");
    }

    void Update()
    {
        if (timer > 0)
        {
            timer -= Time.deltaTime;
        }
        if (timer <= 0)
        {
            //The position of the waypoint will update to the player's position
            wayPointPos = new Vector3(wayPoint.transform.position.x, transform.position.y, wayPoint.transform.position.z);
            //Here, the zombie's will follow the waypoint.
            transform.position = Vector3.MoveTowards(transform.position, wayPointPos, speed * Time.deltaTime);
            timer = 0.5f;
        }
        
    }
}
