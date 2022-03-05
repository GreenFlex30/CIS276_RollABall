using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameSceneManager : MonoBehaviour
{
    public static GameSceneManager Instance;
    public float uiLoadTime = 0.5f;
    private AsyncOperation asyncOperation;

    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
    }

    public void GetReferences()
    {

    }

    public void LoadScene(string sceneName)
    {
        Time.timeScale = 1f;
        StartCoroutine(LoadNewScene(sceneName));
    }

    private IEnumerator LoadNewScene(string sceneName)
    {
        yield return null;
        Time.timeScale = 0f;

        yield return new WaitForSecondsRealtime(uiLoadTime);
        asyncOperation = SceneManager.LoadSceneAsync(sceneName);

        while(!asyncOperation.isDone)
        {
            yield return null;
        }
    }
}
