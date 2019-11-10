using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    public float flSpeed = 8.5f;
    public float flDestroyTime = 5f;

    // Start is called before the first frame update
    void Start()
    {
        Destroy(gameObject, flDestroyTime);
    }

    // Update is called once per frame
    void Update()
    {
        transform.Translate(Vector3.forward * flSpeed * Time.deltaTime);
    }
}
