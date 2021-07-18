using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AM_PickupObject : MonoBehaviour
{
    public bool isShovelInHand = false;

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
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
