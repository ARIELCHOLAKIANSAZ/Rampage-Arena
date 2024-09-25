using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Alteruna;
using UnityEngine.UI;

public class DeathManager : AttributesSync
{
    [SynchronizableField] int lives1 = 3;
    [SynchronizableField] int lives2 = 3;
    [SynchronizableField] int lives3 = 3;
    [SynchronizableField] int lives4 = 3;
    public Text[] lifeDisplay;
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
        if (other.gameObject.layer == LayerMask.NameToLayer("Team1")) if (lives1 <= 0) Destroy(other.gameObject);
        if (other.gameObject.layer == LayerMask.NameToLayer("Team2")) if (lives2 <= 0) Destroy(other.gameObject);
        if (other.gameObject.layer == LayerMask.NameToLayer("Team3")) if (lives3 <= 0) Destroy(other.gameObject);
        if (other.gameObject.layer == LayerMask.NameToLayer("Team4")) if (lives4 <= 0) Destroy(other.gameObject);
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
        if (other.gameObject.layer == LayerMask.NameToLayer("Team1"))
        {
            lives1 -= 1;
            resetPercen(1);
            BroadcastRemoteMethod("livesDisplay", lives1, tpm.playNum);
        }
        if (other.gameObject.layer == LayerMask.NameToLayer("Team2"))
        {
            lives2 -= 1;
            resetPercen(2);
            BroadcastRemoteMethod("livesDisplay", lives2, tpm.playNum);
        }
        if (other.gameObject.layer == LayerMask.NameToLayer("Team3"))
        {
            lives3 -= 1;
            resetPercen(3);
            BroadcastRemoteMethod("livesDisplay", lives3, tpm.playNum);
        }
        if (other.gameObject.layer == LayerMask.NameToLayer("Team4"))
        {
            lives4 -= 1;
            resetPercen(4);
            BroadcastRemoteMethod("livesDisplay", lives4, tpm.playNum);
        }
        tpm.gravAffect = true;
        tpm.locked = false;
        tpm.jlock = false;
    }
    void resetPercen(int num)
    {
        HealthManager hm = GameObject.Find("HEALTHMANAGER").GetComponent<HealthManager>();
        if (num == 1) hm.hit1 = true;
        if (num == 1) hm.dam1 = -1000;
        if (num == 2) hm.hit2 = true;
        if (num == 2) hm.dam2 = -1000;
        if (num == 3) hm.hit3 = true;
        if (num == 3) hm.dam3 = -1000;
        if (num == 4) hm.hit4 = true;
        if (num == 4) hm.dam4 = -1000;
    }
    [SynchronizableMethod]
    void livesDisplay(int life, int pn)
    {
        lifeDisplay[pn - 1].text = life.ToString();
    }
}
