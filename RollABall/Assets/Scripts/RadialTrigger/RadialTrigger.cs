using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RadialTrigger : MonoBehaviour
{
    public Transform triggerInteractionObject;

    // Minimum and maximim length of size set
    [Range(0f, 6f)]
    public float radius = 0;

    private void OnDrawGizmos()
    {
        // nearest interactible object is the PointHolder
        Vector2 triggerPosition = triggerInteractionObject.position;
        Vector2 origin = transform.position;

        float distance = Vector2.Distance(triggerPosition, origin);

        if(distance < radius)
        {
            // If sphere touches the trigger
            Gizmos.color = Color.green;
        }
        else
        {
            // If sphere is not in touch with the trigger
            Gizmos.color = Color.red;
        }
        // The sphere is created, based on its position and set radius size
        Gizmos.DrawSphere(origin, radius);
    }
}
