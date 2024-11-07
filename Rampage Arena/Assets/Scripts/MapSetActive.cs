using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MapSetActive : MonoBehaviour
{
    [SerializeField] GameObject[] maps;
    [SerializeField] GameObject[] killzones;
    MapManager mapManager;

    void Start()
    {
        mapManager = GameObject.Find("MAPMANAGER").GetComponent<MapManager>();
        maps[mapManager.finalMap].SetActive(true);
        killzones[mapManager.finalMap].SetActive(true);
    }
}
