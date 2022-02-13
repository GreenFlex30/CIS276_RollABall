using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    public GameObject ballPrefab;

    // Update is called once per frame
    void Update()
    {
        if (Input.GetButton("Fire1"))
        {
            GameObject ball;
            //Rigidbody rb;
            ball = Instantiate(ballPrefab, transform);

            ball.GetComponent<Rigidbody>().AddForce(Vector3.up * 10f, ForceMode.Impulse);
            //rb = ball.GetComponent<Rigidbody>();
            //rb.AddForce(Vector3.up * 10f);
        }
        if(Input.GetKey(KeyCode.Space))
        {

        }
    }
}
