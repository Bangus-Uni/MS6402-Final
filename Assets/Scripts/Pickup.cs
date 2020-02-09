using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pickup : MonoBehaviour
{
    public GameManager GM;
    public int intPickupGunRand;
    public GunType GunPickup;
    // Start is called before the first frame update
    void Start()
    {
        GM = FindObjectOfType<GameManager>();
        intPickupGunRand = Mathf.RoundToInt(Random.Range(1.5f, GM.GunDictionary.Count + 0.5f));
        Debug.Log("Length Of Dictionary: " + GM.GunDictionary.Count);
        GunPickup = GM.GunDictionary[7];
        Debug.Log("Got Gun: " + GunPickup.strGTGunName);
    }

    // Update is called once per frame
    void Update()
    {

    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "PC")
        {
            GM.Popup(GunPickup);
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.tag == "PC")
        {
            GM.Popup(GunPickup);
        }
    }

    private void OnTriggerStay(Collider other)
    {
        if (other.gameObject.GetComponentInChildren<Gun>())
        {
            Debug.Log("Triggered");
            if (Input.GetKey(KeyCode.E))
            {
                Debug.Log("Active - Left");
                other.gameObject.GetComponentInChildren<LeftGun>().SetGun(GunPickup);
                GM.Popup(GunPickup);
                Destroy(gameObject);
            }
            else if (Input.GetKey(KeyCode.R))
            {
                Debug.Log("Active - Right");
                other.gameObject.GetComponentInChildren<RightGun>().SetGun(GunPickup);
                GM.Popup(GunPickup);
                Destroy(gameObject);
            }
        }
    }
}
