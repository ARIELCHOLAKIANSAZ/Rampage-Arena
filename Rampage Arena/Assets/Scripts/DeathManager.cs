using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Alteruna;

public class DeathManager : MonoBehaviour
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
        Debug.Log(lives.ToString());
    }
}
