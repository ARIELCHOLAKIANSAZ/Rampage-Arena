using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Alteruna;
using JetBrains.Annotations;

public class AttacksManager : AttributesSync
{
    public CharacterController con;
    public AnimatorManager ani;
    public GameObject dada;
    public bool lcked = false;
    public Transform[] attackPoints;
    public float[] attackRanges;
    public LayerMask enemyLayers;
    bool kadoosh = false;
    private Alteruna.Avatar ava;
    bool upspecial1 = false;
    bool upspecial2 = false;
    bool forSpec = false;
    ThirdPersonMovement tpm;
    [SynchronizableField] bool frosp1 = false;
    [SynchronizableField] bool frosp2 = false;
    [SynchronizableField] bool frosp3 = false;
    [SynchronizableField] bool frosp4 = false;
    [SynchronizableField] float frox;
    [SynchronizableField] float froy;
    [SynchronizableField] float froz;
    PlayerManager p;
    bool weakfall = false;
    bool downsp = false;
    bool bodyhit = false;
    bool bodyhit2 = false;


    void Start()
    {
        ani = GetComponent<AnimatorManager>();
        ava = GetComponent<Alteruna.Avatar>();
        if (!ava.IsMe) return;
        p = GetComponent<PlayerManager>();
    }
    void Update()
    {
        if (!ava.IsMe) return;

        if (Input.GetKey(KeyCode.LeftShift) && lcked == false)
        {
            if (Input.GetMouseButtonDown(1))
            {
                StartCoroutine(UpSpecial());
            }
            if (Input.GetMouseButtonDown(0))
            {
                StartCoroutine(UpNormal());
            }

        }
        else if (Input.GetKey(KeyCode.LeftControl) && lcked == false)
        {
            if (Input.GetMouseButtonDown(1))
            {
                StartCoroutine(DownSpecial());
            }
            if (Input.GetMouseButtonDown(0))
            {
                StartCoroutine(DownNormal());
            }
        }
        else if (Input.GetKey(KeyCode.W) && lcked == false)
        {
            if (Input.GetMouseButtonDown(1))
            {
                StartCoroutine(ForwardSpecial());
            }
            if (Input.GetMouseButtonDown(0))
            {
                StartCoroutine(ForwardNormal());
            }
        }
        else if (Input.GetKey(KeyCode.A) && lcked == false)
        {
            if (Input.GetMouseButtonDown(1))
            {
                StartCoroutine(LeftSpecial());
            }
            if (Input.GetMouseButtonDown(0))
            {
                StartCoroutine(LeftNormal());
            }

        }
        else if (Input.GetKey(KeyCode.D) && lcked == false)
        {
            if (Input.GetMouseButtonDown(1))
            {
                StartCoroutine(RightSpecial());
            }
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
                    kn.force = p.percen1 / 5;
                    p.dam1 = 0.1f;
                    p.hit1 = true;
                    kn.hit1 = true;
                }
                if (enemy.gameObject.layer == LayerMask.NameToLayer("Team2"))
                {
                    kn.force = p.percen2 / 5;
                    p.dam2 = 0.1f;
                    p.hit2 = true;
                    kn.hit2 = true;
                }
                if (enemy.gameObject.layer == LayerMask.NameToLayer("Team3"))
                {
                    kn.force = p.percen3 / 5;
                    p.dam3 = 0.1f;
                    p.hit3 = true;
                    kn.hit3 = true;
                }
                if (enemy.gameObject.layer == LayerMask.NameToLayer("Team4"))
                {
                    kn.force = p.percen4 / 5;
                    p.dam4 = 0.1f;
                    p.hit4 = true;
                    kn.hit4 = true;
                }
            }
        }

        if (downsp)
        {
            Collider[] hitEnemies = Physics.OverlapBox(attackPoints[4].position, new Vector3(3f, 2, 3f), Quaternion.identity, enemyLayers);
            foreach (Collider enemy in hitEnemies)
            {
                HealthManager p = GameObject.Find("HEALTHMANAGER").GetComponent<HealthManager>();
                KnockbackHandler kn = enemy.GetComponentInParent<KnockbackHandler>();
                kn.mainx = transform.position.x;
                kn.mainy = transform.position.y;
                kn.mainz = transform.position.z;
                if (enemy.gameObject.layer == LayerMask.NameToLayer("Team1"))
                {
                    kn.force = p.percen1 / 4;
                    p.dam1 = 0.5f;
                    p.hit1 = true;
                    kn.hit1 = true;
                }
                if (enemy.gameObject.layer == LayerMask.NameToLayer("Team2"))
                {
                    kn.force = p.percen2 / 4;
                    p.dam2 = 0.5f;
                    p.hit2 = true;
                    kn.hit2 = true;
                }
                if (enemy.gameObject.layer == LayerMask.NameToLayer("Team3"))
                {
                    kn.force = p.percen3 / 4;
                    p.dam3 = 0.5f;
                    p.hit3 = true;
                    kn.hit3 = true;
                }
                if (enemy.gameObject.layer == LayerMask.NameToLayer("Team4"))
                {
                    kn.force = p.percen4 / 4;
                    p.dam4 = 0.5f;
                    p.hit4 = true;
                    kn.hit4 = true;
                }
            }
        }
        if (upspecial1)
        {
            if (-3f < tpm.verticalVelocity && tpm.verticalVelocity < 3f)
            {
                ani.usS = false;
                ani.usF = true;
                upspecial1 = false;
                upspecial2 = true;
            }
        }
        if (upspecial2)
        {
            Collider[] hitEnemies = Physics.OverlapSphere(attackPoints[6].position, attackRanges[6], enemyLayers);
            foreach (Collider enemy in hitEnemies)
            {
                HealthManager p = GameObject.Find("HEALTHMANAGER").GetComponent<HealthManager>();
                KnockbackHandler kn = enemy.GetComponentInParent<KnockbackHandler>();
                kn.mainx = transform.position.x;
                kn.mainy = transform.position.y;
                kn.mainz = transform.position.z;
                if (enemy.gameObject.layer == LayerMask.NameToLayer("Team1"))
                {
                    kn.force = p.percen1;
                    p.dam1 = 1.4f;
                    p.hit1 = true;
                    kn.hit1 = true;
                }
                if (enemy.gameObject.layer == LayerMask.NameToLayer("Team2"))
                {
                    kn.force = p.percen2;
                    p.dam2 = 1.4f;
                    p.hit2 = true;
                    kn.hit2 = true;
                }
                if (enemy.gameObject.layer == LayerMask.NameToLayer("Team3"))
                {
                    kn.force = p.percen3;
                    p.dam3 = 1.4f;
                    p.hit3 = true;
                    kn.hit3 = true;
                }
                if (enemy.gameObject.layer == LayerMask.NameToLayer("Team4"))
                {
                    kn.force = p.percen4;
                    p.dam4 = 1.4f;
                    p.hit4 = true;
                    kn.hit4 = true;
                }
            }
            if (tpm.ground)
            {
                upspecial2 = false;
                lcked = false;
                tpm.jlock = false;
            }
        }
        if (forSpec)
        {
            tpm.controller.Move(transform.TransformDirection(Vector3.forward) * 8 * Time.deltaTime);
            Collider[] hitEnemies = Physics.OverlapSphere(attackPoints[0].position, attackRanges[6], enemyLayers);
            foreach (Collider enemy in hitEnemies)
            {
                HealthManager p = GameObject.Find("HEALTHMANAGER").GetComponent<HealthManager>();
                KnockbackHandler kn = enemy.GetComponentInParent<KnockbackHandler>();
                AttacksManager am = enemy.GetComponentInParent<AttacksManager>();
                kn.mainx = transform.position.x;
                kn.mainy = transform.position.y;
                kn.mainz = transform.position.z;
                am.frox = attackPoints[0].transform.position.x;
                am.froy = attackPoints[0].transform.position.y;
                am.froz = attackPoints[0].transform.position.z;
                if (enemy.gameObject.layer == LayerMask.NameToLayer("Team1"))
                {
                    frosp1 = true;
                    kn.force = 0;
                    p.dam1 = 0.2f;
                    p.hit1 = true;
                    kn.hit1 = true;
                }
                if (enemy.gameObject.layer == LayerMask.NameToLayer("Team2"))
                {
                    frosp2 = true;
                    kn.force = 0;
                    p.dam2 = 0.2f;
                    p.hit2 = true;
                    kn.hit2 = true;
                }
                if (enemy.gameObject.layer == LayerMask.NameToLayer("Team3"))
                {
                    frosp3 = true;
                    kn.force = 0;
                    p.dam3 = 0.2f;
                    p.hit3 = true;
                    kn.hit3 = true;
                }
                if (enemy.gameObject.layer == LayerMask.NameToLayer("Team4"))
                {
                    frosp4 = true;
                    kn.force = 0;
                    p.dam4 = 0.2f;
                    p.hit4 = true;
                    kn.hit4 = true;
                }
            }
        }
        if (frosp1 && p.playerNumber == 1) gameObject.transform.position = new Vector3(frox, froy, froz);
        if (frosp2 && p.playerNumber == 2) gameObject.transform.position = new Vector3(frox, froy, froz);
        if (frosp3 && p.playerNumber == 3) gameObject.transform.position = new Vector3(frox, froy, froz);
        if (frosp4 && p.playerNumber == 4) gameObject.transform.position = new Vector3(frox, froy, froz);

        if (weakfall)
        {
            if (tpm.controller.isGrounded)
            {
                lcked = false;
                tpm.jlock = false;
                weakfall = false;
                ani.vulfall = false;
            }
            else
            {
            ani.
                vulfall = true;
            }
        }
        if (bodyhit)
        {
            tpm.controller.Move(transform.TransformDirection(Vector3.right) * 25  * Time.deltaTime);
            Collider[] hitEnemies = Physics.OverlapSphere(this.gameObject.transform.position, 2.5f, enemyLayers);
            foreach (Collider enemy in hitEnemies)
            {
                HealthManager p = GameObject.Find("HEALTHMANAGER").GetComponent<HealthManager>();
                KnockbackHandler kn = enemy.GetComponentInParent<KnockbackHandler>();
                kn.mainx = transform.position.x;
                kn.mainy = transform.position.y;
                kn.mainz = transform.position.z;
                if (enemy.gameObject.layer == LayerMask.NameToLayer("Team 1"))
                {
                    kn.force = p.percen1;
                    p.dam1 = 0.3f;
                    p.hit1 = true;
                    kn.hit1 = true;
                }
                if (enemy.gameObject.layer == 11)
                {
                    kn.force = p.percen2;
                    p.dam2 = 0.3f;
                    p.hit2 = true;
                    kn.hit2 = true;
                }
                if (enemy.gameObject.layer == 12)
                {
                    kn.force = p.percen3;
                    p.dam3 = 0.3f;
                    p.hit3 = true;
                    kn.hit3 = true;
                }
                if (enemy.gameObject.layer == 13)
                {
                    kn.force = p.percen4;
                    p.dam4 = 0.3f;
                    p.hit4 = true;
                    kn.hit4 = true;
                }
            }
        }
        if (bodyhit2)
        {
            tpm.controller.Move(transform.TransformDirection(Vector3.left) * 25  * Time.deltaTime);
            Collider[] hitEnemies = Physics.OverlapSphere(this.gameObject.transform.position, 2.5f, enemyLayers);
            foreach (Collider enemy in hitEnemies)
            {
                HealthManager p = GameObject.Find("HEALTHMANAGER").GetComponent<HealthManager>();
                KnockbackHandler kn = enemy.GetComponentInParent<KnockbackHandler>();
                kn.mainx = transform.position.x;
                kn.mainy = transform.position.y;
                kn.mainz = transform.position.z;
                if (enemy.gameObject.layer == LayerMask.NameToLayer("Team 1"))
                {
                    kn.force = p.percen1;
                    p.dam1 = 0.3f;
                    p.hit1 = true;
                    kn.hit1 = true;
                }
                if (enemy.gameObject.layer == 11)
                {
                    kn.force = p.percen2;
                    p.dam2 = 0.3f;
                    p.hit2 = true;
                    kn.hit2 = true;
                }
                if (enemy.gameObject.layer == 12)
                {
                    kn.force = p.percen3;
                    p.dam3 = 0.3f;
                    p.hit3 = true;
                    kn.hit3 = true;
                }
                if (enemy.gameObject.layer == 13)
                {
                    kn.force = p.percen4;
                    p.dam4 = 0.3f;
                    p.hit4 = true;
                    kn.hit4 = true;
                }
            }
        }
    }
        IEnumerator LeftNormal()
        {
            ThirdPersonMovement m = dada.GetComponent<ThirdPersonMovement>();
            lcked = true;
            m.locked = true;
            m.jlock = true;
            ani.ln = true;
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
                    kn.force = p.percen1/2;
                    p.dam1 = 2.4f;
                    p.hit1 = true;
                    kn.hit1 = true;
                } 
                if(enemy.gameObject.layer == 11)
                {
                    kn.force = p.percen2/2;
                    p.dam2 = 2.4f;
                    p.hit2 = true;
                    kn.hit2 = true;
                }
                if(enemy.gameObject.layer == 12) 
                {
                    kn.force = p.percen3/2;
                    p.dam3 = 2.4f;
                    p.hit3 = true;
                    kn.hit3 = true;
                }
                if(enemy.gameObject.layer == 13)
                {
                    kn.force = p.percen4/2;
                    p.dam4 = 2.4f;
                    p.hit4 = true;
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
            ani.rn = true;
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
                    kn.force = p.percen1 / 2;
                    p.dam1 = 2.4f;
                    p.hit1 = true;
                    kn.hit1 = true;
                }
                if (enemy.gameObject.layer == LayerMask.NameToLayer("Team2"))
                {
                    kn.force = p.percen2 / 2;
                    p.dam2 = 2.4f;
                    p.hit2 = true;
                    kn.hit2 = true;
                }
                if (enemy.gameObject.layer == LayerMask.NameToLayer("Team3"))
                {
                    kn.force = p.percen3 / 2;
                    p.dam3 = 2.4f;
                    p.hit3 = true;
                    kn.hit3 = true;
                }
                if (enemy.gameObject.layer == LayerMask.NameToLayer("Team4"))
                {
                    kn.force = p.percen4 / 2;
                    p.dam4 = 2.4f;
                    p.hit4 = true;
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
            ani.nn = true;
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
                    kn.force = p.percen1 / 2;
                    p.dam1 = 4f;
                    p.hit1 = true;
                    kn.hit1 = true;
                }
                if (enemy.gameObject.layer == LayerMask.NameToLayer("Team2"))
                {
                    kn.force = p.percen2 / 2;
                    p.dam2 = 4f;
                    p.hit2 = true;
                    kn.hit2 = true;
                }
                if (enemy.gameObject.layer == LayerMask.NameToLayer("Team3"))
                {
                    kn.force = p.percen3 / 2;
                    p.dam3 = 4f;
                    p.hit3 = true;
                    kn.hit3 = true;
                }
                if (enemy.gameObject.layer == LayerMask.NameToLayer("Team4"))
                {
                    kn.force = p.percen4 / 2;
                    p.dam4 = 4f;
                    p.hit4 = true;
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
            ani.bn = true;
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
                    kn.force = p.percen1 / 2;
                    p.dam1 = 2.8f;
                    p.hit1 = true;
                    kn.hit1 = true;
                }
                if (enemy.gameObject.layer == LayerMask.NameToLayer("Team2"))
                {
                    kn.force = p.percen2 / 2;
                    p.dam2 = 2.8f;
                    p.hit2 = true;
                    kn.hit2 = true;
                }
                if (enemy.gameObject.layer == LayerMask.NameToLayer("Team3"))
                {
                    kn.force = p.percen3 / 2;
                    p.dam3 = 2.8f;
                    p.hit3 = true;
                    kn.hit3 = true;
                }
                if (enemy.gameObject.layer == LayerMask.NameToLayer("Team4"))
                {
                    kn.force = p.percen4 / 2;
                    p.dam4 = 2.8f;
                    p.hit4 = true;
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
            ani.dn = true;
            yield return new WaitForSeconds(0.1f);
            kadoosh = true;
            yield return new WaitForSeconds(0.3f);
            kadoosh = false;
            lcked = false;
            m.locked = false;
            m.jlock = false;
            m.gravAffect = true;
            ani.dn = false;
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
            ani.un = true;
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
                    kn.force = p.percen1 / 2;
                    p.dam1 = 3.2f;
                    p.hit1 = true;
                    kn.hit1 = true;
                }
                if (enemy.gameObject.layer == LayerMask.NameToLayer("Team2"))
                {
                    kn.force = p.percen2 / 2;
                    p.dam2 = 3.2f;
                    p.hit2 = true;
                    kn.hit2 = true;
                }
                if (enemy.gameObject.layer == LayerMask.NameToLayer("Team3"))
                {
                    kn.force = p.percen3 / 2;
                    p.dam3 = 3.2f;
                    p.hit3 = true;
                    kn.hit3 = true;
                }
                if (enemy.gameObject.layer == LayerMask.NameToLayer("Team4"))
                {
                    kn.force = p.percen4 / 2;
                    p.dam4 = 3.2f;
                    p.hit4 = true;
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
            ani.fn = true;
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
                    kn.force = p.percen1 / 2;
                    p.dam1 = 1.7f;
                    p.hit1 = true;
                    kn.hit1 = true;
                }
                if (enemy.gameObject.layer == LayerMask.NameToLayer("Team2"))
                {
                    kn.force = p.percen2 / 2;
                    p.dam2 = 1.7f;
                    p.hit2 = true;
                    kn.hit2 = true;
                }
                if (enemy.gameObject.layer == LayerMask.NameToLayer("Team3"))
                {
                    kn.force = p.percen3 / 2;
                    p.dam3 = 1.7f;
                    p.hit3 = true;
                    kn.hit3 = true;
                }
                if (enemy.gameObject.layer == LayerMask.NameToLayer("Team4"))
                {
                    kn.force = p.percen4 / 2;
                    p.dam4 = 1.7f;
                    p.hit4 = true;
                    kn.hit4 = true;
                }
            }
            yield return new WaitForSeconds(0.2f);
            lcked = false;
            m.locked = false;
            m.jlock = false;
            m.gravAffect = true;
        }
        IEnumerator UpSpecial()
        {
            tpm = dada.GetComponent<ThirdPersonMovement>();
            lcked = true;
            tpm.jlock = true;
            ani.usS = true;
            yield return new WaitForSeconds(0.2f);
        tpm.verticalVelocity = 25;
        upspecial1 = true;
        }
    IEnumerator ForwardSpecial()
    {
        tpm = dada.GetComponent<ThirdPersonMovement>();
        lcked = true;
        tpm.jlock = true;
        tpm.locked = true;
        tpm.gravAffect = false;
        forSpec = true;
        ani.fs = true;
        yield return new WaitForSeconds(0.8f);
        ani.fs = false;
        yield return new WaitForSeconds(0.05f);
        forSpec = false;
        yield return new WaitForSeconds(0.05f);
        frosp1 = false;
        frosp2 = false;
        frosp3 = false;
        frosp4 = false;
        yield return new WaitForSeconds(0.1f);
        Collider[] hitEnemies = Physics.OverlapSphere(attackPoints[0].position, attackRanges[7], enemyLayers);
        foreach (Collider enemy in hitEnemies)
        {
            HealthManager p = GameObject.Find("HEALTHMANAGER").GetComponent<HealthManager>();
            KnockbackHandler kn = enemy.GetComponentInParent<KnockbackHandler>();
            kn.mainx = transform.position.x;
            kn.mainy = transform.position.y;
            kn.mainz = transform.position.z;
            if (enemy.gameObject.layer == LayerMask.NameToLayer("Team1"))
            {
                p.dam1 = 7.2f;
                kn.force = p.percen1;
                p.hit1 = true;
                kn.hit1 = true;
            }
            if (enemy.gameObject.layer == LayerMask.NameToLayer("Team2"))
            {
                p.dam2 = 7.2f;
                kn.force = p.percen2;
                p.hit2 = true;
                kn.hit2 = true;
            }
            if (enemy.gameObject.layer == LayerMask.NameToLayer("Team3"))
            {
                p.dam3 = 7.2f;
                kn.force = p.percen3;
                p.hit3 = true;
                kn.hit3 = true;
            }
            if (enemy.gameObject.layer == LayerMask.NameToLayer("Team4"))
            {
                p.dam4 = 7.2f;
                kn.force = p.percen4;
                p.hit4 = true;
                kn.hit4 = true;
            }
        }
        tpm.locked = false;
        tpm.gravAffect = true;
        weakfall = true;
    }
    IEnumerator DownSpecial()
    {
        tpm = dada.GetComponent<ThirdPersonMovement>();
        lcked = true;
        tpm.jlock = true;
        ani.ds = true;
        tpm.speed /=  2;
        tpm.grav /=  2;
        downsp = true;
        yield return new WaitForSeconds(0.8f);
        downsp = false;
        tpm.speed *= 2;
        tpm.grav *= 2;
        tpm.jlock = false;
        lcked = false;
    }
    IEnumerator RightSpecial()
    {
        tpm = dada.GetComponent<ThirdPersonMovement>();
        lcked = true;
        tpm.jlock = true;
        tpm.locked = true;
        tpm.grav /= 2;
        ani.rs = true;
        yield return new WaitForSeconds(0.2f);
        bodyhit = true;
        ani.rs = false;
        yield return new WaitForSeconds(0.3f);
        bodyhit = false;
        yield return new WaitForSeconds(.3f);
        tpm.grav *= 2;
        lcked = false;
        tpm.jlock = false;
        tpm.locked = false;
    }
    IEnumerator LeftSpecial()
    {
        tpm = dada.GetComponent<ThirdPersonMovement>();
        lcked = true;
        tpm.jlock = true;
        tpm.locked = true;
        tpm.grav /= 2;
        ani.ls = true;
        yield return new WaitForSeconds(0.2f);
        bodyhit2 = true;
        ani.ls = false;
        yield return new WaitForSeconds(0.3f);
        bodyhit2 = false;
        yield return new WaitForSeconds(.3f);
        tpm.grav *= 2;
        lcked = false;
        tpm.jlock = false;
        tpm.locked = false;
    }
}
