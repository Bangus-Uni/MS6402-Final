using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pickup : MonoBehaviour
{

    public int intGunType;
    // Start is called before the first frame update
    void Start()
    {
        intGunType = Mathf.RoundToInt(Random.Range(0.5f, 4.5f));
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
