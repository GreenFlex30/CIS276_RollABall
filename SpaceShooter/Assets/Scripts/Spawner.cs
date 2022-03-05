using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    public GameObject SpaceRock;
    public GameObject SpaceEnemy;
    public double time = 0;

    public float respawn = 1.0f;

    // range from coords: -10.5,7.75 to 10.5,7.75
    public int xCo;

    void Start()
    {
        StartCoroutine(SpawnTimerObs());
        StartCoroutine(SpawnTimerEnemy());
    }

    // Update is called once per frame
    void Update()
    {
        SpawnTimerEnemy();
        SpawnTimerObs();
    }

    private void spawnObstacle()
    {
        xCo = Random.Range(-10, 10);
        GameObject obstacle;
        obstacle = Instantiate(SpaceRock, new Vector2(xCo, 7), Quaternion.identity);

        obstacle.GetComponent<Rigidbody>().AddForce(Vector2.down * 7f, ForceMode.Impulse);
    }

    private void spawnEnemy()
    {
        xCo = Random.Range(-10, 10);
        GameObject enemyShip;
        enemyShip = Instantiate(SpaceEnemy, new Vector2(xCo, 7), Quaternion.identity);

        enemyShip.GetComponent<Rigidbody>().AddForce(Vector2.down * 7f, ForceMode.Impulse);
    }

    IEnumerator SpawnTimerObs()
    {
        while(true)
        {
            yield return new WaitForSeconds(1.0f);
            spawnObstacle();
        }
    }

    IEnumerator SpawnTimerEnemy()
    {
        Debug.Log("Reached");
        while (true)
        {
            yield return new WaitForSeconds(1.0f);
            spawnEnemy();
        }
    }
}