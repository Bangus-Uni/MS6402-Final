using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Door : MonoBehaviour
{
    public bool boolPosNeg1;
    public bool boolPosNeg2;

    public bool boolUseable = true;

    public bool boolOpened = false;

    public GameObject goRoom;

    GameManager GM;


    void Start()
    {
        GM = FindObjectOfType<GameManager>();
        goRoom = gameObject.transform.parent.gameObject;
    }

    private void OnTriggerEnter(Collider other)
    {
        if (!boolOpened && other.tag == "PC") GM.GenerateRoom(boolPosNeg1, boolPosNeg2, goRoom.transform);
        boolOpened = true;
    }
}
