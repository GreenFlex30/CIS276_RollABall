using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MainMenuFunction : MonoBehaviour
{
    public Button startButton;
    public Button exitButton;
    public string gameSceneName;

    private void Start()
    {
        startButton.onClick.AddListener(LoadGameScene);
        exitButton.onClick.AddListener(QuitGame) ;
    }

    public void LoadGameScene()
    {
        GameSceneManager.Instance.LoadScene(gameSceneName);
    }

    public void QuitGame()
    {
        Time.timeScale = 0f;
        Application.Quit();
    }
}
