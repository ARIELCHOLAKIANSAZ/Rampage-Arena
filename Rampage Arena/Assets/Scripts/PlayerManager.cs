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
    public int[] chosenCharacters = { 3, 3, 3, 3 };
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
            Destroy(this.gameObject);
        }
        else
        {
            Instance = this;
        }

        DontDestroyOnLoad(this);
    }
    void Update()
    {
        if(SceneManager.GetActiveScene().name == "CharSelec" && btnList[1] != null)
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
        else if(SceneManager.GetActiveScene().name == "CharSelec" && btnList[1] == null)
        {
            btnList[0] = GameObject.Find("Player1SelecBtn");
            btnList[1] = GameObject.Find("Player2SelecBtn");
            btnList[2] = GameObject.Find("Player3SelecBtn");
            btnList[3] = GameObject.Find("Player4SelecBtn");
            btnList[4] = GameObject.Find("RampageBtn");
        }
        if(SceneManager.GetActiveScene().name == "Placement")
        {
            playerNumber = 0;
            chosenCharacter = null;
            for (int i = 0; i < 4; i++) 
            {
                chosenCharacters[i] = 3;
                activePlayerList[i] = false;
            }
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
        GameManager.Instance.ChangeSceneSingle("Map");
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
