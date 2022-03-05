using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Projectiles : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        // checks if object collided is an enemy or obstacle, where score will be given
        if (other.gameObject.tag == "Enemy" || other.gameObject.tag == "Obstacle")
        {
            Score.score += 10;
            Destroy(gameObject);
        }
        // checks if object collided is the border, spawner, or garbage collector
        else if (other.gameObject.tag == "Border" || other.gameObject.tag == "Spawner" || other.gameObject.tag == "Dump")
        {
            Destroy(gameObject);
        }
    }
}
