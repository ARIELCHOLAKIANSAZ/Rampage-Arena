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
        if (Input.anyKeyDown && SceneManager.GetActiveScene().name == "Menu") ChangeSceneSingle("RoomMenu");
    }

    public void ChangeScene(string sceneName)
    {
        Debug.Log("ChangeScene Called");
        Multiplayer.LoadScene(sceneName);
    }
    public void ChangeSceneSingle(string sceneName)
    {
        SceneManager.LoadScene(sceneName);
    }
}
