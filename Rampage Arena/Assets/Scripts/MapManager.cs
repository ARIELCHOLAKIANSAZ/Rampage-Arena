using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using Alteruna;

public class MapManager : AttributesSync
{
    PlayerManager pm;
    [SynchronizableField] public int easterIslandP;
    [SynchronizableField] public int epicPeaksP;
    [SynchronizableField] public int roofCityP;
    public GameObject[] mapBtns;
    int playerAmmount;
    bool mapChosen = false;
    public int finalMap;
    public static MapManager Instance;

    void Awake()
    {
        if(Instance != this && Instance != null)
        {
            Destroy(this);
        }
        else
        {
            Instance = this;
        }

        DontDestroyOnLoad(this);
    }
    void Start()
    {
            pm = GameObject.Find("PLAYERMANAGER").GetComponent<PlayerManager>();
            for(int i = 0; i < 4; i++)
            {
                if(pm.activePlayerList[i] == true) playerAmmount += 1;
            }
    }

    void Update()
    {
        if(easterIslandP + epicPeaksP + roofCityP == playerAmmount && !mapChosen) 
        {
            if(easterIslandP > epicPeaksP && easterIslandP > roofCityP) finalMap = 0;
            if(epicPeaksP > easterIslandP && epicPeaksP > roofCityP) finalMap = 1;
            if(roofCityP > epicPeaksP && roofCityP > easterIslandP) finalMap = 2;
            if(easterIslandP == epicPeaksP && easterIslandP > roofCityP) finalMap = Random.Range(0, 1);
            if(epicPeaksP == roofCityP && epicPeaksP > easterIslandP) finalMap = Random.Range(1, 2);
            if(easterIslandP == roofCityP && easterIslandP > epicPeaksP)
            {
                finalMap = Random.Range(3, 4);
                if(finalMap == 3) finalMap = 0;
                if(finalMap == 4) finalMap = 2;
            }
            if(easterIslandP == epicPeaksP && easterIslandP == roofCityP) finalMap = Random.Range(0, 2);
            mapChosen = true;
            GameManager.Instance.ChangeSceneSingle("Battle");
        }
    }

    public void VoteMap(int map)
    {
        if(map == 0) easterIslandP += 1;
        if(map == 1) epicPeaksP += 1;
        if(map == 2) roofCityP += 1;

        for(int i = 0; i < mapBtns.Length; i++)
        {
            mapBtns[i].SetActive(false);
        }
    }
}
