using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Score : MonoBehaviour
{
    public Text totalScore;
    public static int score = 0;

    public void getScore()
    {
        score++;
    }

    void Start()
    {
        totalScore = GetComponent<Text> ();
    }

    void Update()
    {
        totalScore.text = "Score: " + score;
    }
}
