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
    }

    void Start()
    {
        Alteruna.Avatar[] avaArray = FindObjectsOfType<Alteruna.Avatar>();
        for (int i = 0; i < avaArray.Length; i++)
        {
            nameArray[i] = avaArray[i].gameObject.name;
        }
        AttacksManager am = GetComponent<AttacksManager>();
        p = GameObject.Find("PLAYERMANAGER").GetComponent<PlayerManager>();
;
        for(int i = 0; i < avaArray.Length; i++)
        {
            if (GameObject.Find(nameArray[i]).GetComponent<ThirdPersonMovement>().playNum == 1 && GameObject.Find(players[i]).layer != LayerMask.NameToLayer("Team1")) GameObject.Find(players[i]).layer = LayerMask.NameToLayer("Team1");
            if (GameObject.Find(nameArray[i]).GetComponent<ThirdPersonMovement>().playNum == 2 && GameObject.Find(players[i]).layer != LayerMask.NameToLayer("Team2")) GameObject.Find(players[i]).layer = LayerMask.NameToLayer("Team2");
            if (GameObject.Find(nameArray[i]).GetComponent<ThirdPersonMovement>().playNum == 3 && GameObject.Find(players[i]).layer != LayerMask.NameToLayer("Team3")) GameObject.Find(players[i]).layer = LayerMask.NameToLayer("Team3");
            if (GameObject.Find(nameArray[i]).GetComponent<ThirdPersonMovement>().playNum == 4 && GameObject.Find(players[i]).layer != LayerMask.NameToLayer("Team4")) GameObject.Find(players[i]).layer = LayerMask.NameToLayer("Team4");
        }
        am.enemyLayers &= ~(1 << gameObject.layer);
    }

    private void Update()
    {


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
