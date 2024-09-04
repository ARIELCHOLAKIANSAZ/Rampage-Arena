using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Alteruna;
using JetBrains.Annotations;
using UnityEngine.EventSystems;

public class KnockbackHandler : AttributesSync
{
    [SynchronizableField] public float mainx;
    [SynchronizableField] public float mainy;
    [SynchronizableField] public float mainz;
    [SynchronizableField] public float force;
    [SynchronizableField] public bool hit1 = false;
    [SynchronizableField] public bool hit2 = false;
    [SynchronizableField] public bool hit3 = false;
    [SynchronizableField] public bool hit4 = false;
    private float knockbackCounter;
    [SynchronizableField] public float time;
    public PlayerManager p;
    AttacksManager atmg;
    ThirdPersonMovement tpm;
    public CharacterController cont;
    private bool lockKey;
    void Awake()
    {
        p = GameObject.Find("PLAYERMANAGER").GetComponent<PlayerManager>();
        atmg = GetComponent<AttacksManager>();
        tpm = GetComponent<ThirdPersonMovement>();
    }
    void Update()
    {
        if(knockbackCounter <= 0 && lockKey == true)
        {
            lockKey = false;           
            atmg.lcked = false;
            tpm.jlock = false;            
            tpm.locked = false;
        }
        else if(knockbackCounter > 0)
        {
            knockbackCounter =- Time.deltaTime;
            tpm.jlock = true;
            atmg.lcked = true;
            tpm.locked = true;
        }
        if(p.playerNumber == 1)
        {
            if(hit1)
            {
                hit1=false;
                Vector3 direction = transform.position - new Vector3(mainx, mainy, mainz);
                Knockback(direction.normalized);
            }
        }
        else if (p.playerNumber == 2)
        {
            if(hit2)
            {
                hit2=false;
                Vector3 direction = transform.position - new Vector3(mainx, mainy, mainz);
                Knockback(direction.normalized);
            }
        }
        else if (p.playerNumber == 3)
        {
            if(hit3)
            {
                hit3=false;
                Vector3 direction = transform.position - new Vector3(mainx, mainy, mainz);
                Knockback(direction.normalized);
            }
        }
        else if (p.playerNumber == 4)
        {
            if(hit4)
            {
                hit4=false;
                Vector3 direction = transform.position - new Vector3(mainx, mainy, mainz);
                Knockback(direction.normalized);
            }
        }
    }
    public void Knockback(Vector3 direction)
    {
        knockbackCounter = time;
        Vector3 moveDir = (direction * force);
        cont.Move(moveDir);
    }
}
