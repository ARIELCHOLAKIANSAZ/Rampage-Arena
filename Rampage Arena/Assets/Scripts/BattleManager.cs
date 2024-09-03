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
            PlayerManager p = GetComponent<PlayerManager>();
            if (p.playerNumber == 1)
            {
                Multiplayer.SpawnAvatar(GameObject.Find("SPAWNPOINT1").transform.position);
            }
            else if (p.playerNumber == 2)
            {
                Multiplayer.SpawnAvatar(GameObject.Find("SPAWNPOINT2").transform.position);
            }
            else if (p.playerNumber == 3)
            {
                Multiplayer.SpawnAvatar(GameObject.Find("SPAWNPOINT3").transform.position);
            } 
            else if (p.playerNumber == 4)
            {
                Multiplayer.SpawnAvatar(GameObject.Find("SPAWNPOINT4").transform.position);
            }
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
