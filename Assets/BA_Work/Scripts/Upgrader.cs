using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Upgrader : MonoBehaviour
{
    public GameManager GM;

    public int intUpgradeType;

    public bool boolActivated = false;
    // Start is called before the first frame update
    void Start()
    {
        GM = FindObjectOfType<GameManager>();
        intUpgradeType = Mathf.RoundToInt(Random.Range(0.5f, 3.5f));
        Debug.Log("Upgrade Type: " + intUpgradeType);
    }

    private void OnTriggerEnter(Collider other)
    {
        Debug.Log("Upgrade Type: " + intUpgradeType);
        if (
            !boolActivated && 
            other.gameObject.tag == "PC" &&
            GM.intTotalCorruption < GM.intCorruptionThreshold
           )
        {
            if (intUpgradeType == 1) GM.ArmorBoost();
            if (intUpgradeType == 2) GM.HealthBoost();
            if (intUpgradeType == 3) GM.SpeedBoost();

            Debug.Log("Upgrader Activated");
            boolActivated = true;
            Destroy(gameObject);
        }

        else if (
            !boolActivated &&
            other.gameObject.tag == "PC" &&
            GM.intTotalCorruption > GM.intCorruptionThreshold
           )
        {
            Debug.Log("ERROR - TOO CORRUPTED - ERROR");
        }
    }
}
