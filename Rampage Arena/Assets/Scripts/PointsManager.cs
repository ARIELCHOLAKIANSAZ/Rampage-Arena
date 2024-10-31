using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PointsManager : MonoBehaviour
{
    public static PointsManager Instance;
    GameObject P1;
    GameObject P2;
    GameObject P3;
    GameObject P4;

    void Awake()
    {
        if (Instance != this && Instance != null) Destroy(this);
        else Instance = this;
        DontDestroyOnLoad(this);
    }
    void Start()
    {
        
    }
    void Update()
    {
        if (SceneManager.GetActiveScene().name == "Battle")
        {
            
        }
    }
}
