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
        if (Input.GetKey(KeyCode.W) && lcked == false)
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
        else if (Input.GetKey(KeyCode.LeftShift) && lcked == false)
        {
            if (Input.GetMouseButtonDown(0))
            {
                StartCoroutine(RightNormal());
            }

        }
        else if (Input.GetKey(KeyCode.LeftControl) && lcked == false)
        {
            if (Input.GetMouseButtonDown(0))
            {
                StartCoroutine(DownNormal());
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
            m.gravAffect = false;
            ani.SetTrigger("LeftNormal");
            yield return new WaitForSeconds(0.1f);
            Collider[] hitEnemies = Physics.OverlapSphere(attackPoints[3].position, attackRanges[3], enemyLayers);
            foreach (Collider enemy in hitEnemies)
            {
                HealthManager p = enemy.GetComponent<HealthManager>();
                p.percen += 2.4f;
            }
            yield return new WaitForSeconds(0.3f);
            lcked = false;
            m.locked = false;
            m.gravAffect = true;
        }

        IEnumerator RightNormal()
        {
            ThirdPersonMovement m = dada.GetComponent<ThirdPersonMovement>();
            lcked = true;
            m.locked = true;
            m.gravAffect = false;
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
            m.locked = false;
            m.gravAffect = true;
        }

        IEnumerator NeutralNormal()
        {
            ThirdPersonMovement m = dada.GetComponent<ThirdPersonMovement>();
            lcked = true;
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
            m.locked = false;
            m.gravAffect = true;
        }

        IEnumerator BackNormal()
        {
            ThirdPersonMovement m = dada.GetComponent<ThirdPersonMovement>();
            lcked = true;
            m.locked = true;
            m.gravAffect = false;
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
            m.locked = false;
            m.gravAffect = true;
        }

        IEnumerator DownNormal()
        {
            ThirdPersonMovement m = dada.GetComponent<ThirdPersonMovement>();
            lcked = true;
            m.locked = true;
            m.gravAffect = false;
            ani.SetTrigger("DownNormal");
            yield return new WaitForSeconds(0.1f);
            kadoosh = true;
            yield return new WaitForSeconds(0.3f);
            kadoosh = false;
            lcked = false;
            m.locked = false;
            m.gravAffect = true;
        }
        if (kadoosh)
        {
            Collider[] hitEnemies = Physics.OverlapBox(attackPoints[4].position, new Vector3(3, 1, 3), Quaternion.identity, enemyLayers);
            foreach (Collider enemy in hitEnemies)
            {
                HealthManager p = enemy.GetComponent<HealthManager>();
                p.percen += 0.1f;
            }
        }
    }
    
}
