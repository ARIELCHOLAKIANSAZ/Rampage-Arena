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
        if (other.gameObject.layer == LayerMask.NameToLayer("Team1")) resetPercen(1);
        if (other.gameObject.layer == LayerMask.NameToLayer("Team2")) resetPercen(2);
        if (other.gameObject.layer == LayerMask.NameToLayer("Team3")) resetPercen(3);
        if (other.gameObject.layer == LayerMask.NameToLayer("Team4")) resetPercen(4);

         Debug.Log(lives.ToString());
    }
    [SynchronizableMethod]
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
}
