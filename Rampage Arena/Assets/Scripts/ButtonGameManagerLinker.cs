using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Alteruna;

public class ButtonGameManagerLinker : AttributesSync
{
    public void nextScene()
    {
        GameManager.Instance.ChangeScene("CharSelec");
    }
}
