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
            transform.SetParent(other.gameObject.transform.GetChild(0).GetChild(0));
            transform.position = other.gameObject.transform.GetChild(0).GetChild(0).transform.position;
            transform.rotation = other.gameObject.transform.GetChild(0).GetChild(0).transform.rotation;

            if (this.gameObject.CompareTag("Shovel"))
            {
                isShovelInHand = true;
            }
        }
    }
}
