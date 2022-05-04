using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MainTimer : MonoBehaviour
{
    float current = 0;
    public float startTime = 10f;

    [SerializeField] Text timeCountText;

    private Mess mess;

    private void Awake()
    {
        mess = GetComponent<Mess>();
    }

    // Start is called before the first frame update
    void Start()
    {
        current = startTime;
    }

    // Update is called once per frame
    void Update()
    {
        current -= 1 * Time.deltaTime;
        timeCountText.text = current.ToString("0");

        if(current <= 0)
        {
            current = 0;
            StartCoroutine(gameOverTimer());
            //gameOver();
        }
    }

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
    IEnumerator gameOverTimer()
    {
        while (true)
        {
            yield return new WaitForSeconds(1.0f);
            gameOver();
        }
    }
}
