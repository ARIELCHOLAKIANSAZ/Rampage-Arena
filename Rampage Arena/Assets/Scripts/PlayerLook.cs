using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerLook : MonoBehaviour
{
    public GameObject cam;
    public GameObject player;
    private Alteruna.Avatar ava;
    public Cinemachine.CinemachineFreeLook vcam;

    void Awake()
    {
        ava = GetComponent<Alteruna.Avatar>();
        if (!ava.IsMe) return;
    }
    void Update()
    {
        if (!ava.IsMe) return;
        cam = GameObject.Find("Third Person Camera");
        vcam = cam.GetComponent<Cinemachine.CinemachineFreeLook>();
        vcam.Follow = player.transform;
        vcam.LookAt = player.transform;
    }

}
