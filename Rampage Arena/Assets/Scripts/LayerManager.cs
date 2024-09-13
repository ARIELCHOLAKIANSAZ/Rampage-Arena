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
        ava = GetComponent<Alteruna.Avatar>();
        if (!ava.IsMe) return;
        StartCoroutine(setLayers());
    }

    IEnumerator setLayers()
    {
        yield return new WaitForSeconds(3);
        Alteruna.Avatar[] avaArray = FindObjectsOfType<Alteruna.Avatar>();
        for (int i = 0; i < avaArray.Length; i++)
        {
            nameArray[i] = avaArray[i].gameObject.name;
        }
        for(int i = 0; i < nameArray.Length; i++)
        {
            Debug.Log("name " + i + ": " + nameArray[i]);
        }
        AttacksManager am = GetComponent<AttacksManager>();
        p = GameObject.Find("PLAYERMANAGER").GetComponent<PlayerManager>();
;       
        for(int i = 0; i < avaArray.Length; i++)
        {
            if (GameObject.Find(nameArray[i]).GetComponent<ThirdPersonMovement>().playNum == 1) GameObject.Find(nameArray[i]).layer = LayerMask.NameToLayer("Team1"); Debug.Log("Attempted to turn " + nameArray[i] + " into Team 1");
            if (GameObject.Find(nameArray[i]).GetComponent<ThirdPersonMovement>().playNum == 2) GameObject.Find(nameArray[i]).layer = LayerMask.NameToLayer("Team2"); Debug.Log("Attempted to turn " + nameArray[i] + " into Team 2");
            if (GameObject.Find(nameArray[i]).GetComponent<ThirdPersonMovement>().playNum == 3) GameObject.Find(nameArray[i]).layer = LayerMask.NameToLayer("Team3"); Debug.Log("Attempted to turn " + nameArray[i] + " into Team 3");
            if (GameObject.Find(nameArray[i]).GetComponent<ThirdPersonMovement>().playNum == 4) GameObject.Find(nameArray[i]).layer = LayerMask.NameToLayer("Team4"); Debug.Log("Attempted to turn " + nameArray[i] + " into Team 4");
        }
        am.enemyLayers &= ~(1 << gameObject.layer);

    }
}
