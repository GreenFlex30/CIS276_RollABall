using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ArrowSpawn : MonoBehaviour
{
    public GameObject arrowVan;

    private void Update()
    {
        if (Mess.dirtLeft == 0)
        {
            StartCoroutine(spawnArrowTimer());
        }
    }

    public void spawnArrow()
    {
        if (Mess.dirtLeft == 0)
        {
            GameObject arrow;

            arrow = Instantiate(arrowVan, transform.position, transform.rotation);
        }
    }

    IEnumerator spawnArrowTimer()
    {
        while (true)
        {
            yield return new WaitForSeconds(1.0f);
            spawnArrow();
        }
    }
}
