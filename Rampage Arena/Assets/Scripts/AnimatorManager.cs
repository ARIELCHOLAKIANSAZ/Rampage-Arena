using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Alteruna;

public class AnimatorManager : AttributesSync
{
    public Animator ani;
    [SynchronizableField] public bool nn;
    [SynchronizableField] public bool ln;
    [SynchronizableField] public bool rn;
    [SynchronizableField] public bool bn;
    [SynchronizableField] public bool un;
    [SynchronizableField] public bool dn;
    [SynchronizableField] public bool fn;

    void Update()
    {
        if (nn)
        {
            ani.SetTrigger("NeutralNormal");
            nn = false;
        }
        if (ln)
        {
            ani.SetTrigger("LeftNormal");
            ln = false;
        }
        if (rn)
        {
            ani.SetTrigger("RightNormal");
            rn = false;
        }
        if (bn)
        {
            ani.SetTrigger("BackNormal");
            bn = false;
        }
        if (dn) ani.SetBool("DownNormal", true);
        else ani.SetBool("DownNormal", false);
        if (un)
        {
            ani.SetTrigger("UpNormal");
            un = false;
        }
        if (fn)
        {
            ani.SetTrigger("ForwardNormal");
            fn = false;
        }
    }
}
