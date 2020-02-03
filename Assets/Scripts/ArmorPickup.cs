using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ArmorPickup : MonoBehaviour
{
    public GameManager GM;
    public int intArmorValue = 25;
    // Start is called before the first frame update
    void Start()
    {
        GM = FindObjectOfType<GameManager>();
    }

    // Update is called once per frame
    void Update()
    {

    }

    private void OnTriggerStay(Collider other)
    {
        if (other.tag == "PC")
        {
            if (Input.GetKey(KeyCode.E))
            {
                GM.AddArmor(intArmorValue);
                Destroy(gameObject);
            }
        }
    }
}
