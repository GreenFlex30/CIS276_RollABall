using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PauseUI : MonoBehaviour
{
    public GameObject pauseMenu;
    public Button resumeButton;
    public Button menuButton;
    public string gameSceneName;
    public bool gameStopped = false;
    public Text totalScore;

    private void Start()
    {
        resumeButton.onClick.AddListener(Resume);
        menuButton.onClick.AddListener(LoadMainMenu);
    }

    public void LoadMainMenu()
    {
        GameSceneManager.Instance.LoadScene(gameSceneName);
    }

    public void Update()
    {
        if(Input.GetKeyDown(KeyCode.Escape))
        {
            if(gameStopped)
            {
                Resume();
            }
            else
            {
                Pause();
            }
        }
    }

    void Resume()
    {
        pauseMenu.SetActive(false);
        Time.timeScale = 1f;
        gameStopped = false;
    }

    void Pause()
    {
        pauseMenu.SetActive(true);
        Time.timeScale = 0f;
        gameStopped = true;
    }
}
