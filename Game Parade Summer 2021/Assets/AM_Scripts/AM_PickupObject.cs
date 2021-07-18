using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AM_PickupObject : MonoBehaviour
{
    public bool isShovelInHand = false;

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.E) && GameObject.FindGameObjectWithTag("Box").transform.parent != null)
        {
            GameObject.FindGameObjectWithTag("Box").transform.parent = null;
            GameObject.FindGameObjectWithTag("Box").GetComponent<Rigidbody>().isKinematic = false;
            GameObject.FindGameObjectWithTag("Box").GetComponent<BoxCollider>().isTrigger = false;
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Player") && GameObject.FindGameObjectWithTag("ObjectHolder").transform.childCount == 0)
        {
            transform.SetParent(GameObject.FindGameObjectWithTag("ObjectHolder").transform);
            transform.position = GameObject.FindGameObjectWithTag("ObjectHolder").transform.position;
            transform.rotation = GameObject.FindGameObjectWithTag("ObjectHolder").transform.rotation;

            if (this.gameObject.CompareTag("Shovel"))
            {
                isShovelInHand = true;
            }
        }
    }
}
