using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DirtSpawn : MonoBehaviour
{
    public GameObject dirtSpot;
    public bool isReset = true;

    // Start is called before the first frame update
    private void Start()
    {
        GameObject dirt;

        dirt = Instantiate(dirtSpot, transform.position, transform.rotation);
    }
}
