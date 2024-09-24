using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Alteruna;

public class DeathManager : AttributesSync
{
    int lives = 3;
    bool done = false;
    private void OnTriggerExit(Collider other)
    {
        Debug.Log("left");
        Alteruna.Avatar ava = other.GetComponent<Alteruna.Avatar>();
        if (!ava.IsMe) return;
        Debug.Log("avaisme");
        ThirdPersonMovement tpm = other.GetComponent<ThirdPersonMovement>();
        tpm.gravAffect = false;
        tpm.locked = true;
        tpm.jlock = true;
        StartCoroutine(timer(other, tpm));
        if (lives <= 0)
        {
            Destroy(other.gameObject);
        }
    }
    IEnumerator timer(Collider other, ThirdPersonMovement tpm)
    {
        yield return new WaitForSeconds(0.1f);
        other.transform.position = GameObject.Find("SPAWNPOINT1").transform.position;
        Debug.Log(other.transform.position.ToString() + " positioned to " + GameObject.Find("SPAWNPOINT1").transform.position);
        yield return new WaitForSeconds(0.05f);
        other.transform.position = GameObject.Find("SPAWNPOINT1").transform.position;
        Debug.Log(other.transform.position.ToString() + " positioned to " + GameObject.Find("SPAWNPOINT1").transform.position);
        yield return new WaitForSeconds(0.1f);
        lives -= 1;
        tpm.gravAffect = true;
        tpm.locked = false;
        tpm.jlock = false;
        if (other.gameObject.layer == LayerMask.NameToLayer("Team1")) BroadcastRemoteMethod("resetPercen", 0);
        if (other.gameObject.layer == LayerMask.NameToLayer("Team2")) BroadcastRemoteMethod("resetPercen", 1);
        if (other.gameObject.layer == LayerMask.NameToLayer("Team3")) BroadcastRemoteMethod("resetPercen", 2);
        if (other.gameObject.layer == LayerMask.NameToLayer("Team4")) BroadcastRemoteMethod("resetPercen", 3);

         Debug.Log(lives.ToString());
    }
    [SynchronizableMethod]
    void resetPercen(int num)
    {
        Debug.Log("team " + (num + 1));
        HealthManager hm = GameObject.Find("HEALTHMANAGER").GetComponent<HealthManager>();
        hm.percen[num] = 0;
    }
}
