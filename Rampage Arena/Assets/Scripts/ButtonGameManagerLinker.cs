using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ButtonGameManagerLinker : MonoBehaviour
{
public void nextScene()
    {
        GameManager.Instance.ChangeScene("CharSelec");
    }
}
