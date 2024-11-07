using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using Alteruna;

public class GameManager : AttributesSync
{
    public static GameManager Instance;

    void Awake()
    {
        if(Instance != this && Instance != null)
        {
            Destroy(this);
        }
        else
        {
            Instance = this;
        }

        DontDestroyOnLoad(this);
    }

    void Update()
    {
        if (Input.anyKeyDown && SceneManager.GetActiveScene().name == "Menu") ChangeSceneSingle("Hub");
        if (SceneManager.GetActiveScene().name == "Battle") Screen.lockCursor = true;
        else Screen.lockCursor = false;
    }

    public void ChangeScene(string sceneName)
    {
        BroadcastRemoteMethod("ChangeSceneSingle", sceneName);
    }

    [SynchronizableMethod]
    public void ChangeSceneSingle(string sceneName)
    {
        SceneManager.LoadScene(sceneName);
    }
}
