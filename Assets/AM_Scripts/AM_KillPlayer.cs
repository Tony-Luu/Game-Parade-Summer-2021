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
            other.gameObject.GetComponent<playermovementscript>().enabled = false;
            other.gameObject.transform.position = new Vector3(checkpoint.transform.position.x, checkpoint.transform.position.y, 
                checkpoint.transform.position.z);
            StartCoroutine(WaitBeforeMoving());
        }
    }

    IEnumerator WaitBeforeMoving()
    {
        yield return new WaitForSeconds(0.5f);
        GameObject.FindGameObjectWithTag("Player").GetComponent<playermovementscript>().enabled = true;
    }
}
