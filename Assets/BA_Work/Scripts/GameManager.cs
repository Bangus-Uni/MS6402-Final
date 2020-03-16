using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public int intPCHealth = 200;
    public int intPCMaxHealth = 200;

    public int intPCArmor = 100;
    public int intPCMaxArmor = 100;

    public int intPCSpeed = 7;

    public int intDefaultMaxHealth = 200;
    public int intDefaultMaxArmor = 100;
    public int intDefaultSpeed = 7;


    public int intTotalCorruption = 0;
    public int intLACorruption = 0;
    public int intLLCorruption = 0;
    public int intRACorruption = 0;
    public int intRLCorruption = 0;
    public int intCorruptionThreshold = 50;
    public int intMaxCorrupted = 100;

    public int intSpeedBoosts = 0;
    public int intArmorBoosts = 0;
    public int intHealthBoosts = 0;

    public bool boolCorrupted = false;

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
    public Text txtLeftGunName;
    public Text txtRightGunName;
    public Text txtCurrentLevel;


    [Header("Bullets")]
    // List Of Bullets to pick from
    #region AddBullets
    public Bullet _BasicBullet;
    public Bullet _Grenade;
    public Bullet _HomingMissile;
    #endregion

    // List Of Bullets to pick from
    #region Bullets
    static Bullet BasicBullet;
    static Bullet Grenade;
    static Bullet HomingMissile;
    #endregion

    [Header("Popup")]
    #region Popup
    public bool boolPopupActive;
    public GameObject goPopup;
    public Text txtPopupTitle;
    public Text txtPopupDesc;
    public Text txtPopupEffect;
    #endregion

    #region Rooms
    Room StartRoom;
    Room CurrentRoom;
    Room PrevRoom;
    #endregion

    public Dictionary<int, GunType> GunDictionary = new Dictionary<int, GunType>();
    public Dictionary<string, Room> RoomGrid = new Dictionary<string, Room>();
    // Guns To Import
    #region Guns
    GunType gun1;
    GunType gun2;
    GunType gun3;
    GunType gun4;
    GunType gun5;
    GunType gun6;
    GunType gun7;
    GunType gun8;

    GunType guntemp = null;
    #endregion
    void CreateGuns()
    {

        gun1 = new GunType("The PeaShooter", "Gun 1", 1, BasicBullet, 20, 0.08f, false, 0);
        gun2 = new GunType("The Better Peashooter", "Gun 2", 1, BasicBullet, 20, 0.04f, false, 0);
        gun3 = new GunType("Wide Load", "Gun 3", 2, BasicBullet, 20, 0.08f, false, 0);
        gun4 = new GunType("The Wiggler", "Gun 4", 3, BasicBullet, 20, 0.08f, false, 0);
        gun5 = new GunType("Spread Em", "Gun 5", 4, BasicBullet, 20, 0.08f, false, 0);
        gun6 = new GunType("Spread Em Hard", "Gun 6", 5, BasicBullet, 20, 0.04f, true, 30);
        gun7 = new GunType("Bomboclaat", "Gun 7", 6, Grenade, 6, 3f, true, 10);
        gun8 = new GunType("Ass Grabber", "Gun 8", 1, HomingMissile, 25, 2f, true, 20);
    }

    private void Awake()
    {
        LoadBullets();
        CreateGuns();
        AddGuns();

    }

    // Start is called before the first frame update
    void Start()
    {
        goPopup.SetActive(false);
        SetLeftGun(gun1);
        SetRightGun(gun1);
        intPCHealth = intPCMaxHealth;
        intPCArmor = intPCMaxArmor;

        StartRoom = new Room(0, 0, 0, 0, 0, false, false);
        string _strRoomKey = StartRoom.intRLeftCoord.ToString()
                           + StartRoom.intRUpCoord.ToString()
                           + StartRoom.intRRightCoord.ToString()
                           + StartRoom.intRDownCoord.ToString();
        Debug.Log(_strRoomKey);
        RoomGrid.Add(_strRoomKey, StartRoom);
        CurrentRoom = StartRoom;
    }

    // Update is called once per frame
    void Update()
    {
        txtCurrentLevel.text = intCurrentLevel + " - " + intCurrentZone;
    }

    public void LoadBullets()
    {
        BasicBullet = _BasicBullet;
        Grenade = _Grenade;
        HomingMissile = _HomingMissile;
    }

    public void AddGuns() {
        GunDictionary.Add(1, gun1);
        GunDictionary.Add(2, gun2);
        GunDictionary.Add(3, gun3);
        GunDictionary.Add(4, gun4);
        GunDictionary.Add(5, gun5);
        GunDictionary.Add(6, gun6);
        GunDictionary.Add(7, gun7);
        GunDictionary.Add(8, gun8);
        Debug.Log("GunsLoaded");
    }

    void GameOver()
    {
        //txtPCHealth.text = "Dead - Restart";
        Time.timeScale = 0;
    }

    public void CreateRoom(GameObject goCreatingRoom, int intDirection)
    {
        PrevRoom = CurrentRoom;
        Room _NewRoom = null;
        switch (intDirection)
        {
            case 1:
                _NewRoom = new Room(PrevRoom.intRLeftCoord,
                                    PrevRoom.intRUpCoord + 1,
                                    PrevRoom.intRRightCoord,
                                    PrevRoom.intRDownCoord,
                                    0,
                                    false,
                                    false);
                break;
            case 2:
                _NewRoom = new Room(PrevRoom.intRLeftCoord,
                                    PrevRoom.intRUpCoord,
                                    PrevRoom.intRRightCoord + 1,
                                    PrevRoom.intRDownCoord,
                                    0,
                                    false,
                                    false);
                break;
            case 3:
                _NewRoom = new Room(PrevRoom.intRLeftCoord + 1,
                                    PrevRoom.intRUpCoord,
                                    PrevRoom.intRRightCoord,
                                    PrevRoom.intRDownCoord,
                                    0,
                                    false,
                                    false);
                break;
            case 4:
                _NewRoom = new Room(PrevRoom.intRLeftCoord,
                                    PrevRoom.intRUpCoord,
                                    PrevRoom.intRRightCoord,
                                    PrevRoom.intRDownCoord + 1,
                                    0,
                                    false,
                                    false);
                break;
            default:
                break;
        }
        string _strRoomKey = _NewRoom.intRLeftCoord.ToString()
                           + _NewRoom.intRUpCoord.ToString()
                           + _NewRoom.intRRightCoord.ToString()
                           + _NewRoom.intRDownCoord.ToString();
        Debug.Log(_strRoomKey);
        RoomGrid.Add(_strRoomKey, _NewRoom);
        CurrentRoom = _NewRoom;
    }

    public void GenerateRoom(bool _boolPosNeg1, bool _boolPosNeg2, Transform _trRoom)
    {
        float _intDir1 = 0;
        float _intDir2 = 0;
        int _intDirection = 0;
        Vector3 v3NewRoomPos;
        GameObject goNewRoom = null;
        bool boolBossSpawned = false;

        if (intNoRooms == intLevelSize)
        {
            goNewRoom = goBossRoom;
            boolBossSpawned = true;
            //intCurrentZone++;
            //SceneManager.LoadScene(0);
        }

        else
        {
            int intDice = Mathf.RoundToInt(Random.Range(0.5f, (a_goRooms.Length + 0.5f)));
            goNewRoom = a_goRooms[intDice - 1];
            intNoRooms++;
        }

        if (_boolPosNeg1 && _boolPosNeg2)
        {
            _intDirection = 1;
        }

        else if (_boolPosNeg1 && !_boolPosNeg2)
        {
            _intDirection = 2;
        }

        else if (!_boolPosNeg1 && _boolPosNeg2)
        {
            _intDirection = 3;
        }

        else if (!_boolPosNeg1 && !_boolPosNeg2)
        {
            _intDirection = 4;
        }

        CreateRoom(goNewRoom, _intDirection);

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

    public void SetLeftGun(GunType GunPickup) {
        txtLeftGunName.text = GunPickup.strGTGunName;
        if (GunPickup.boolGTCorrupted)
        {
            intLACorruption = GunPickup.intGTCorruption;
            intTotalCorruption = intLACorruption + intLLCorruption + intRACorruption + intRLCorruption;
            if (intTotalCorruption > intCorruptionThreshold)
            {
                TooCorrupted();
            }
        }   
    }

    public void SetRightGun(GunType GunPickup)
    {
        txtRightGunName.text = GunPickup.strGTGunName;
        if (GunPickup.boolGTCorrupted)
        {
            intRACorruption = GunPickup.intGTCorruption;
            intTotalCorruption = intLACorruption + intLLCorruption + intRACorruption + intRLCorruption;
            if (intTotalCorruption > intCorruptionThreshold)
            {
                TooCorrupted();
            }
        }
    }

    public void HealthBoost()
    {
        intHealthBoosts++;
        intPCMaxHealth = intPCMaxHealth + (intHealthBoosts * (intPCMaxHealth / 5));
        intPCHealth = intPCMaxHealth;
    }

    public void ArmorBoost()
    {
        intArmorBoosts++;
        intPCMaxArmor = intPCMaxArmor + (intArmorBoosts * (intPCMaxArmor/5));
        intPCArmor = intPCMaxArmor;
    }

    public void SpeedBoost ()
    {
        intSpeedBoosts++;
        intPCSpeed = intPCSpeed + intSpeedBoosts;
    }

    public void TooCorrupted()
    {
        intHealthBoosts = 0;
        intArmorBoosts = 0;
        intSpeedBoosts = 0;

        intPCSpeed = intDefaultSpeed;
        intPCMaxHealth = intDefaultMaxHealth;
        intPCMaxArmor = intDefaultMaxArmor;

        if (intPCHealth > intPCMaxHealth) intPCHealth = intPCMaxHealth;
        if (intPCArmor > intPCMaxArmor) intPCArmor = intPCMaxArmor;
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

    public void AddArmor(int _intArmorValue)
    {
        intPCArmor = intPCArmor + _intArmorValue;
        if (intPCArmor > intPCMaxArmor) intPCArmor = intPCMaxArmor;
        imgPCArmor.rectTransform.sizeDelta = new Vector2(intPCArmor, 22);
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

    public void Popup(GunType _GunPickup) {
        if (!boolPopupActive)
        {
            txtPopupTitle.text = _GunPickup.strGTGunName;
            txtPopupDesc.text = _GunPickup.strGTGunDesc;
            goPopup.SetActive(true);
            boolPopupActive = true;
        }

        else if (boolPopupActive)
        {
            goPopup.SetActive(false);
            boolPopupActive = false;
        }
    }
}