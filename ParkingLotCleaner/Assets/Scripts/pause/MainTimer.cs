using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MainTimer : MonoBehaviour
{
    // variables
    float current = 0;
    // time can be changed to different value, usually 200
    public float startTime = 10f;

    [SerializeField] Text timeCountText;

    private Mess mess;

    // gets the Mess script
    private void Awake()
    {
        mess = GetComponent<Mess>();
    }

    // Start is called before the first frame update
    void Start()
    {
        // timer starts at default time when game begins
        current = startTime;
    }

    // Update is called once per frame
    void Update()
    {
        // timer counts down by one
        current -= 1 * Time.deltaTime;
        timeCountText.text = current.ToString("0");

        // when timer reaches 0, game over
        if(current <= 0)
        {
            current = 0;
            StartCoroutine(gameOverTimer());
            //gameOver();
        }
    }

    // sends the player back to the main menu
    public void gameOver()
    {
        if(current <= 0)
        {
            //Debug.Log("Game Over!");
            //mess.totalDirt.text = "Game Over";
            Time.timeScale = 0f;
            GameSceneManager.Instance.LoadScene("MainMenu");
        }
    }

    // timer to reduce repeats of loading the main menu scene
    IEnumerator gameOverTimer()
    {
        while (true)
        {
            yield return new WaitForSeconds(1.0f);
            gameOver();
        }
    }
}
