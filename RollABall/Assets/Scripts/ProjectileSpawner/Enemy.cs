using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    // Enemy's health. You can find it in Inspector
    public int hp = 100;

    // For when a projectile collides with the Enemy
    private void OnTriggerEnter(Collider other)
    {
        // checks if object collided is a projectile
        if(other.gameObject.tag == "Projectile")
        {
            // health decreases by 25
            hp -= 25;

            // Enemy gets deleted on zero health
            if(hp <= 0)
            {
                Destroy(gameObject);
            }
        }
    }
}
