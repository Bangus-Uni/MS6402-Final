using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PC : MonoBehaviour
{

    private float flMoveSpeed = 0;

    [SerializeField]
    float flSprintSpeed = 8f;
    [SerializeField]
    float flWalkSpeed = 4.5f;
    Vector3 v3Forward, v3Right, v3Heading;


    // Start is called before the first frame update
    void Start()
    {
        v3Forward = Camera.main.transform.forward;
        v3Forward.y = 0;
        v3Forward = Vector3.Normalize(v3Forward);

        v3Right = Quaternion.Euler(new Vector3(0, 90, 0)) * v3Forward;
    }

    // Update is called once per frame
    void Update()
    {
        flMoveSpeed = flWalkSpeed;

        if (Input.GetKey(KeyCode.LeftShift))
        {
            flMoveSpeed = flSprintSpeed;
        }

        if (Input.GetAxis("VerticalKey") < 0 || Input.GetAxis("VerticalKey") > 0 || Input.GetAxis("HorizontalKey") < 0 || Input.GetAxis("HorizontalKey") > 0)
        {
            Move();
        }

    }

    void Move()
    {
        Vector3 _v3Direction = new Vector3(Input.GetAxis("HorizontalKey"), 0, Input.GetAxis("VerticalKey"));
        Vector3 _v3RightMovement = v3Right * flMoveSpeed * Time.deltaTime * Input.GetAxis("HorizontalKey");
        Vector3 _v3UpMovement = v3Forward * flMoveSpeed * Time.deltaTime * Input.GetAxis("VerticalKey");

        v3Heading = Vector3.Normalize(_v3RightMovement + _v3UpMovement);

        transform.forward = v3Heading;
        transform.position += _v3RightMovement;
        transform.position += _v3UpMovement;
    }

}
