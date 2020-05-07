using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Door : MonoBehaviour
{
    public bool boolPosNeg1;
    public bool boolPosNeg2;

    public bool boolUseable = true;

    public bool boolOpened = false;

    public bool boolPicked = false;

    public GameObject goRoom;

    GameManager GM;

    BoxCollider bcDoor;

    RoomController RC;


    void Start()
    {
        GM = FindObjectOfType<GameManager>();
        goRoom = gameObject.transform.parent.gameObject;
        bcDoor = GetComponent<BoxCollider>();
        RC = GetComponentInParent<RoomController>();
    }

    private void Update()
    {
        if (boolUseable == false)
        {
            bcDoor.isTrigger = false;
        }
        else
        {
            bcDoor.isTrigger = true;
        }
    }

    private void OnTriggerEnter(Collider other)
    {
       if (RC.boolActivated == true)
        {
            boolPicked = true;
            if (!boolOpened && other.tag == "PC") GM.GenerateRoom(boolPosNeg1, boolPosNeg2, goRoom.transform);
            boolOpened = true;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.tag == "PC" && RC.boolActivated == false)
        {
            RC.RoomOpening();
        }
    }
}
