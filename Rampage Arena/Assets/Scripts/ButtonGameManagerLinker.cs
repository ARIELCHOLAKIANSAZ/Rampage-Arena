using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Alteruna;

public class ButtonGameManagerLinker : AttributesSync
{
    public void nextScene()
    {
        BroadcastRemoteMethod("changingScene");
    }
    [SynchronizableMethod]
    public void changingScene()
    {
        Debug.Log("NextScene called");
        GameManager.Instance.ChangeSceneSingle("CharSelec");
    }

}
