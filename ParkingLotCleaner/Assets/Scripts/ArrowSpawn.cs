using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ArrowSpawn : MonoBehaviour
{
    public GameObject arrowVan;

    private void Update()
    {
        // checks if all dirtspots are gone
        if (Mess.dirtLeft == 0)
        {
            StartCoroutine(spawnArrowTimer());
        }
    }

    // spawns an arrow in the position of the spawner when called
    public void spawnArrow()
    {
        if (Mess.dirtLeft == 0)
        {
            GameObject arrow;

            arrow = Instantiate(arrowVan, transform.position, transform.rotation);
        }
    }

    // timer for calling an arrow
    IEnumerator spawnArrowTimer()
    {
        while (true)
        {
            yield return new WaitForSeconds(1.0f);
            spawnArrow();
        }
    }
}
