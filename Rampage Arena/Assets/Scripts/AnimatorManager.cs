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
    [SynchronizableField] public bool usS;
    [SynchronizableField] public bool usF;
    [SynchronizableField] public bool fs;

    void Update()
    {
        if (fs) ani.SetBool("ForwardSpecial", true);
        else ani.SetBool("ForwardSpecial", false);
        if (usS)
        {
            ani.SetBool("UpSpecialStart", true);
            usS = false;
        }
        else ani.SetBool("UpSpecialStart", false);
        if (usF)
        {
            ani.SetBool("UpSpecialFall", true);
            usF = false;
        }
        else ani.SetBool("UpSpecialFall", false);
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
