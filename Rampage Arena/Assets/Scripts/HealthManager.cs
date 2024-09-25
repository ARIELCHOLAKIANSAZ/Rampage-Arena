using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Alteruna;
using UnityEngine.UI;

public class HealthManager : AttributesSync
{
    [SynchronizableField] public float percen1 = 0;
    [SynchronizableField] public float percen2 = 0;
    [SynchronizableField] public float percen3 = 0;
    [SynchronizableField] public float percen4 = 0;
    [SynchronizableField] public bool hit1 = false;
    [SynchronizableField] public bool hit2 = false;
    [SynchronizableField] public bool hit3 = false;
    [SynchronizableField] public bool hit4 = false;
    [SynchronizableField] public float dam1 = 0;
    [SynchronizableField] public float dam2 = 0;
    [SynchronizableField] public float dam3 = 0;
    [SynchronizableField] public float dam4 = 0;
    public Text[] displayText;
    public GameObject[] display;
    float percenLast = 0;
    public int guy;
    PlayerManager pm;

    void Start()
    {
        pm = GameObject.Find("PLAYERMANAGER").GetComponent<PlayerManager>();
        if (pm.activePlayerList[0] == false) display[0].SetActive(false);
        if (pm.activePlayerList[1] == false) display[1].SetActive(false);
        if (pm.activePlayerList[2] == false) display[2].SetActive(false);
        if (pm.activePlayerList[3] == false) display[3].SetActive(false);
    }
    void Update()
    {
        if (hit1)
        {
            percen1 += dam1;
            hit1 = false;
        }
        if (hit2)
        {
            percen2 += dam2;
            hit2 = false;
        }
        if (hit3)
        {
            percen3 += dam3;
            hit3 = false;
        }
        if (hit4)
        {
            percen4 += dam4;
            hit4 = false;
        }
        if (pm.activePlayerList[0] == true) displayText[0].text = percen1.ToString();
        if (pm.activePlayerList[1] == true) displayText[1].text = percen2.ToString();
        if (pm.activePlayerList[2] == true) displayText[2].text = percen3.ToString();
        if (pm.activePlayerList[3] == true) displayText[3].text = percen4.ToString();
    }
}
