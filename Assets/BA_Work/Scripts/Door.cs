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

    GameObject goParticles;

    public bool BoolBigRoomDoor;


    void Start()
    {
        GM = FindObjectOfType<GameManager>();
        goRoom = gameObject.transform.parent.gameObject;
        bcDoor = GetComponent<BoxCollider>();
        RC = GetComponentInParent<RoomController>();
        goParticles = transform.GetChild(0).gameObject;
    }

    private void Update()
    {
        if (boolUseable == false)
        {
            bcDoor.isTrigger = false;
            goParticles.SetActive(true);
        }
        else
        {
            bcDoor.isTrigger = true;
            goParticles.SetActive(false);
        }
    }

    private void OnTriggerEnter(Collider other)
    {
       if (other.gameObject.tag == "PC" && RC.boolRoomCompleted == true)
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
            Debug.Log("LockingRoom");
            RC.RoomOpening();
            gameObject.SetActive(false);
        }
    }
}
