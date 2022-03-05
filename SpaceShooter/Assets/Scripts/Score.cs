using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Score : MonoBehaviour
{
    // variables and objects are set
    public Text totalScore;
    public static int score = 0;

    // when called, score will increase
    public void getScore()
    {
        score++;
    }

    // score gets set as the UI text
    void Start()
    {
        totalScore = GetComponent<Text> ();
    }

    // text and score gets updated to the UI text
    void Update()
    {
        totalScore.text = "Score: " + score;
    }
}
