using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlacementManager : MonoBehaviour
{
    PlayerManager pm;
    PointsManager ptm;
    public GameObject[] FirstPlace;
    public GameObject[] SecondPlace;
    public GameObject[] ThirdPlace;
    public GameObject[] FourthPlace;
    public GameObject[] Podium;
    void Start()
    {
        pm = GameObject.Find("PLAYERMANAGER").GetComponent<PlayerManager>();
        ptm = GameObject.Find("POINTMANAGER").GetComponent<PointsManager>();
        //if (ptm.playerAmmount <= 3) Podium[0].SetActive(false);
        //if (ptm.playerAmmount <= 2) Podium[1].SetActive(false);
        for (int i = 0; i < 4; i++)
        {
            if (ptm.placement[i] != 5) 
            {
                if (ptm.placement[i] == 1) FirstPlace[pm.chosenCharacters[i]].SetActive(true);
                if (ptm.placement[i] == 2) SecondPlace[pm.chosenCharacters[i]].SetActive(true);
                if (ptm.placement[i] == 3) ThirdPlace[pm.chosenCharacters[i]].SetActive(true);
                if (ptm.placement[i] == 4) FourthPlace[pm.chosenCharacters[i]].SetActive(true);
            }
        }
    }
}
