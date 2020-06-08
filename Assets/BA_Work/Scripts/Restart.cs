using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Restart : MonoBehaviour
{

    private void Update()
    {
        if (Input.GetKey(KeyCode.Space))
        {
            Debug.Log("Restarting");
            System.Diagnostics.Process.Start(Application.dataPath.Replace("_Data", ".exe")); //new program
            Application.Quit(); //kill current process
        }
    }
}
