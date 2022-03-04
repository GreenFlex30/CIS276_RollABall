using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Projectiles : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        // checks if object collided is a projectile
        if (other.gameObject.tag == "Enemy" || other.gameObject.tag == "Border" || other.gameObject.tag == "Spawner" || other.gameObject.tag == "Obstacle" || other.gameObject.tag == "Dump")
        {
            Destroy(gameObject);
        }
    }
}
