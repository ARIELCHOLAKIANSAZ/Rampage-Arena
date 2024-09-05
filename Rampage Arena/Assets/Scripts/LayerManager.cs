using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Alteruna;

public class LayerManager : AttributesSync
{
    string[] players = { "", "", "", "" };
    private Alteruna.Avatar ava;

    void Start()
    {
        ava = GetComponent<Alteruna.Avatar>();
        Debug.Log("preava");
        if (!ava.IsMe) return;
        Debug.Log("posava");
        PlayerManager p = GameObject.Find("PLAYERMANAGER").GetComponent<PlayerManager>();

        if (p.playerNumber == 1)
        {
            BroadcastRemoteMethod("setPlayer", 0, gameObject.name);
        }
        else if (p.playerNumber == 2)
        {
            BroadcastRemoteMethod("setPlayer", 1, gameObject.name);
        }
        else if (p.playerNumber == 3)
        {
            BroadcastRemoteMethod("setPlayer", 2, gameObject.name);
        }
        else if (p.playerNumber == 4)
        {
            BroadcastRemoteMethod("setPlayer", 3, gameObject.name);
        }
        Debug.Log("name 2: " + players[1]);
        Debug.Log("name 3: " + players[2]);

        if (p.activePlayerList[0] == true) GameObject.Find(players[0]).layer = LayerMask.NameToLayer("Team1");
        if (p.activePlayerList[1] == true) GameObject.Find(players[1]).layer = LayerMask.NameToLayer("Team2");
        if (p.activePlayerList[2] == true) GameObject.Find(players[2]).layer = LayerMask.NameToLayer("Team3");
        if (p.activePlayerList[3] == true) GameObject.Find(players[3]).layer = LayerMask.NameToLayer("Team4");

        AttacksManager am = GetComponent<AttacksManager>();
        am.enemyLayers &= ~(1 << gameObject.layer);
    }
    [SynchronizableMethod]
    void setPlayer(int numb, string name)
    {
        players[numb] = name;
    }
}
