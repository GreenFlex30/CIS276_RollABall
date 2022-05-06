using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RandomManagers : MonoBehaviour
{
    // gameobjects set
    public GameObject speedPwr;
    public GameObject jumpPwr;
    public GameObject dirt;

    // random variables
    public int ranSpeed;
    public int ranJump;
    public int ranDirt;

    // index variables
    public int speedNum;
    public int jumpNum;
    public int dirtNum;

    // maximum variables
    public int maxSpeed = 5;
    public int maxJump = 3;
    public int maxDirt = 10;

    // for game initiation
    public bool gameStart = true;

    // script for spawning speedBoosts
    public void spawnSpeed()
    {
        // for initiating game
        if (gameStart == true)
        {
            // starts setting up objects
            while (speedNum < maxSpeed)
            {
                speedNum++;
                GameObject speedBoost;
                // check to not overwrite existing objects in the loop
                while (ranSpeed != speedNum)
                {
                    ranSpeed = Random.Range(-5, 5);
                    speedBoost = Instantiate(speedPwr, new Vector3(ranSpeed, 0, 0), Quaternion.identity);
                }
            }
        }
        // spawns a new object after one was used by a player
        else
        {
            GameObject speedBoost;
            
            ranSpeed = Random.Range(-5, 5);
            speedBoost = Instantiate(speedPwr, new Vector3(ranSpeed, 0, 0), Quaternion.identity);
            
        }
    }

    // script for spawning jumpBoosts
    public void spawnJump()
    {
        // for initiating game
        if (gameStart == true)
        {
            // starts setting up objects
            while (jumpNum < maxJump)
            {
                jumpNum++;
                GameObject jumpBoost;
                // check to not overwrite existing objects in the loop
                while (ranJump != jumpNum)
                {
                    ranJump = Random.Range(-3, 3);
                    jumpBoost = Instantiate(jumpPwr, new Vector3(ranJump, 0, 0), Quaternion.identity);
                }
            }
        }
        else
        // spawns a new object after one was used by a player
        {
            GameObject speedBoost;

            ranSpeed = Random.Range(-5, 5);
            speedBoost = Instantiate(speedPwr, new Vector3(ranSpeed, 0, 0), Quaternion.identity);
        }
    }

    // script for spawning dirt spots
    private void spawnDirt()
    {
        // starts setting up objects
        while (dirtNum < maxDirt)
        {
            dirtNum++;
            GameObject mess;
            // check to not overwrite existing objects in the loop
            while (ranDirt != dirtNum)
            {
                ranDirt = Random.Range(-20, 20);
                mess = Instantiate(dirt, new Vector3(ranDirt, 0, 0), Quaternion.identity);
            }
        }
        // marks end of initialization, and sets bool off
        gameStart = false;
    }

    // Start is called before the first frame update
    void Start()
    {
        // initializes game
        spawnJump();
        spawnSpeed();
        spawnDirt();
    }

    // spawn timer for speed
    public IEnumerator spawnTimerSpeed()
    {
        while (true)
        {
            yield return new WaitForSeconds(10.0f);
            spawnSpeed();
        }
    }

    // spawn timer for jump
    public IEnumerator spawnTimerJump()
    {
        while (true)
        {
            yield return new WaitForSeconds(10.0f);
            spawnJump();
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}


/*
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
*/