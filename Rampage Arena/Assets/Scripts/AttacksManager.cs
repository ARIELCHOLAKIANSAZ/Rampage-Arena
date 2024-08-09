using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AttacksManager : MonoBehaviour
{
    public CharacterController con;
    public Animator ani;
    public GameObject dada;
    public bool lcked = false;
    public Transform[] attackPoints;
    public float[] attackRanges;
    public LayerMask enemyLayers;
    bool kadoosh = false;


    void Update()
    {
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
                StartCoroutine(NeutralNormal());
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
            ani.SetTrigger("LeftNormal");
            yield return new WaitForSeconds(0.1f);
            Collider[] hitEnemies = Physics.OverlapSphere(attackPoints[3].position, attackRanges[3], enemyLayers);
            foreach (Collider enemy in hitEnemies)
            {
                HealthManager p = enemy.GetComponent<HealthManager>();
                p.percen += 2.4f;
            }
            yield return new WaitForSeconds(0.3f);
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
            ani.SetTrigger("RightNormal");
            yield return new WaitForSeconds(0.1f);
            Collider[] hitEnemies = Physics.OverlapSphere(attackPoints[2].position, attackRanges[2], enemyLayers);
            foreach (Collider enemy in hitEnemies)
            {
                HealthManager p = enemy.GetComponent<HealthManager>();
                p.percen += 2.4f;
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
            ani.SetTrigger("NeutralNormal");
            yield return new WaitForSeconds(0.2f);
            Collider[] hitEnemies = Physics.OverlapSphere(attackPoints[0].position, attackRanges[0], enemyLayers);
            foreach (Collider enemy in hitEnemies)
            {
                HealthManager p = enemy.GetComponent<HealthManager>();
                p.percen += 4;
            }
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
            ani.SetTrigger("BackNormal");
            yield return new WaitForSeconds(0.1f);
            Collider[] hitEnemies = Physics.OverlapSphere(attackPoints[1].position, attackRanges[1], enemyLayers);
            foreach (Collider enemy in hitEnemies)
            {
                HealthManager p = enemy.GetComponent<HealthManager>();
                p.percen += 2.8f;
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
            ani.SetBool("DownNormal", true);
            yield return new WaitForSeconds(0.1f);
            kadoosh = true;
            yield return new WaitForSeconds(0.3f);
            kadoosh = false;
            lcked = false;
            m.locked = false;
            m.jlock = false;
            m.gravAffect = true;
            ani.SetBool("DownNormal", false);
        }
        if (kadoosh)
        {
            Collider[] hitEnemies = Physics.OverlapBox(attackPoints[4].position, new Vector3(2.5f, 1, 2.5f), Quaternion.identity, enemyLayers);
            foreach (Collider enemy in hitEnemies)
            {
                HealthManager p = enemy.GetComponent<HealthManager>();
                p.percen += 0.1f;
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
            ani.SetTrigger("UpNormal");
            yield return new WaitForSeconds(0.1f);
            Collider[] hitEnemies = Physics.OverlapSphere(attackPoints[5].position, attackRanges[5], enemyLayers);
            foreach (Collider enemy in hitEnemies)
            {
                HealthManager p = enemy.GetComponent<HealthManager>();
                p.percen += 3.2f;
            }
            yield return new WaitForSeconds(0.3f);
            lcked = false;
            m.locked = false;
            m.jlock = false;
            m.gravAffect = true;
        }
    }
    
}
