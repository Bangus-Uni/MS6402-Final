using System.Collections;
using System.Collections.Generic;
using System;
using UnityEngine;

public class Room : IComparable<Room>
{
    public int intRLeftCoord;
    public int intRUpCoord;
    public int intRRightCoord;
    public int intRDownCoord;
    public int intRRoomType;
    public bool boolRUpgradeRoom;
    public bool boolRFinishRoom;

    public Room(int _intRLeftCoord, int _intRUpCoord, int _intRRightCoord, int _intRDownCoord, int _intRRoomType, bool _boolRUpgradeRoom, bool _boolRFinishRoom)
    {
        intRLeftCoord = _intRLeftCoord;
        intRUpCoord = _intRUpCoord;
        intRRightCoord = _intRRightCoord;
        intRDownCoord = _intRDownCoord;
        intRRoomType = _intRRoomType;
        boolRUpgradeRoom = _boolRUpgradeRoom;
        boolRFinishRoom = _boolRFinishRoom;
    }

    public int CompareTo(Room other)
    {
        if (other == null)
        {
            return 1;
        }

        return intRRoomType = other.intRRoomType;
    }
}
