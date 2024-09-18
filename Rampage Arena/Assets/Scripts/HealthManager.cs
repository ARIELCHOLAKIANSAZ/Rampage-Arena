using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Alteruna;
using UnityEngine.UI;

public class HealthManager : AttributesSync
{
    public float[] percen = { 0, 0, 0, 0 };
    [SynchronizableField] public bool[] hit = { false, false, false, false };
    [SynchronizableField] public float[] dam = { 0, 0, 0, 0 };
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
        if (hit[0])
        {
            percen[0] += dam[0];
            hit[0] = false;
        }
        if (hit[1])
        {
            percen[1] += dam[1];
            hit[1] = false;
        }
        if (hit[2])
        {
            percen[2] += dam[2];
            hit[2] = false;
        }
        if (hit[3])
        {
            percen[3] += dam[3];
            hit[3] = false;
        }
        if (pm.activePlayerList[0] == true) displayText[0].text = percen[0].ToString();
        if (pm.activePlayerList[1] == true) displayText[1].text = percen[1].ToString();
        if (pm.activePlayerList[2] == true) displayText[2].text = percen[2].ToString();
        if (pm.activePlayerList[3] == true) displayText[3].text = percen[3].ToString();

    }
}
