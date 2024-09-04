using System.Collections;
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

    void Awake()
    {
        ava = GetComponent<Alteruna.Avatar>();
        if (!ava.IsMe) return;
        PlayerManager p = GameObject.Find("PLAYERMANAGER").GetComponent<PlayerManager>();
        int LayerTeam = 0;
        if (p.playerNumber == 1)
        {
            LayerTeam = LayerMask.NameToLayer("Team1");
        }
        else if (p.playerNumber == 2)
        {
            LayerTeam = LayerMask.NameToLayer("Team2");
        }
        else if (p.playerNumber == 3)
        {
            LayerTeam = LayerMask.NameToLayer("Team3");
        }
        else if (p.playerNumber == 4)
        {
            LayerTeam = LayerMask.NameToLayer("Team4");
        }
        gameObject.layer = LayerTeam;
        enemyLayers = -LayerTeam;
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
                HealthManager p = enemy.GetComponent<HealthManager>();
                p.percen += 2.4f;
                KnockbackHandler kn = enemy.GetComponentInParent<KnockbackHandler>();
                kn.mainx = transform.position.x;
                kn.mainy = transform.position.y;
                kn.mainz = transform.position.z;
                kn.force = p.percen/2;
                if(enemy.gameObject.layer == 9) kn.hit1 = true;
                if(enemy.gameObject.layer == 11) kn.hit2 = true;
                if(enemy.gameObject.layer == 12) kn.hit3 = true;
                if(enemy.gameObject.layer == 13) kn.hit4 = true;
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
                HealthManager p = enemy.GetComponent<HealthManager>();
                p.percen += 2.4f;
                KnockbackHandler kn = enemy.GetComponentInParent<KnockbackHandler>();
                kn.mainx = transform.position.x;
                kn.mainy = transform.position.y;
                kn.mainz = transform.position.z;
                kn.force = p.percen/2;
                if(enemy.gameObject.layer == 9) kn.hit1 = true;
                if(enemy.gameObject.layer == 11) kn.hit2 = true;
                if(enemy.gameObject.layer == 12) kn.hit3 = true;
                if(enemy.gameObject.layer == 13) kn.hit4 = true;
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
                HealthManager p = enemy.GetComponent<HealthManager>();
                p.percen += 4;
                KnockbackHandler kn = enemy.GetComponentInParent<KnockbackHandler>();
                kn.mainx = transform.position.x;
                kn.mainy = transform.position.y;
                kn.mainz = transform.position.z;
                kn.force = p.percen/2;
                if(enemy.gameObject.layer == 9) kn.hit1 = true;
                if(enemy.gameObject.layer == 11) kn.hit2 = true;
                if(enemy.gameObject.layer == 12) kn.hit3 = true;
                if(enemy.gameObject.layer == 13) kn.hit4 = true;
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
                HealthManager p = enemy.GetComponent<HealthManager>();
                p.percen += 2.8f;
                KnockbackHandler kn = enemy.GetComponentInParent<KnockbackHandler>();
                kn.mainx = transform.position.x;
                kn.mainy = transform.position.y;
                kn.mainz = transform.position.z;
                kn.force = p.percen/2;
                if(enemy.gameObject.layer == 9) kn.hit1 = true;
                if(enemy.gameObject.layer == 11) kn.hit2 = true;
                if(enemy.gameObject.layer == 12) kn.hit3 = true;
                if(enemy.gameObject.layer == 13) kn.hit4 = true;
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
                HealthManager p = enemy.GetComponent<HealthManager>();
                p.percen += 0.1f;
                Rigidbody rb = enemy.GetComponent<Rigidbody>();
                KnockbackHandler kn = enemy.GetComponentInParent<KnockbackHandler>();
                kn.mainx = transform.position.x;
                kn.mainy = transform.position.y;
                kn.mainz = transform.position.z;
                kn.force = p.percen/5;
                if(enemy.gameObject.layer == 9) kn.hit1 = true;
                if(enemy.gameObject.layer == 11) kn.hit2 = true;
                if(enemy.gameObject.layer == 12) kn.hit3 = true;
                if(enemy.gameObject.layer == 13) kn.hit4 = true;
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
            m.verticalVelocity += 8;
            }
            ani.Animator.SetTrigger("UpNormal");
            yield return new WaitForSeconds(0.1f);
            Collider[] hitEnemies = Physics.OverlapSphere(attackPoints[5].position, attackRanges[5], enemyLayers);
            foreach (Collider enemy in hitEnemies)
            {
                HealthManager p = enemy.GetComponent<HealthManager>();
                p.percen += 3.2f;
                KnockbackHandler kn = enemy.GetComponentInParent<KnockbackHandler>();
                kn.mainx = transform.position.x;
                kn.mainy = transform.position.y;
                kn.mainz = transform.position.z;
                kn.force = p.percen/2;
                if(enemy.gameObject.layer == 9) kn.hit1 = true;
                if(enemy.gameObject.layer == 11) kn.hit2 = true;
                if(enemy.gameObject.layer == 12) kn.hit3 = true;
                if(enemy.gameObject.layer == 13) kn.hit4 = true;
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
                HealthManager p = enemy.GetComponentInParent<HealthManager>();
                p.percen += 1.7f;
                KnockbackHandler kn = enemy.GetComponentInParent<KnockbackHandler>();
                kn.mainx = transform.position.x;
                kn.mainy = transform.position.y;
                kn.mainz = transform.position.z;
                kn.force = p.percen/2;
                if(enemy.gameObject.layer == 9) kn.hit1 = true;
                if(enemy.gameObject.layer == 11) kn.hit2 = true;
                if(enemy.gameObject.layer == 12) kn.hit3 = true;
                if(enemy.gameObject.layer == 13) kn.hit4 = true;
            }
            yield return new WaitForSeconds(0.2f);
            lcked = false;
            m.locked = false;
            m.jlock = false;
            m.gravAffect = true;
        }
    
    }
}
