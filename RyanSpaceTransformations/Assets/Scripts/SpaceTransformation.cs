using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpaceTransformation : MonoBehaviour
{
    public Vector2 worldSpacePoint;
    public Transform localObjectTransform;

    private void OnDrawGizmos()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawRay(transform.position, transform.right);
        Gizmos.color = Color.green;
        Gizmos.DrawRay(transform.position, transform.up);

        Gizmos.color = Color.yellow;

        Gizmos.DrawSphere(worldSpacePoint, 0.15f);

        localObjectTransform.localPosition = WorldToLocal(worldSpacePoint);
    }

    Vector2 WorldToLocal(Vector2 WorldPoint)
    {
        Vector2 relativePoint = WorldPoint - (Vector2)transform.position;
        float x = Vector2.Dot(relativePoint, transform.right);
        float y = Vector2.Dot(relativePoint, transform.up);

        return new Vector2(x, y);
    }
}
