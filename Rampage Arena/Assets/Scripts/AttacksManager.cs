﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Alteruna;
using JetBrains.Annotations;

public class AttacksManager : AttributesSync
{
    public CharacterController con;
    public AnimationSynchronizable ani;
    public GameObject dada;
    public bool lcked = false;
    public Transform[] attackPoints;
    public float[] attackRanges;
    public LayerMask enemyLayers;
    bool kadoosh = false;
    private Alteruna.Avatar ava;

    void Start()
    {
        ava = GetComponent<Alteruna.Avatar>();
        if (!ava.IsMe) return;
    }
    void Update()
    {
        if (!ava.IsMe) return;

        if (Input.GetKey(KeyCode.LeftShift) && lcked == false)
        {
            if (Input.GetMouseButtonDown(0))
            {
                StartCoroutine(UpNormal());
            }

        }
        else if (Input.GetKey(KeyCode.LeftControl) && lcked == false)
        {
            if (Input.GetMouseButtonDown(0))
            {
                StartCoroutine(DownNormal());
            }
        }
        else if (Input.GetKey(KeyCode.W) && lcked == false)
        {
            if (Input.GetMouseButtonDown(0))
            {
                StartCoroutine(ForwardNormal());
            }

        }
        else if (Input.GetKey(KeyCode.A) && lcked == false)
        {
            if (Input.GetMouseButtonDown(0))
            {
                StartCoroutine(LeftNormal());
            }

        }
        else if (Input.GetKey(KeyCode.D) && lcked == false)
        {
            if (Input.GetMouseButtonDown(0))
            {
                StartCoroutine(RightNormal());
            }

        }
        else if (Input.GetKey(KeyCode.S) && lcked == false)
        {
            if (Input.GetMouseButtonDown(0))
            {
                StartCoroutine(BackNormal());
            }

        }
        else if (lcked == false)
        {
            if (Input.GetMouseButtonDown(0))
            {
                StartCoroutine(NeutralNormal());
            }

        }

        IEnumerator LeftNormal()
        {
            ThirdPersonMovement m = dada.GetComponent<ThirdPersonMovement>();
            lcked = true;
            m.locked = true;
            m.jlock = true;
            ani.Animator.SetTrigger("LeftNormal");
            yield return new WaitForSeconds(0.3f);
            Collider[] hitEnemies = Physics.OverlapSphere(attackPoints[3].position, attackRanges[3], enemyLayers);
            foreach (Collider enemy in hitEnemies)
            {
                HealthManager p = GameObject.Find("HEALTHMANAGER").GetComponent<HealthManager>();
                KnockbackHandler kn = enemy.GetComponentInParent<KnockbackHandler>();
                kn.mainx = transform.position.x;
                kn.mainy = transform.position.y;
                kn.mainz = transform.position.z;
                if (enemy.gameObject.layer == LayerMask.NameToLayer("Team 1"))
                {
                    kn.force = p.percen[0]/2;
                    p.dam[0] = 2.4f;
                    p.hit[0] = true;
                    kn.hit1 = true;
                } 
                if(enemy.gameObject.layer == 11)
                {
                    kn.force = p.percen[1]/2;
                    p.dam[1] = 2.4f;
                    p.hit[1] = true;
                    kn.hit2 = true;
                }
                if(enemy.gameObject.layer == 12) 
                {
                    kn.force = p.percen[2]/2;
                    p.dam[2] = 2.4f;
                    p.hit[2] = true;
                    kn.hit3 = true;
                }
                if(enemy.gameObject.layer == 13)
                {
                    kn.force = p.percen[3]/2;
                    p.dam[3] = 2.4f;
                    p.hit[3] = true;
                    kn.hit4 = true;
                }
            }
            yield return new WaitForSeconds(0.1f);
            m.jlock = false;
            lcked = false;
            m.locked = false;
        }

        IEnumerator RightNormal()
        {
            ThirdPersonMovement m = dada.GetComponent<ThirdPersonMovement>();
            lcked = true;
            m.jlock = true;
            m.locked = true;
            ani.Animator.SetTrigger("RightNormal");
            yield return new WaitForSeconds(0.1f);
            Collider[] hitEnemies = Physics.OverlapSphere(attackPoints[2].position, attackRanges[2], enemyLayers);
            foreach (Collider enemy in hitEnemies)
            {
                HealthManager p = GameObject.Find("HEALTHMANAGER").GetComponent<HealthManager>();
                KnockbackHandler kn = enemy.GetComponentInParent<KnockbackHandler>();
                kn.mainx = transform.position.x;
                kn.mainy = transform.position.y;
                kn.mainz = transform.position.z;
                if (enemy.gameObject.layer == LayerMask.NameToLayer("Team1"))
                {
                    kn.force = p.percen[0] / 2;
                    p.dam[0] = 2.4f;
                    p.hit[0] = true;
                    kn.hit1 = true;
                }
                if (enemy.gameObject.layer == LayerMask.NameToLayer("Team2"))
                {
                    kn.force = p.percen[1] / 2;
                    p.dam[1] = 2.4f;
                    p.hit[1] = true;
                    kn.hit2 = true;
                }
                if (enemy.gameObject.layer == LayerMask.NameToLayer("Team3"))
                {
                    kn.force = p.percen[2] / 2;
                    p.dam[2] = 2.4f;
                    p.hit[2] = true;
                    kn.hit3 = true;
                }
                if (enemy.gameObject.layer == LayerMask.NameToLayer("Team4"))
                {
                    kn.force = p.percen[3] / 2;
                    p.dam[3] = 2.4f;
                    p.hit[3] = true;
                    kn.hit4 = true;
                }
            }
            yield return new WaitForSeconds(0.3f);
            lcked = false;
            m.jlock = false;
            m.locked = false;
        }

        IEnumerator NeutralNormal()
        {
            ThirdPersonMovement m = dada.GetComponent<ThirdPersonMovement>();
            lcked = true;
            m.jlock = true;
            m.locked = true;
            m.gravAffect = false;
            ani.Animator.SetTrigger("NeutralNormal");
            Debug.Log("preforeach");
            yield return new WaitForSeconds(0.2f);
            Collider[] hitEnemies = Physics.OverlapSphere(attackPoints[0].position, attackRanges[0], enemyLayers);
            foreach (Collider enemy in hitEnemies)
            {
                Debug.Log("inforeach");
                HealthManager p = GameObject.Find("HEALTHMANAGER").GetComponent<HealthManager>();
                KnockbackHandler kn = enemy.GetComponentInParent<KnockbackHandler>();
                kn.mainx = transform.position.x;
                kn.mainy = transform.position.y;
                kn.mainz = transform.position.z;
                if (enemy.gameObject.layer == LayerMask.NameToLayer("Team1"))
                {
                    kn.force = p.percen[0] / 2;
                    p.dam[0] = 4f;
                    p.hit[0] = true;
                    kn.hit1 = true;
                }
                if (enemy.gameObject.layer == LayerMask.NameToLayer("Team2"))
                {
                    kn.force = p.percen[1] / 2;
                    p.dam[1] = 4f;
                    p.hit[1] = true;
                    kn.hit2 = true;
                }
                if (enemy.gameObject.layer == LayerMask.NameToLayer("Team3"))
                {
                    kn.force = p.percen[2] / 2;
                    p.dam[2] = 4f;
                    p.hit[2] = true;
                    kn.hit3 = true;
                }
                if (enemy.gameObject.layer == LayerMask.NameToLayer("Team4"))
                {
                    kn.force = p.percen[3] / 2;
                    p.dam[3] = 4f;
                    p.hit[3] = true;
                    kn.hit4 = true;
                }
                Debug.Log("postknock");
            }
            Debug.Log("postforeach");
            yield return new WaitForSeconds(0.6f);
            lcked = false;
            m.jlock = false;
            m.locked = false;
            m.gravAffect = true;
        }

        IEnumerator BackNormal()
        {
            ThirdPersonMovement m = dada.GetComponent<ThirdPersonMovement>();
            lcked = true;
            m.jlock = true;
            m.locked = true;
            ani.Animator.SetTrigger("BackNormal");
            yield return new WaitForSeconds(0.1f);
            Collider[] hitEnemies = Physics.OverlapSphere(attackPoints[1].position, attackRanges[1], enemyLayers);
            foreach (Collider enemy in hitEnemies)
            {
                HealthManager p = GameObject.Find("HEALTHMANAGER").GetComponent<HealthManager>();
                KnockbackHandler kn = enemy.GetComponentInParent<KnockbackHandler>();
                kn.mainx = transform.position.x;
                kn.mainy = transform.position.y;
                kn.mainz = transform.position.z;
                if (enemy.gameObject.layer == LayerMask.NameToLayer("Team1"))
                {
                    kn.force = p.percen[0] / 2;
                    p.dam[0] = 2.8f;
                    p.hit[0] = true;
                    kn.hit1 = true;
                }
                if (enemy.gameObject.layer == LayerMask.NameToLayer("Team2"))
                {
                    kn.force = p.percen[1] / 2;
                    p.dam[1] = 2.8f;
                    p.hit[1] = true;
                    kn.hit2 = true;
                }
                if (enemy.gameObject.layer == LayerMask.NameToLayer("Team3"))
                {
                    kn.force = p.percen[2] / 2;
                    p.dam[2] = 2.8f;
                    p.hit[2] = true;
                    kn.hit3 = true;
                }
                if (enemy.gameObject.layer == LayerMask.NameToLayer("Team4"))
                {
                    kn.force = p.percen[3] / 2;
                    p.dam[3] = 2.8f;
                    p.hit[3] = true;
                    kn.hit4 = true;
                }
            }
            yield return new WaitForSeconds(0.3f);
            lcked = false;
            m.jlock = false;
            m.locked = false;
        }

        IEnumerator DownNormal()
        {
            ThirdPersonMovement m = dada.GetComponent<ThirdPersonMovement>();
            lcked = true;
            m.jlock = true;
            m.locked = true;
            m.gravAffect = false;
            ani.Animator.SetBool("DownNormal", true);
            yield return new WaitForSeconds(0.1f);
            kadoosh = true;
            yield return new WaitForSeconds(0.3f);
            kadoosh = false;
            lcked = false;
            m.locked = false;
            m.jlock = false;
            m.gravAffect = true;
            ani.Animator.SetBool("DownNormal", false);
        }
        if (kadoosh)
        {
            Collider[] hitEnemies = Physics.OverlapBox(attackPoints[4].position, new Vector3(2.5f, 1, 2.5f), Quaternion.identity, enemyLayers);
            foreach (Collider enemy in hitEnemies)
            {
                HealthManager p = GameObject.Find("HEALTHMANAGER").GetComponent<HealthManager>();
                KnockbackHandler kn = enemy.GetComponentInParent<KnockbackHandler>();
                kn.mainx = transform.position.x;
                kn.mainy = transform.position.y;
                kn.mainz = transform.position.z;
                if (enemy.gameObject.layer == LayerMask.NameToLayer("Team1"))
                {
                    kn.force = p.percen[0] / 5;
                    p.dam[0] = 0.1f;
                    p.hit[0] = true;
                    kn.hit1 = true;
                }
                if (enemy.gameObject.layer == LayerMask.NameToLayer("Team2"))
                {
                    kn.force = p.percen[1] / 5;
                    p.dam[1] = 0.1f;
                    p.hit[1] = true;
                    kn.hit2 = true;
                }
                if (enemy.gameObject.layer == LayerMask.NameToLayer("Team3"))
                {
                    kn.force = p.percen[2] / 5;
                    p.dam[2] = 0.1f;
                    p.hit[2] = true;
                    kn.hit3 = true;
                }
                if (enemy.gameObject.layer == LayerMask.NameToLayer("Team4"))
                {
                    kn.force = p.percen[3] / 5;
                    p.dam[3] = 0.1f;
                    p.hit[3] = true;
                    kn.hit4 = true;
                }
            }
        }
        IEnumerator UpNormal()
        {
            ThirdPersonMovement m = dada.GetComponent<ThirdPersonMovement>();
            lcked = true;
            m.jlock = true;
            m.locked = true;
            if (m.controller.isGrounded == false)
            {
            m.verticalVelocity += 10;
            }
            ani.Animator.SetTrigger("UpNormal");
            yield return new WaitForSeconds(0.1f);
            Collider[] hitEnemies = Physics.OverlapSphere(attackPoints[5].position, attackRanges[5], enemyLayers);
            foreach (Collider enemy in hitEnemies)
            {
                HealthManager p = GameObject.Find("HEALTHMANAGER").GetComponent<HealthManager>();
                KnockbackHandler kn = enemy.GetComponentInParent<KnockbackHandler>();
                kn.mainx = transform.position.x;
                kn.mainy = transform.position.y;
                kn.mainz = transform.position.z;
                if (enemy.gameObject.layer == LayerMask.NameToLayer("Team1"))
                {
                    kn.force = p.percen[0] / 2;
                    p.dam[0] = 3.2f;
                    p.hit[0] = true;
                    kn.hit1 = true;
                }
                if (enemy.gameObject.layer == LayerMask.NameToLayer("Team2"))
                {
                    kn.force = p.percen[1] / 2;
                    p.dam[1] = 3.2f;
                    p.hit[1] = true;
                    kn.hit2 = true;
                }
                if (enemy.gameObject.layer == LayerMask.NameToLayer("Team3"))
                {
                    kn.force = p.percen[2] / 2;
                    p.dam[2] = 3.2f;
                    p.hit[2] = true;
                    kn.hit3 = true;
                }
                if (enemy.gameObject.layer == LayerMask.NameToLayer("Team4"))
                {
                    kn.force = p.percen[3] / 2;
                    p.dam[3] = 3.2f;
                    p.hit[3] = true;
                    kn.hit4 = true;
                }
            }
            yield return new WaitForSeconds(0.3f);
            lcked = false;
            m.locked = false;
            m.jlock = false;
            m.gravAffect = true;
        }
        IEnumerator ForwardNormal()
        {
            ThirdPersonMovement m = dada.GetComponent<ThirdPersonMovement>();
            lcked = true;
            m.jlock = true;
            m.locked = true;
            ani.Animator.SetTrigger("ForwardNormal");
            yield return new WaitForSeconds(0.1f);
            Collider[] hitEnemies = Physics.OverlapSphere(attackPoints[0].position, 1.5f, enemyLayers);
            foreach (Collider enemy in hitEnemies)
            {
                HealthManager p = GameObject.Find("HEALTHMANAGER").GetComponent<HealthManager>();
                KnockbackHandler kn = enemy.GetComponentInParent<KnockbackHandler>();
                kn.mainx = transform.position.x;
                kn.mainy = transform.position.y;
                kn.mainz = transform.position.z;
                if (enemy.gameObject.layer == LayerMask.NameToLayer("Team1"))
                {
                    kn.force = p.percen[0] / 2;
                    p.dam[0] = 1.7f;
                    p.hit[0] = true;
                    kn.hit1 = true;
                }
                if (enemy.gameObject.layer == LayerMask.NameToLayer("Team2"))
                {
                    kn.force = p.percen[1] / 2;
                    p.dam[1] = 1.7f;
                    p.hit[1] = true;
                    kn.hit2 = true;
                }
                if (enemy.gameObject.layer == LayerMask.NameToLayer("Team3"))
                {
                    kn.force = p.percen[2] / 2;
                    p.dam[2] = 1.7f;
                    p.hit[2] = true;
                    kn.hit3 = true;
                }
                if (enemy.gameObject.layer == LayerMask.NameToLayer("Team4"))
                {
                    kn.force = p.percen[3] / 2;
                    p.dam[3] = 1.7f;
                    p.hit[3] = true;
                    kn.hit4 = true;
                }
            }
            yield return new WaitForSeconds(0.2f);
            lcked = false;
            m.locked = false;
            m.jlock = false;
            m.gravAffect = true;
        }
    
    }
}
