using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using Alteruna;

public class BattleManager : AttributesSync
{
    // Start is called before the first frame update
    void Start()

    {
        if (SceneManager.GetActiveScene().name == "Battle")
        {
            Multiplayer.SpawnAvatar(GameObject.Find("SPAWNPOINT").transform.position);
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
