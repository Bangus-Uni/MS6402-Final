using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pickup : MonoBehaviour
{

    public int intPickupGunType;
    // Start is called before the first frame update
    void Start()
    {
        intPickupGunType = Mathf.RoundToInt(Random.Range(1.5f, 4.5f));
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.GetComponentInChildren<Gun>())
        {
            Debug.Log("Triggered");
            other.gameObject.GetComponentsInChildren<Gun>()[0].intGunType = intPickupGunType;
            other.gameObject.GetComponentsInChildren<Gun>()[1].intGunType = intPickupGunType;
            Destroy(gameObject);
        }
    }
}
