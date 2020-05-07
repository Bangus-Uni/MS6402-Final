using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RoomController : MonoBehaviour
{
    public bool boolFirstRoom;

    public bool boolActivated = false;

    public bool boolRoomOpened = false;
    public bool boolRoomOpenedComp = false;

    public bool boolRoomCompleted = false;

    public Door[] a_goDoors;

    public Enemy[] a_goEnemies;

    void Start()
    {
        a_goDoors = GetComponentsInChildren<Door>();
    }

    // Update is called once per frame
    void Update()
    {
        a_goEnemies = GetComponentsInChildren<Enemy>();
        if (a_goEnemies.Length == 0 && !boolRoomCompleted)
        {
            RoomCompleted();
        }
    }

    public void RoomOpening()
    {
        for (int i = 0; i < a_goDoors.Length; i++)
        {
            a_goDoors[i].boolUseable = false;
        }

        boolRoomOpenedComp = true;
    }

    void RoomCompleted()
    {
        for (int i = 0; i < a_goDoors.Length; i++)
        {
            a_goDoors[i].boolUseable = true;
        }

        boolRoomCompleted = true;
    }
}
