using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AM_KillPlayer : MonoBehaviour
{
    [SerializeField] private Transform checkpoint;

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            print("die");
            other.gameObject.transform.position = checkpoint.transform.position;
        }
    }
}
