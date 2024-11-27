using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Alteruna;

public class ButtonGameManagerLinker : AttributesSync
{
    public SoundManager sm;
    void Start()
    {
        sm = GameObject.Find("SOUNDMANAGER").GetComponent<SoundManager>();
    }
    public void nextScene()
    {
        sm.ok = true;
        BroadcastRemoteMethod("changingScene");
    }
    [SynchronizableMethod]
    public void changingScene()
    {
        sm.ok = true;
        Debug.Log("NextScene called");
        GameManager.Instance.ChangeSceneSingle("CharSelec");
    }
    public void salir()
    {
        sm.ok = true;
        Application.Quit();
    }
    public void option()
    {
        sm.ok = true;
        GameManager.Instance.ChangeSceneSingle("Options");
    }
    public void rampagin()
    {
        sm.ok = true;
        GameManager.Instance.ChangeSceneSingle("RoomMenu");
    }
    public void xamnin()
    {
        sm.ok = true;
        GameManager.Instance.ChangeSceneSingle("Hub");
    }
    public void charchosen(int num)
    {
        sm.ok = true;
        PlayerManager.Instance.CharChosen(num);
    }
    public void chosnum(int num)
    {
        sm.ok = true;
        PlayerManager.Instance.ChooseNumber(num);
    }
    public void gamstart()
    {
        sm.ok = true;
        PlayerManager.Instance.gameStart();
    }
}
