using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AM_DigUpKey : MonoBehaviour
{
    private string keyName = "Door Key";
    public bool keyObtained = false;
    private bool isDigging = false;
    private bool playerOnMud = false;

    void Update()
    {
        if (playerOnMud && !keyObtained)
        {
            if (Input.GetKeyDown(KeyCode.E))
            {
                isDigging = true;
                print("Digging...");
            }
        }

        if (!keyObtained && isDigging)
        {
            keyObtained = true;
            print("Key Obtained: " + keyName);
            isDigging = false;
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            playerOnMud = true;
        }
    }
}
