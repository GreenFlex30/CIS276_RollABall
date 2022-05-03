using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainGameManager : MonoBehaviour
{
    public int timeLeft = 540;

    public void timer()
    {
        if(timeLeft == 0)
        {
            // display Game Over
            // exit to main menu
        }
    }

    public void win()
    {
        // display win text
        // wait a couple seconds
        // send to main menu
    }

    // Start is called before the first frame update
    void Start()
    {
        // display text
        // wait a couple of seconds
        // method to start timer
    }

    // Update is called once per frame
    void Update()
    {
        timer();
    }
}
