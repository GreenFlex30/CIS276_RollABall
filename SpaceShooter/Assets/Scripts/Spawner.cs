using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    // variables and objects set
    public GameObject SpaceRock;
    public GameObject SpaceEnemy;
    // range from coords: -10.5x,7.75y to 10.5x,7.75y
    public int xCo;

    // timers intitiated for enemies and obstacles
    void Start()
    {
        StartCoroutine(SpawnTimerObs());
        StartCoroutine(SpawnTimerEnemy());
    }

    // Update is called once per frame (Unused)
    void Update()
    {
        SpawnTimerEnemy();
        SpawnTimerObs();
    }

    // to spawn an asteroid
    private void spawnObstacle()
    {
        // random X coords set
        xCo = Random.Range(-10, 10);
        GameObject obstacle;
        // object is made in-game
        obstacle = Instantiate(SpaceRock, new Vector2(xCo, 7), Quaternion.identity);

        // gets the physics
        obstacle.GetComponent<Rigidbody>().AddForce(Vector2.down * 7f, ForceMode.Impulse);
    }

    // to spawn an enemy ship
    private void spawnEnemy()
    {
        // random X coords set
        xCo = Random.Range(-10, 10);
        GameObject enemyShip;
        // object is made in-game
        enemyShip = Instantiate(SpaceEnemy, new Vector2(xCo, 7), Quaternion.identity);

        // gets the physics
        enemyShip.GetComponent<Rigidbody>().AddForce(Vector2.down * 7f, ForceMode.Impulse);
    }

    // timer for obstacles
    IEnumerator SpawnTimerObs()
    {
        while(true)
        {
            yield return new WaitForSeconds(1.0f);
            spawnObstacle();
        }
    }

    // timer for enemy ships
    IEnumerator SpawnTimerEnemy()
    {
        while (true)
        {
            yield return new WaitForSeconds(1.0f);
            spawnEnemy();
        }
    }
}