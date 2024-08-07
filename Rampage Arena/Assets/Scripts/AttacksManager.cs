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

    void Start()
    {

    }

    void Update()
    {
        if (Input.GetKey(KeyCode.W) && lcked == false)
        {
            
            Debug.Log("Click");
            if (Input.GetMouseButtonDown(0))
            {
                 StartCoroutine(ForwardNormal());                
            }
            
        }
    }

    IEnumerator ForwardNormal()
    {
        
        ThirdPersonMovement m = dada.GetComponent<ThirdPersonMovement>();
        lcked = true;
        m.locked = true;
        ani.SetTrigger("ForwardNormal");
        Debug.Log("yit");
        Collider[] hitEnemies = Physics.OverlapSphere(attackPoints[0].position, attackRanges[0], enemyLayers);
        yield return new WaitForSeconds(0.2f);
        foreach(Collider enemy in hitEnemies)
        {
            Debug.Log("hitemm");
        }
        yield return new WaitForSeconds(0.6f);
        Debug.Log("yot");
        lcked = false;
        m.locked = false;
    }
}
