using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MainMenuFunction : MonoBehaviour
{
    // variables and objects set
    public Button startButton;
    public Button exitButton;
    public string gameSceneName;

    // listeners are initiated
    private void Start()
    {
        startButton.onClick.AddListener(LoadGameScene);
        exitButton.onClick.AddListener(QuitGame);
    }

    // action to start the game (go to MainGame scene)
    public void LoadGameScene()
    {
        GameSceneManager.Instance.LoadScene(gameSceneName);
    }

    // action to exit the game application
    public void QuitGame()
    {
        Time.timeScale = 1f;
        Application.Quit();
    }
}
