using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using Alteruna;

public class BattleManager : AttributesSync
{
        Vector3 sp = new Vector3 (0, 0, 0);
    void Start()
    {  
        int p = GameObject.Find("PLAYERMANAGER").GetComponent<PlayerManager>().playerNumber;
        Debug.Log(p);
        if (p == 1)
        {
            sp = GameObject.Find("SPAWNPOINT1").transform.position;
        }
        else if (p == 2)
        {
            sp = GameObject.Find("SPAWNPOINT2").transform.position;
        }
        else if (p == 3)
        {
            sp = GameObject.Find("SPAWNPOINT3").transform.position;
        } 
        else if (p == 4)
        {
            sp = GameObject.Find("SPAWNPOINT4").transform.position;
        }
            Multiplayer.SpawnAvatar(sp);
    }

    void Update()
    {
        
    }
}