using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Asteroid : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        // checks if object collided is a projectile
        if (other.gameObject.tag == "Laser" || other.gameObject.tag == "Mine" || other.gameObject.tag == "Player")
        {
            Destroy(gameObject);
        }
    }
}
