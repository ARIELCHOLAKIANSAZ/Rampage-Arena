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
    public void salir()
    {
        Application.Quit();
    }
    public void option()
    {
        GameManager.Instance.ChangeSceneSingle("Options");
    }
    public void rampagin()
    {
        GameManager.Instance.ChangeSceneSingle("RoomMenu");
    }
    public void xamnin()
    {
        GameManager.Instance.ChangeSceneSingle("Hub");
    }
}
