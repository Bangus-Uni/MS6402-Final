using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pickup : MonoBehaviour
{
    public GameManager GM;
    public GunType GunPickup;
    // Start is called before the first frame update
    void Start()
    {
        GM = FindObjectOfType<GameManager>();
        Debug.Log("Length Of Dictionary: " + GM.GunDictionary.Count);
        //GunPickup = GM.GunDictionary.Count;
    }

    // Update is called once per frame
    void Update()
    {

    }

    private void OnTriggerStay(Collider other)
    {
        if (other.gameObject.GetComponentInChildren<Gun>())
        {
            Debug.Log("Triggered");
            if (Input.GetKey(KeyCode.E))
            {
                Debug.Log("Active - Left");
                //other.gameObject.GetComponentInChildren<LeftGun>().intGunType = intPickupGunType;
                Destroy(gameObject);
            }
            else if (Input.GetKey(KeyCode.R))
            {
                Debug.Log("Active - Right");
                //other.gameObject.GetComponentInChildren<RightGun>().intGunType = intPickupGunType;
                Destroy(gameObject);
            }
        }
    }
}
