using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCollider : MonoBehaviour
{
    public int health = 100;

    // Start is called before the first frame update
    private void OnTriggerEnter(Collider other)
    {
        // checks if object collided is a projectile
        if (other.gameObject.tag == "EnemyFire" || other.gameObject.tag == "Enemy")
        {
            health -= 10;

            if (health < 0)
            {
                Destroy(gameObject);
            }
        }
        else if(other.gameObject.tag == "Obstacle")
        {
            health -= 15;

            if(health < 0)
            {
                Destroy(gameObject);
            }
        }
    }
}
