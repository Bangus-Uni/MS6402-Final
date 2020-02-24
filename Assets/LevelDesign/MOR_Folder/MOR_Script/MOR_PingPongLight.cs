using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MOR_PingPongLight : MonoBehaviour
{
    public float speed = 1;
    private Light lightlight;

    // Start is called before the first frame update
    void Start()
    {
        lightlight = GetComponent<Light>();
    }

    // Update is called once per frame
    void Update()
    {
        PingPongIntesity();
    }

    void PingPongIntesity()
    {
        lightlight.intensity = Mathf.PingPong(Time.time * speed, 1);
    }
}

