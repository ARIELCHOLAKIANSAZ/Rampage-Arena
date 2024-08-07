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
    float kadoosh = 0;


    void Update()
    {
        if (Input.GetKey(KeyCode.W) && lcked == false)
        {
            if (Input.GetMouseButtonDown(0))
            {
                 StartCoroutine(ForwardNormal());                
            }

        }
        if (Input.GetKey(KeyCode.S) && lcked == false)
        {
            if (Input.GetMouseButtonDown(0))
            {
                StartCoroutine(ForwardNormal());
            }

        }
    }

    IEnumerator BackNormal()
    {
        ThirdPersonMovement m = dada.GetComponent<ThirdPersonMovement>();
        lcked = true;
        m.locked = true;
        m.gravAffect = false;
        ani.SetTrigger("ForwardNormal");
        Collider[] hitEnemies = Physics.OverlapSphere(attackPoints[0].position, attackRanges[0], enemyLayers);
        yield return new WaitForSeconds(0.2f);
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

    IEnumerator ForwardNormal()
    {
        ThirdPersonMovement m = dada.GetComponent<ThirdPersonMovement>();
        lcked = true;
        m.locked = true;
        m.gravAffect = false;
        ani.SetTrigger("ForwardNormal");
        Collider[] hitEnemies = Physics.OverlapSphere(attackPoints[0].position, attackRanges[0], enemyLayers);
        yield return new WaitForSeconds(0.2f);
        foreach(Collider enemy in hitEnemies)
        {
            HealthManager p = enemy.GetComponent<HealthManager>();
            p.percen += 4;
        }
        yield return new WaitForSeconds(0.6f);
        lcked = false;
        m.locked = false;
        m.gravAffect = true;
    }
}
