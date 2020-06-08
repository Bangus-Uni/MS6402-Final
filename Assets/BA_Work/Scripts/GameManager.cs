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

    [Header("Canvas")]
    public Canvas canStartScreen;
    public Canvas canMainUI;
    public Canvas canLore;


    [Header("Bullets")]
    // List Of Bullets to pick from
    #region AddBullets
    public Bullet _BasicBullet;
    public Bullet _Grenade;
    public Bullet _HomingMissile;
    public Bullet _FlamingBullet;
    public Bullet _IceBullet;
    public Bullet _ShockBullet;
    #endregion

    // List Of Bullets to pick from
    #region Bullets
    static Bullet BasicBullet;
    static Bullet Grenade;
    static Bullet HomingMissile;
    static Bullet FlamingBullet;
    static Bullet IceBullet;
    static Bullet ShockBullet;
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
    GunType gun9;
    GunType gun10;
    GunType gun11;
    GunType gun12;
    GunType gun13;
    GunType gun14;
    GunType gun15;
    GunType gun16;
    GunType gun17;
    GunType gun18;

    GunType guntemp = null;
    #endregion
    void CreateGuns()
    {

        gun1 = new GunType("The PeaShooter", "Basic Gun", 1, BasicBullet, 20, 0.08f, false, 0);
        gun2 = new GunType("The Better Peashooter", "Better Basic Gun", 1, BasicBullet, 20, 0.04f, false, 0);
        gun3 = new GunType("Wide Load", "A Wide Spreaded Gun", 2, BasicBullet, 20, 0.08f, false, 0);
        gun4 = new GunType("The Wiggler", "Rapid Firing Beam", 3, BasicBullet, 20, 0.08f, false, 0);
        gun5 = new GunType("Spread Em", "3 Streams of Bullets", 4, BasicBullet, 20, 0.08f, false, 0);
        gun6 = new GunType("Spread Em Hard", "CORRUPTED - 5 Streams of Bullets", 5, BasicBullet, 20, 0.04f, true, 30);
        gun7 = new GunType("Bomboclaat", "Grenade Launcher", 6, Grenade, 6, 3f, true, 10);
        gun8 = new GunType("Ass Grabber", "Homing Missile", 1, HomingMissile, 25, 2f, true, 20);
        gun9 = new GunType("The Puncher", "CORRUPTED - Short Range Cluster Shot", 7, BasicBullet, 20, 0.04f, true, 0);
        gun10 = new GunType("Flaming PeaShooter", "Fire Effect - Basic Gun", 1, FlamingBullet, 20, 0.08f, false, 0);
        gun11 = new GunType("Frozen PeaShooter", "Ice Effect - Basic Gun", 1, IceBullet, 20, 0.08f, false, 0);
        gun12 = new GunType("Shocking PeaShooter", "Shock Effect - Basic Gun", 1, ShockBullet, 20, 0.08f, false, 0);
        gun13 = new GunType("Fire Punch", "CORRUPTED - Fire Effect - Short Range Cluster Shot", 7, FlamingBullet, 20, 0.04f, true, 0);
        gun14 = new GunType("Shock Whipper", "CORRUPTED - Shock Effect - Rapid Firing Beam", 3, ShockBullet, 20, 0.08f, false, 0);
        gun15 = new GunType("Ice Wave", "Ice Effect - A Wide Spreaded Gun", 2, IceBullet, 20, 0.08f, false, 0);
        gun16 = new GunType("Flaming Spread", "CORRUPTED - Fire Effect - 3 Streams of Bullets", 4, FlamingBullet, 20, 0.08f, true, 0);
        gun17 = new GunType("Lightning Bolt", "CORRUPTED - Shock Effect - Better Basic Gun", 1, ShockBullet, 20, 0.04f, true, 0);
        gun18 = new GunType("Chilly Blow", "CORRUPTED - Ice Effect - Short Range Cluster Shot", 7, IceBullet, 20, 0.04f, true, 0);

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

        canMainUI.gameObject.SetActive(false);
        canLore.gameObject.SetActive(false);
        canStartScreen.gameObject.SetActive(true);
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKey(KeyCode.Tab) && Input.GetKey(KeyCode.P))
        {
            GameOver();
        }

        if (Input.GetKey(KeyCode.Tab) && Input.GetKey(KeyCode.O))
        {
            SceneManager.LoadScene(1);
        }

        txtCurrentLevel.text = intCurrentLevel + " - " + intCurrentZone;
    }

    public void LoadBullets()
    {
        BasicBullet = _BasicBullet;
        Grenade = _Grenade;
        HomingMissile = _HomingMissile;
        FlamingBullet = _FlamingBullet;
        IceBullet = _IceBullet;
        ShockBullet = _ShockBullet;
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
        GunDictionary.Add(9, gun9);
        GunDictionary.Add(10, gun10);
        GunDictionary.Add(11, gun11);
        GunDictionary.Add(12, gun12);
        GunDictionary.Add(13, gun13);
        GunDictionary.Add(14, gun14);
        GunDictionary.Add(15, gun15);
        GunDictionary.Add(16, gun16);
        GunDictionary.Add(17, gun17);
        GunDictionary.Add(18, gun18);
        Debug.Log("GunsLoaded");
    }

    void GameOver()
    {
        SceneManager.LoadScene(2);
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
            //_goNewRoom.transform.GetChild(4).gameObject.SetActive(false);
        }

        else if (_boolPosNeg1 && !_boolPosNeg2)
        {
            _intDir1 = 14.1f;
            _intDir2 = -14.1f;
            v3NewRoomPos = new Vector3(_trRoom.position.x + _intDir1, _trRoom.position.y, _trRoom.position.z + _intDir2);
            GameObject _goNewRoom = Instantiate(goNewRoom, v3NewRoomPos, _trRoom.rotation);
            // _goNewRoom.transform.GetChild(3).gameObject.SetActive(false);
        }

        else if (!_boolPosNeg1 && _boolPosNeg2)
        {
            _intDir1 = -14.1f;
            _intDir2 = 14.1f;
            v3NewRoomPos = new Vector3(_trRoom.position.x + _intDir1, _trRoom.position.y, _trRoom.position.z + _intDir2);
            GameObject _goNewRoom = Instantiate(goNewRoom, v3NewRoomPos, _trRoom.rotation);
            // _goNewRoom.transform.GetChild(2).gameObject.SetActive(false);
        }

        else if (!_boolPosNeg1 && !_boolPosNeg2)
        {
            _intDir1 = -14.1f;
            _intDir2 = -14.1f;
            v3NewRoomPos = new Vector3(_trRoom.position.x + _intDir1, _trRoom.position.y, _trRoom.position.z + _intDir2);
            GameObject _goNewRoom = Instantiate(goNewRoom, v3NewRoomPos, _trRoom.rotation);
            //_goNewRoom.transform.GetChild(1).gameObject.SetActive(false);
        }

        ////////////////////////////

    }

    public void SetLeftGun(GunType GunPickup) {
        txtLeftGunName.text = GunPickup.strGTGunName;
        if (GunPickup.boolGTCorrupted)
        {
            intPCHealth = intPCHealth - 20;
            if (intPCHealth <= 0)
            {
                GameOver();
            }
        }
    }

    public void SetRightGun(GunType GunPickup)
    {
        txtRightGunName.text = GunPickup.strGTGunName;
        if (GunPickup.boolGTCorrupted)
        {
            intPCHealth = intPCHealth - 20;
            if (intPCHealth <= 0)
            {
                GameOver();
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
        intPCMaxArmor = intPCMaxArmor + (intArmorBoosts * (intPCMaxArmor / 5));
        intPCArmor = intPCMaxArmor;
    }

    public void SpeedBoost()
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

    public void PCGrenHit()
    {
        if (intPCArmor > 50)
        {
            intPCArmor = intPCArmor - 50;
            imgPCArmor.rectTransform.sizeDelta = new Vector2(intPCArmor, 22);
        }

        else
        {
            int intDamRemainder = 50 - intPCArmor;
            intPCArmor = 0;
            intPCHealth = intPCHealth - intDamRemainder;
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

    public void StartButtonClick() {
        canMainUI.gameObject.SetActive(true);
        Destroy(canStartScreen);
    }

    public void LoreButtonClick()
    {
        canLore.gameObject.SetActive(true);
    }

    public void BackButtonClick()
    {
        canLore.gameObject.SetActive(false);
    }

}