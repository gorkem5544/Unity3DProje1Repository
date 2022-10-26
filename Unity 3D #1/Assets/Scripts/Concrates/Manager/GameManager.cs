using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public event System.Action onGameOver;
    public event System.Action onMissionSucces;

    public static GameManager Instance { get; set; }
    private void Awake()
    {
        SingeltonThisGameObject();
    }

    private void SingeltonThisGameObject()
    {
        if (Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(this.gameObject);
        }
        else
        {
            Destroy(this.gameObject);
        }
    }

    public void GameOver()
    {
        onGameOver?.Invoke();
    }
    public void MissionSucces()
    {
        onMissionSucces?.Invoke();
    }


    public void LoadLevelScene(int levelIndex = 0)
    {

        StartCoroutine(LoadLevelSceneAsync(levelIndex));
        Debug.Log("Deneme1");
    }
    private IEnumerator LoadLevelSceneAsync(int levelIndex)
    {
        yield return SceneManager.LoadSceneAsync(SceneManager.GetActiveScene().buildIndex + levelIndex);
    }
    public void GameExit()
    {
        Application.Quit();
    }
    public void LoadMenu()
    {
        StartCoroutine(LoadMenuSceneAsync());
    }

    private IEnumerator LoadMenuSceneAsync()
    {
        yield return SceneManager.LoadSceneAsync("Menu");
    }
}
