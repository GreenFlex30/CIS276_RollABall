using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RayCastTest : MonoBehaviour
{
    // Update is called once per frame
    void Update()
    {
        // Raycast and info variables created
        Ray r = new Ray(transform.position, transform.forward);
        RaycastHit hitIntel;

        //PhysicMaterial.Raycast(transform.position, transform.forward);

        if (Physics.Raycast(r, out hitIntel, 10f/*, mask*/))
        {
            // Orb sees something
            Debug.DrawLine(transform.position, hitIntel.point, Color.green);
        }
        else
        {
            // Orb does not see any object in range
            Debug.DrawLine(r.origin, r.origin + r.direction * 10f, Color.red);
        }
    }
}
