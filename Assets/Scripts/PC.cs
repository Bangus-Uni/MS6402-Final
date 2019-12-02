using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PC : MonoBehaviour
{
    public float flMoveSpeed = 5;
    private Rigidbody rbPC;

    private Vector3 v3MoveInput;
    private Vector3 v3MoveVelocity;

    private Camera camMainCam;

    public Gun LeftGun;
    public Gun RightGun;
    void Start() {
        rbPC = GetComponent<Rigidbody>();
        camMainCam = FindObjectOfType<Camera>();
    }

    void Update() {
        v3MoveInput = new Vector3(Input.GetAxisRaw("Horizontal"), 0f, Input.GetAxisRaw("Vertical"));
        v3MoveVelocity = v3MoveInput * flMoveSpeed;

        Ray rayCamRay = camMainCam.ScreenPointToRay(Input.mousePosition);
        Plane plGround = new Plane(Vector3.up, Vector3.zero);
        float flRayLength;

        if (plGround.Raycast(rayCamRay, out flRayLength)) {

            Vector3 v3PointToLook = rayCamRay.GetPoint(flRayLength);
            Debug.DrawLine(rayCamRay.origin, v3PointToLook, Color.blue);

            transform.LookAt(new Vector3(v3PointToLook.x, transform.position.y, v3PointToLook.z));
        }

        if (Input.GetMouseButton(0)) {
            LeftGun.boolIsFiring = true;
        }
        else {
            LeftGun.boolIsFiring = false;
        }

        if (Input.GetMouseButton(1))
        {
            RightGun.boolIsFiring = true;
        }
        else
        {
            RightGun.boolIsFiring = false;
        }
    }

    private void FixedUpdate() {
        rbPC.velocity = v3MoveVelocity;
    }



}
