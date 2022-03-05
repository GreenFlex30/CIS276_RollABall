using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCollider : MonoBehaviour
{
    // health is initiated
    public int health = 100;

    // Start is called before the first frame update
    private void OnTriggerEnter(Collider other)
    {
        // checks if object collided is a an enemy, and takes damage
        // NOTE: EnemyFire is not included in game
        if (other.gameObject.tag == "EnemyFire" || other.gameObject.tag == "Enemy")
        {
            health -= 10;

            if (health < 0)
            {
                Destroy(gameObject);
            }
        }
        // takes damage from obstacles as well
        else if(other.gameObject.tag == "Obstacle")
        {
            health -= 5;

            if(health < 0)
            {
                Destroy(gameObject);
            }
        }
    }
}
