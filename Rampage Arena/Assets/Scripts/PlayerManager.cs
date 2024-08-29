using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Alteruna;

public class PlayerManager : AttributesSync
{
    public int playerNumber;
    public GameObject[] chosenCharacters;
    public GameObject[] charList;
    public GameObject[] btnList;
    public Text[] charName;
    [SynchronizableField] public float[] playerList;


    public void CharChosen(int num)
    {
        if (playerNumber == 0) return;
        charName[playerNumber-1].text = charList[num].name;
        chosenCharacters[playerNumber - 1] = charList[num];
    }

    public void ChooseNumber(int num)
    {
        if (playerNumber != 0)
        {
            BroadcastRemoteMethod("setActive", btnList[playerNumber-1], true);
            if (chosenCharacters[playerNumber -1] != null)
            {
            charName[playerNumber - 1].text = "";
            chosenCharacters[playerNumber - 1] = null;
            }
        }
        playerNumber = num;
        BroadcastRemoteMethod("setActive", btnList[num-1], false);
    }

    public void gameStart()
    {
        BroadcastRemoteMethod("playerDivide");
        if(playerList[0] != null && chosenCharacters[0] == null)
        {
            return;
        }
        if(playerList[1] != null && chosenCharacters[1] == null)
        {
            return;
        }
        if(playerList[2] != null && chosenCharacters[2] == null)
        {
            return;
        }
        if(playerList[3] != null && chosenCharacters[3] == null)
        {
            return;
        }
        GameManager.Instance.ChangeScene("Battle");
    }

    [SynchronizableMethod]
    public void playerDivide()
    {
        playerList[playerNumber - 1] = UserId;
    }

    [SynchronizableMethod]
    public void setActive(GameObject objtc, bool tof)
    {
        objtc.SetActive(tof);
    }
}
