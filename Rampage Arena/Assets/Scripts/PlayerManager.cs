using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerManager : MonoBehaviour
{
    public int playerNumber;
    public GameObject[] chosenCharacters;
    public GameObject[] charList;
    public GameObject[] btnList;
    public Text[] charName;

    public void CharChosen(int num)
    {
        if (playerNumber == 0) return;
        charName[playerNumber-1].text = charList[num].name;
        chosenCharacters[playerNumber - 1] = charList[num];
    }

    public void ChooseNumber(int num)
    {
        playerNumber = num;
        btnList[num-1].SetActive(false);
    }
}
