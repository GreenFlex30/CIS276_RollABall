using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    public GameObject ballPrefab;

    // Update is called once per frame
    void Update()
    {
        if (Input.GetButtonDown("Fire1"))
        {
            GameObject ball;
            ball = Instantiate(ballPrefab, transform);

            ball.GetComponent<Rigidbody>().AddForce(Vector3.back * 30f, ForceMode.Impulse);
        }
    }
}
