using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PercentageDisplayManager : MonoBehaviour
{
    public Text[] percenDisplay;

    public void PercenUpdate(float Percentage, int num)
    {
        percenDisplay[num].text = Percentage.ToString() + "%";
    }

}
