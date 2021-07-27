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
    public GameObject startDiggingText;

    public GameObject shovel;
    private AM_PickupObject pickUpScript;

    public GameObject player;

    private AudioSource DiggingSound;

    private void Start()
    {
        pickUpScript = shovel.GetComponent<AM_PickupObject>();
        DiggingSound = GetComponent<AudioSource>();
    }

    void Update()
    {
        DigAndGrabKey();
    }

    private void DigAndGrabKey()
    {
        if (playerOnMud && !keyObtained && pickUpScript.isShovelInHand)
        {
            if (Input.GetKeyDown(KeyCode.E))
            {
                startDiggingText.SetActive(false);
                if (enter == false)
                    StartCoroutine(DiggingTimer());

            }

            if (keySpawned && !keyObtained && playerOnMud)
            {
                pickUpKeyText.SetActive(true);
                startDiggingText.SetActive(false);
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
        // Start digging
        enter = true;
        DiggingSound.Play();
        print("Digging...");
        player.GetComponent<TL_MoveCharacter>().enabled = false;
        player.GetComponent<TL_JumpCharacter>().enabled = false;
        diggingText.SetActive(true);

        yield return new WaitForSeconds(3.0f);

        // Finish digging
        print("Digging done");
        player.GetComponent<TL_MoveCharacter>().enabled = true;
        player.GetComponent<TL_JumpCharacter>().enabled = true;
        DiggingSound.Stop();
        diggingText.SetActive(false);

        // Drop shovel after use
        GameObject.FindGameObjectWithTag("ObjectHolder").transform.GetChild(0).GetComponent<Rigidbody>().isKinematic = false;
        GameObject.FindGameObjectWithTag("ObjectHolder").transform.GetChild(0).GetComponent<BoxCollider>().isTrigger = false;
        GameObject.FindGameObjectWithTag("ObjectHolder").transform.GetChild(0).parent = null;

        // Spawn a key
        key.SetActive(true);
        keySpawned = true;
        enter = false;
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            if (!keyObtained && pickUpScript.isShovelInHand)
            {
                print("Start digging");
                startDiggingText.SetActive(true);
            }
            playerOnMud = true;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            pickUpKeyText.SetActive(false);
            startDiggingText.SetActive(false);
            playerOnMud = false;
        }
    }
}
