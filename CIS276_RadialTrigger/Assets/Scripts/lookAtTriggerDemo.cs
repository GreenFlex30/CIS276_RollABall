using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class lookAtTriggerDemo : MonoBehaviour
{
    // Start is called before the first frame update
    [Range(0f,1f)]
    public float threshold = 0.5f;

    public Transform playerTransfrom;

    private void OnDrawGizmos()
    {
        Vector2 position = transform.position;
        Vector2 playerPosition = playerPosition.position;
        Vector2 playerLookDir = playerTransfrom.right;

        Vector2 playerToEnemyDir = (position - playerLookDir).normalized;

        float lookingTowardsValue = Vector2.Dot(playerToEnemyDir, playerLookDir);
        dotProduct = lookingTowardsValue;

        bool canSeePlayer = lookingTowardsValue >= threshold;

        Gizmos.color = canSeePlayer ? Color.green : Color.red;
        Gizmos.DrawLine(position, playerPosition + playerToEnemyDir);

        Gizmos.color = Color.yellow;
        Gizmos.DrawLine(playerPosition, playerPosition + playerLookDir);
    }
}
