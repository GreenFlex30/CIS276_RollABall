using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpaceTransform2 : MonoBehaviour
{
    public Vector2 localSpacePoint;

    private void OnDrawGizmos()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawRay(transform.position, transform.right);
        Gizmos.color = Color.green;
        Gizmos.DrawRay(transform.position, transform.up);

        Gizmos.color = Color.blue;
        Vector2 worldSpacePoint = LocalToWorld(localSpacePoint);

        Gizmos.DrawSphere(worldSpacePoint, 0.15f);
    }

    
    Vector2 LocalToWorld(Vector2 localPoint)
    {
        Vector2 worldOffset = (transform.right * localPoint.x) + (transform.up * localPoint.y);
        return (Vector2)transform.position + worldOffset;
    }
}
