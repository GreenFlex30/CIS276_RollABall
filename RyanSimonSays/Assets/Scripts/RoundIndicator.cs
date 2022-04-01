using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class RoundIndicator : MonoBehaviour
{
    // variables and objects are set
    public Text currentRound;
    public static int round = 0;

    // when called, round number will increase
    public void getScore()
    {
        round++;
    }

    // round number gets set as the UI text
    void Start()
    {
        currentRound = GetComponent<Text>();
    }

    // text and round number gets updated to the UI text
    void Update()
    {
        currentRound.text = "Round: " + round;
    }
}
