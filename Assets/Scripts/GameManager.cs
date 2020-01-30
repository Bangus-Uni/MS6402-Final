using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    public int intPCHealth = 200;
    public int intPCMaxHealth = 200;

    public int intPCArmor = 100;
    public int intPCMaxArmor = 100;


    public GameObject[] a_goRooms;
    public GameObject goBossRoom;

    public int intNoRooms;
    public int intLevelSize = 4;

    public int intCurrentLevel = 1;
    public int intCurrentZone = 1;

    public Image imgPCHealth;
    public Image imgPCArmor;
    public Text txtLeftGunAmmo;
    public Text txtRightGunAmmo;
    public Text txtCurrentLevel;
    public Text txtCurrentZone;


    [Header("Bullets")]
    // List Of Bullets to pick from
    #region AddBullets
    public Bullet _BasicBullet;
    #endregion

    // List Of Bullets to pick from
    #region Bullets
    public static Bullet BasicBullet; 
    #endregion

    Dictionary<int, GunType> GunDictionary = new Dictionary<int, GunType>();

    // Guns To Import
    #region Guns

    GunType gun1 = new GunType("The PeaShooter", 1, BasicBullet, 20, 0.08f, false, 0);
    GunType gun2 = new GunType("The Better Peashooter", 1, BasicBullet, 20, 0.04f, false, 0);
    GunType gun3 = new GunType("Wide Load", 1, BasicBullet, 20, 0.08f, false, 0);
    GunType gun4 = new GunType("The Wiggler", 1, BasicBullet, 20, 0.08f, false, 0);
    GunType gun5 = new GunType("Spread Em", 1, BasicBullet, 20, 0.08f, false, 0);

    GunType guntemp = null;

    #endregion


    // Start is called before the first frame update
    void Start()
    {
        LoadBullets();
        AddGuns();
        intPCHealth = intPCMaxHealth;
        intPCArmor = intPCMaxArmor;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void LoadBullets()
    {
        BasicBullet = _BasicBullet;
    }

    public void AddGuns() {
        GunDictionary.Add(1, gun1);
        GunDictionary.Add(2, gun2);
        GunDictionary.Add(3, gun3);
        GunDictionary.Add(4, gun4);
        GunDictionary.Add(5, gun5);
    }

    void GameOver()
    {
        //txtPCHealth.text = "Dead - Restart";
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
        if (intPCArmor > 0) {
            intPCArmor--;
            imgPCArmor.rectTransform.sizeDelta = new Vector2(intPCArmor, 22);
        }

        else {
            intPCHealth--;
            imgPCHealth.rectTransform.sizeDelta = new Vector2(intPCHealth * 2, 22);
        }

        if (intPCHealth <= 0)
        {
            GameOver();
        }
    }

    public void LeftGunAmmo(int _intAmmo, bool _boolOverHeat)
    {
        if (_boolOverHeat) txtLeftGunAmmo.color = Color.red;
        else txtLeftGunAmmo.color = Color.white;
        txtLeftGunAmmo.text = _intAmmo.ToString() + "%";
    }

    public void RightGunAmmo(int _intAmmo, bool _boolOverHeat)
    {
        if (_boolOverHeat) txtRightGunAmmo.color = Color.red;
        else txtRightGunAmmo.color = Color.white;
        txtRightGunAmmo.text = _intAmmo.ToString() + "%";
    }
}