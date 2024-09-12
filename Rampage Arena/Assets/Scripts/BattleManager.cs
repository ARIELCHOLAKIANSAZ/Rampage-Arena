using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using Alteruna;
using UnityEngine.UI;

public class BattleManager : AttributesSync
{
    public Vector3 sp = new Vector3 (0, 0, 0);
    public Text count;
    public void Start()
    {  
        int p = GameObject.Find("PLAYERMANAGER").GetComponent<PlayerManager>().playerNumber;
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
        StartCoroutine(countDown());
    }


    IEnumerator countDown()
    {
        count.text = "3";
        Alteruna.Avatar[] gaobjs = FindObjectsOfType<Alteruna.Avatar>();
        ThirdPersonMovement[] tpm = { null, null, null, null };
        for (int i = 0; i < gaobjs.Length; i++)
        {
            tpm[i] = gaobjs[i].gameObject.GetComponent<ThirdPersonMovement>();
        }
        AttacksManager[] am = { null, null, null, null };
        for (int i = 0; i < gaobjs.Length; i++)
        {
            am[i] = gaobjs[i].gameObject.GetComponent<AttacksManager>();
        }
        for (int i = 0; i < gaobjs.Length; i++)
        {
            am[i].lcked = true;
            tpm[i].locked = true;
            tpm[i].jlock = true;
        }
        yield return new WaitForSeconds(1);
        count.text = "2";
        yield return new WaitForSeconds(1);
        count.text = "1";
        yield return new WaitForSeconds(1);
        for (int i = 0; i < gaobjs.Length; i++)
        {
            am[i].lcked = false;
            tpm[i].locked = false;
            tpm[i].jlock = false;
        }
        count.text = "RAMPAGE";
        yield return new WaitForSeconds(1);
        count.text = "";
    }
}
