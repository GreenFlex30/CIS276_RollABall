using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    public int hp = 100;

    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.tag == "Projectile")
        {
            hp -= 25;

            if(hp <= 0)
            {
                Destroy(gameObject);
            }
        }
    }
}
