using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class AM_DigUpKey : MonoBehaviour
{
    private string keyName = "Door Key";
    public bool keyObtained = false;
    public bool keySpawned = false;
    private bool playerOnMud = false;
    public int keyCount = 0;

    private bool enter = false;

    public GameObject key;

    public GameObject foundKeyText;
    public GameObject diggingText;
    public GameObject pickUpKeyText;

    void Update()
    {
        DigAndGrabKey();
    }

    private void DigAndGrabKey()
    {
        if (playerOnMud && !keyObtained)
        {
            if (Input.GetKeyDown(KeyCode.E))
            {
                if (enter == false)
                    StartCoroutine(DiggingTimer());

            }

            if (keySpawned && !keyObtained && playerOnMud)
            {
                pickUpKeyText.SetActive(true);
                if (Input.GetKeyDown(KeyCode.G))
                {
                    key.SetActive(false);
                    keyObtained = true;
                    keyCount++;
                    foundKeyText.SetActive(true);
                    pickUpKeyText.SetActive(false);
                    print("Key Obtained: " + keyName);
                }
            }
        }
    }

    IEnumerator DiggingTimer()
    {
        enter = true;
        print("Digging...");
        diggingText.SetActive(true);
        yield return new WaitForSeconds(3.0f);
        print("Digging done");
        diggingText.SetActive(false);

        key.SetActive(true);
        keySpawned = true;
        enter = false;
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            playerOnMud = true;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            pickUpKeyText.SetActive(false);
            playerOnMud = false;
        }
    }
}
