using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Alteruna;

public class DeathManager : MonoBehaviour
{
    int lives = 3; 
    private void OnTriggerExit(Collider other)
    {
        Debug.Log("left");
        Alteruna.Avatar ava = other.GetComponent<Alteruna.Avatar>();
        if (!ava.IsMe) return;
        Debug.Log("avaisme");
        ava.gameObject.transform.position = GameObject.Find("SPAWNPOINT1").transform.position;
        Debug.Log("positioned");
        lives -= 1;
        Debug.Log(lives.ToString());
        if (lives <= 0)
        {
            Destroy(ava.gameObject);
        }
    }
}
