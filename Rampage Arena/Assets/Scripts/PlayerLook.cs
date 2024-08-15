using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerLook : MonoBehaviour
{
    private Cinemachine.CinemachineVirtualCamera cam;
    void Start()
    {
        cam = GetComponent<Cinemachine.CinemachineVirtualCamera>();
    }

    public void LockIn(GameObject gemobj)
    {
        cam.Follow = gemobj.transform;
        cam.LookAt = gemobj.transform;
    }

}
