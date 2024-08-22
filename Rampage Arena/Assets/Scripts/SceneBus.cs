using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SceneBus : MonoBehaviour
{
    public static SceneBus Instance;
    void Awake()
    {
        if (Instance != this && Instance != null)
        {
            Destroy(this);
        }
        else
        {
            Instance = this;
        }

        DontDestroyOnLoad(this);
    }
}
