using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MainMenuUI : MonoBehaviour
{
    // variables and objects set
    public Button level1Button;
    public Button level2Button;
    public Button exitButton;

    public DirtSpawn dirtSpawn;

    public void Awake()
    {
        dirtSpawn = GetComponent<DirtSpawn>();
    }

    // listeners are initiated
    private void Start()
    {
        level1Button.onClick.AddListener(LoadLevel1);
        level2Button.onClick.AddListener(LoadLevel2);
        exitButton.onClick.AddListener(QuitGame);
    }

    // action to start the mall level
    public void LoadLevel1()
    {
        Mess.dirtLeft = 10;
        //dirtSpawn.loadDirt();
        GameSceneManager.Instance.LoadScene("Mall");
    }

    // action to start the mall level
    public void LoadLevel2()
    {
        Mess.dirtLeft = 10;
        GameSceneManager.Instance.LoadScene("MultiLevel");
    }

    // action to exit the game application
    public void QuitGame()
    {
        Time.timeScale = 1f;
        Application.Quit();
    }
}