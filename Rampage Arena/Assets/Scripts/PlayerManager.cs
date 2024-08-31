using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Alteruna;
using Microsoft.Win32;

public class PlayerManager : AttributesSync
{
    public int playerNumber;
    public GameObject chosenCharacter;
    [SynchronizableField] public float[] chosenCharacters = { 3, 3, 3, 3 };
    public GameObject[] charList;
    public GameObject[] btnList;
    public Text[] charName;
    [SynchronizableField] public bool[] activePlayerList = { false, false, false, false };

    void Update()
    {
        Debug.Log("0");
        if (!activePlayerList[0] && !activePlayerList[1] && !activePlayerList[2] && !activePlayerList[3])
        {
            btnList[4].SetActive(false);
            Debug.Log("1");
        }
        else if (activePlayerList[0] && chosenCharacters[0] == 3)
        {
            btnList[4].SetActive(false);
            Debug.Log("2");
        }
        else if (activePlayerList[1] && chosenCharacters[1] == 3)
        {
            btnList[4].SetActive(false);
            Debug.Log("3");
        }
        else if (activePlayerList[2] && chosenCharacters[2] == 3)
        {
            btnList[4].SetActive(false);
            Debug.Log("4");
        }
        else if (activePlayerList[3] && chosenCharacters[3] == 3)
        {
            btnList[4].SetActive(false);
            Debug.Log("5");
        }
        else btnList[4].SetActive(true);
        Debug.Log("w");
    }

    public void CharChosen(int num)
    {
        if (playerNumber == 0) return;
        charName[playerNumber-1].text = charList[num].name;
        chosenCharacter = charList[num];
        chosenCharacters[playerNumber - 1] = num;
    }

    public void ChooseNumber(int num)
    {
        if (playerNumber != 0)
        {
            btnList[playerNumber-1].SetActive(true);
            activePlayerList[playerNumber - 1] = false;
            if (chosenCharacters[playerNumber -1] != 3)
            {
                charName[playerNumber - 1].text = "";
                chosenCharacter = null;
                chosenCharacters[playerNumber - 1] = 3;
            }
        }
        playerNumber = num;
        btnList[num-1].SetActive(false);
        activePlayerList[playerNumber - 1] = true;
    }

    public void gameStart()
    {
        GameManager.Instance.ChangeScene("Battle");
    }


}
