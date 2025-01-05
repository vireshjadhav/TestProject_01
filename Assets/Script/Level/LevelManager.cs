using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelManager : MonoBehaviour
{
    private int currentSceneIndex;

    // Start is called before the first frame update
    void Start()
    {
        currentSceneIndex = SceneManager.GetActiveScene().buildIndex;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void OnLevelComplete()
    {
        LoadNextLevel();
    }

    private void LoadNextLevel()
    {
        int nextSceneIndex = currentSceneIndex + 1;
        int totalNumberOfScene = SceneManager.sceneCountInBuildSettings;

        if (nextSceneIndex < totalNumberOfScene)
        {
            SceneManager.LoadScene(nextSceneIndex);
        }
        else
        {
            Debug.Log("You're completed all levels!");
        }
    }

    public void OnPlayerDeath() => RestartLevel();

    public void RestartLevel() => SceneManager.LoadScene(currentSceneIndex);
}
