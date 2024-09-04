using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Alteruna;

public class HealthManager : AttributesSync
{
    [SynchronizableField] public float percen = 0;
    float percenLast = 0;
    public PercentageDisplayManager display;
    public int guy;

}
