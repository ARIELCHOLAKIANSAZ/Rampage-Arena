using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthManager : MonoBehaviour
{
    public float percen = 0;
    float percenLast = 0;
    public PercentageDisplayManager display;
    public int guy;

    void Update()
    {
        if (percenLast != percen)
        {
            display.PercenUpdate(percen, guy);
        }
    }
}
