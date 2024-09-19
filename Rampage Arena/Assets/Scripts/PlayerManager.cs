using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Alteruna;
using Microsoft.Win32;
using UnityEngine.SceneManagement;

public class PlayerManager : AttributesSync
{
    public int playerNumber;
    public GameObject chosenCharacter;
    public float[] chosenCharacters = { 3, 3, 3, 3 };
    public GameObject[] charList;
    public GameObject[] btnList;
    public Text[] charName;
    public bool[] activePlayerList = { false, false, false, false };
    int pnumM1;

    public static PlayerManager Instance;

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
    void Update()
    {
        if(SceneManager.GetActiveScene().name == "CharSelec")
        {
        if (!activePlayerList[0] && !activePlayerList[1] && !activePlayerList[2] && !activePlayerList[3])
        {
            btnList[4].SetActive(false);
        }
        else if (activePlayerList[0] && chosenCharacters[0] == 3)
        {
            btnList[4].SetActive(false);
        }
        else if (activePlayerList[1] && chosenCharacters[1] == 3)
        {
            btnList[4].SetActive(false);
        }
        else if (activePlayerList[2] && chosenCharacters[2] == 3)
        {
            btnList[4].SetActive(false);
        }
        else if (activePlayerList[3] && chosenCharacters[3] == 3)
        {
            btnList[4].SetActive(false);
        }
        else btnList[4].SetActive(true);
        }
    }

    public void CharChosen(int num)
    {
        if (playerNumber == 0) return;
        charName[playerNumber-1].text = charList[num].name;
        chosenCharacter = charList[num];
        pnumM1 = playerNumber - 1;
        BroadcastRemoteMethod("setChosenChars", pnumM1, num);
    }

    public void ChooseNumber(int num)
    {
        if (playerNumber != 0)
        {
            btnList[playerNumber-1].SetActive(true);
            activePlayerList[playerNumber - 1] = false;
            pnumM1 = playerNumber - 1;
            BroadcastRemoteMethod("setActivePlayers", pnumM1 - 1, false);
            if (chosenCharacters[playerNumber -1] != 3)
            {
                charName[playerNumber - 1].text = "";
                chosenCharacter = null;
                pnumM1 = playerNumber - 1;
                BroadcastRemoteMethod("setChosenChars", pnumM1, 3);
        BroadcastRemoteMethod("setActivePlayers", pnumM1, true);
            }
        }
        playerNumber = num;
        btnList[num-1].SetActive(false);
        pnumM1 = playerNumber - 1;
        BroadcastRemoteMethod("setActivePlayers", pnumM1, true);
    }

    public void gameStart()
    {
        BroadcastRemoteMethod("toBattle");
    }

    [SynchronizableMethod]
    public void toBattle()
    {
        GameManager.Instance.ChangeSceneSingle("Battle");
    }
    [SynchronizableMethod]
    public void setActivePlayers(int playerNum, bool isPlayerActive)
    {
        activePlayerList[playerNum] = isPlayerActive;
    }

    [SynchronizableMethod]
    public void setChosenChars(int playerNum, int charChosen)
    {
        chosenCharacters[playerNum] = charChosen;
    }

}
