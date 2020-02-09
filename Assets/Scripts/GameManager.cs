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

    public int intTotalCorruption = 0;
    public int intLACorruption = 0;
    public int intLLCorruption = 0;
    public int intRACorruption = 0;
    public int intRLCorruption = 0;
    public int intCorruptionThreshold = 50;
    public int intMaxCorrupted = 100;

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
    public Text txtCurrentZone;


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

    public Dictionary<int, GunType> GunDictionary = new Dictionary<int, GunType>();
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
        gun8 = new GunType("Ass Grabber", "Gun 8", 1, HomingMissile, 15, 2f, true, 20);
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
    }

    // Update is called once per frame
    void Update()
    {
        
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

    public void SetLeftGun(GunType GunPickup) {
        txtLeftGunName.text = GunPickup.strGTGunName;
        if (GunPickup.boolGTCorrupted)
        {
            intLACorruption = GunPickup.intGTCorruption;
            intTotalCorruption = intLACorruption + intLLCorruption + intRACorruption + intRLCorruption;
        }   
    }

    public void SetRightGun(GunType GunPickup)
    {
        txtRightGunName.text = GunPickup.strGTGunName;
        if (GunPickup.boolGTCorrupted)
        {
            intRACorruption = GunPickup.intGTCorruption;
            intTotalCorruption = intLACorruption + intLLCorruption + intRACorruption + intRLCorruption;
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