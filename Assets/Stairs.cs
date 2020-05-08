using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Stairs : MonoBehaviour {
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "PC")
        {
            SceneManager.LoadScene(1);
        }
    }
}
