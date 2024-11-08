using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PointsManager : MonoBehaviour
{
    public static PointsManager Instance;
    GameObject P1;
    GameObject P2;
    GameObject P3;
    GameObject P4;
    public int[] placement = {0, 0, 0, 0};
    bool[] placed = {false, false, false, false};
    int placing = 4;
    PlayerManager pm;
    LayerManager lm;
    string[] nameArray = { "", "", "", "" };
    bool done = false;
    public float playerAmmount = 4;
    bool again = true;

    void Awake()
    {
        if (Instance != this && Instance != null) Destroy(this);
        else Instance = this;
        DontDestroyOnLoad(this);
    }
    void Start()
    {
        pm = GameObject.Find("PLAYERMANAGER").GetComponent<PlayerManager>();
    }
    void Update()
    {
        if (again && SceneManager.GetActiveScene().name == "Battle")
        {
            StartCoroutine(GetGameObjects());
            again = false;
        }
        if (SceneManager.GetActiveScene().name == "Placement")
        {
            again = true;
            done = false;
        }
        if (SceneManager.GetActiveScene().name == "Battle" && done == true)
        {
            if (placement[0] == 0 && placed[0] == false && pm.activePlayerList[0] == true && P1 == null)
            {
                placed[0] = true;
                placement[0] = placing;
                placing -= 1;
            }
            else if (pm.activePlayerList[0] == false && placed[0] == false)
            {
                placed[0] = true;
                placement[0] = 5;
                placing -= 1;
                playerAmmount -=1;
            }
            else if (placing == 1 && placed[0] == false)
            {
                placed[0] = true;
                placement[0] = placing;
                placing -= 1;
            }
            if (placement[1] == 0 && placed[1] == false && pm.activePlayerList[1] == true && P2 == null)
            {
                placed[1] = true;
                placement[1] = placing;
                placing -= 1;
            }
            else if (pm.activePlayerList[1] == false && placed[1] == false)
            {
                placed[1] = true;
                placement[1] = 5;
                placing -= 1;
                playerAmmount -=1;
            }
            else if (placing == 1 && placed[1] == false)
            {
                placed[1] = true;
                placement[1] = placing;
                placing -= 1;
            }
            if (placement[2] == 0 && placed[2] == false && pm.activePlayerList[2] == true && P3 == null)
            {
                placed[2] = true;
                placement[2] = placing;
                placing -= 1;
            }
            else if (pm.activePlayerList[2] == false && placed[2] == false)
            {
                placed[2] = true;
                placement[2] = 5;
                placing -= 1;
                playerAmmount -=1;
            }
            else if (placing == 1 && placed[2] == false)
            {
                placed[2] = true;
                placement[2] = placing;
                placing -= 1;
            }
            if (placement[3] == 0 && placed[3] == false && pm.activePlayerList[3] == true && P4 == null)
            {
                placed[3] = true;
                placement[3] = placing;
                placing -= 1;
            }
            else if (pm.activePlayerList[3] == false && placed[3] == false)
            {
                placed[3] = true;
                placement[3] = 5;
                placing -= 1;
                playerAmmount -=1;
            }
            else if (placing == 1 && placed[3] == false)
            {
                placed[3] = true;
                placement[3] = placing;
                placing -= 1;
            }
            if(placing == 0) GameManager.Instance.ChangeSceneSingle("Placement");
        }
    }
    IEnumerator GetGameObjects()
    {
        yield return new WaitForSeconds(3);
        Alteruna.Avatar[] avaArray = FindObjectsOfType<Alteruna.Avatar>();
        for (int i = 0; i < avaArray.Length; i++)
        {
            nameArray[i] = avaArray[i].gameObject.name;
        }       
        for(int i = 0; i < avaArray.Length; i++)
        {
            if (GameObject.Find(nameArray[i]).GetComponent<ThirdPersonMovement>().playNum == 1) P1 = GameObject.Find(nameArray[i]);
            if (GameObject.Find(nameArray[i]).GetComponent<ThirdPersonMovement>().playNum == 2) P2 = GameObject.Find(nameArray[i]);
            if (GameObject.Find(nameArray[i]).GetComponent<ThirdPersonMovement>().playNum == 3) P3 = GameObject.Find(nameArray[i]);
            if (GameObject.Find(nameArray[i]).GetComponent<ThirdPersonMovement>().playNum == 4) P4 = GameObject.Find(nameArray[i]);
        }
        yield return new WaitForSeconds(0.5f);
        done = true;
    }
}
