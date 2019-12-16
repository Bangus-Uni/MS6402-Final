using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    public int intPCHealth = 100;
    public int intPCMaxHealth = 100;


    public GameObject[] a_goRooms;
    public GameObject goBossRoom;

    public int intNoRooms;
    public int intLevelSize = 4;

    public Text txtPCHealth;
    public Text txtLeftGunAmmo;
    public Text txtRightGunAmmo;


    // Start is called before the first frame update
    void Start()
    {
        intPCHealth = intPCMaxHealth;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void GameOver()
    {
        txtPCHealth.text = "Dead - Restart";
        Time.timeScale = 0;
    }

    public void GenerateRoom(bool _boolPosNeg1, bool _boolPosNeg2, Transform _trRoom)
    {
        float _intDir1 = 0;
        float _intDir2 = 0;
        Vector3 v3NewRoomPos;
        GameObject goNewRoom;
        bool boolBossSpawned = false;

        if (intNoRooms == intLevelSize)
        {
            goNewRoom = goBossRoom;
            boolBossSpawned = true;
        }

        else
        {
            int intDice = Mathf.RoundToInt(Random.Range(0.5f, (a_goRooms.Length + 0.5f)));
            goNewRoom = a_goRooms[intDice - 1];
            intNoRooms++;
        }

        //////////////////////////////

        if (_boolPosNeg1 && _boolPosNeg2)
        {
            _intDir1 = 14.1f;
            _intDir2 = 14.1f;
            v3NewRoomPos = new Vector3(_trRoom.position.x + _intDir1, _trRoom.position.y, _trRoom.position.z + _intDir2);
            GameObject _goNewRoom = Instantiate(goNewRoom, v3NewRoomPos, _trRoom.rotation);
            _goNewRoom.transform.GetChild(4).gameObject.SetActive(false);
        }

        else if (_boolPosNeg1 && !_boolPosNeg2)
        {
            _intDir1 = 14.1f;
            _intDir2 = -14.1f;
            v3NewRoomPos = new Vector3(_trRoom.position.x + _intDir1, _trRoom.position.y, _trRoom.position.z + _intDir2);
            GameObject _goNewRoom = Instantiate(goNewRoom, v3NewRoomPos, _trRoom.rotation);
            _goNewRoom.transform.GetChild(3).gameObject.SetActive(false);
        }

        else if (!_boolPosNeg1 && _boolPosNeg2)
        {
            _intDir1 = -14.1f;
            _intDir2 = 14.1f;
            v3NewRoomPos = new Vector3(_trRoom.position.x + _intDir1, _trRoom.position.y, _trRoom.position.z + _intDir2);
            GameObject _goNewRoom = Instantiate(goNewRoom, v3NewRoomPos, _trRoom.rotation);
            _goNewRoom.transform.GetChild(2).gameObject.SetActive(false);
        }

        else if (!_boolPosNeg1 && !_boolPosNeg2)
        {
            _intDir1 = -14.1f;
            _intDir2 = -14.1f;
            v3NewRoomPos = new Vector3(_trRoom.position.x + _intDir1, _trRoom.position.y, _trRoom.position.z + _intDir2);
            GameObject _goNewRoom = Instantiate(goNewRoom, v3NewRoomPos, _trRoom.rotation);
            _goNewRoom.transform.GetChild(1).gameObject.SetActive(false);
        }

        ////////////////////////////
        
        if (boolBossSpawned)
        {
           Door[] a_AllDoors = FindObjectsOfType<Door>();

            for (int i = 0; i < a_AllDoors.Length; i++)
            {
                a_AllDoors[i].gameObject.SetActive(false);
            }

        }
    }

    public void PCHit()
    {
        intPCHealth--;
        txtPCHealth.text = intPCHealth.ToString();
        if (intPCHealth <= 0)
        {
            GameOver();
        }
    }

    public void LeftGunAmmo(int _intAmmo, bool _boolOverHeat)
    {
        if (_boolOverHeat) txtLeftGunAmmo.color = Color.red;
        else txtLeftGunAmmo.color = Color.white;
        txtLeftGunAmmo.text = _intAmmo.ToString();
    }

    public void RightGunAmmo(int _intAmmo, bool _boolOverHeat)
    {
        if (_boolOverHeat) txtRightGunAmmo.color = Color.red;
        else txtRightGunAmmo.color = Color.white;
        txtRightGunAmmo.text = _intAmmo.ToString();
    }
}