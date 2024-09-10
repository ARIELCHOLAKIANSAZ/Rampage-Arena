using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Alteruna;

public class LayerManager : AttributesSync
{
    string[] players = { "", "", "", "" };
    private Alteruna.Avatar ava;
    PlayerManager p;
    string goName;
    string[] nameArray = { "", "", "", "" };

    private void Awake()
    {
        ava = GetComponent<Alteruna.Avatar>();
        if (!ava.IsMe) return;
        p = GameObject.Find("PLAYERMANAGER").GetComponent<PlayerManager>();
        var avaArray = FindObjectsOfType<Alteruna.Avatar>();
        for (int i = 0; i < avaArray.Length; i++)
        {
            nameArray[i] = avaArray[i].gameObject.name;
        }
    }

    void Start()
    {
        AttacksManager am = GetComponent<AttacksManager>();
        am.enemyLayers &= ~(1 << gameObject.layer);
    }

    private void Update()
    {

        if (p.playerNumber == 1 && players[0] == "")
        {
            BroadcastRemoteMethod("setPlayer", 0);
        }
        if (p.playerNumber == 2 && players[0] == "")
        {
            BroadcastRemoteMethod("setPlayer", 1);
        }
        if (p.playerNumber == 3 && players[0] == "")
        {
            BroadcastRemoteMethod("setPlayer", 2);
        }
        if (p.playerNumber == 4 && players[0] == "")
        {
            BroadcastRemoteMethod("setPlayer", 3);
        }
        if (p.activePlayerList[0] == true && GameObject.Find(players[0]).layer != LayerMask.NameToLayer("Team1")) GameObject.Find(players[0]).layer = LayerMask.NameToLayer("Team1");
        if (p.activePlayerList[1] == true && GameObject.Find(players[1]).layer != LayerMask.NameToLayer("Team2")) GameObject.Find(players[1]).layer = LayerMask.NameToLayer("Team2");
        if (p.activePlayerList[2] == true && GameObject.Find(players[2]).layer != LayerMask.NameToLayer("Team3")) GameObject.Find(players[2]).layer = LayerMask.NameToLayer("Team3");
        if (p.activePlayerList[3] == true && GameObject.Find(players[3]).layer != LayerMask.NameToLayer("Team4")) GameObject.Find(players[3]).layer = LayerMask.NameToLayer("Team4");
    }

    [SynchronizableMethod]
    void setPlayer(int numb)
    {
        for(int i = 0; i < nameArray.Length; i++)
        {
            if (nameArray[i] == this.gameObject.name) players[numb] = nameArray[i];
        }
    }
}
