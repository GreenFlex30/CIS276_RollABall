using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Trashcan : MonoBehaviour
{
    // Start is called before the first frame update
    private void OnTriggerEnter(Collider other)
    {
        // enemies and obstacles will be destroyed when collided with the garbage collector
        if (other.gameObject.tag == "Enemy" || other.gameObject.tag == "Obstacle")
        {
            Destroy(other.gameObject);
        }
    }
}
