using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Door : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        if(other.tag=="Player")
        {
            SceneManager.LoadScene("Layer1");
        }
    }
}
