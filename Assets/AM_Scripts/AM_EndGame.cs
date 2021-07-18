using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class AM_EndGame : MonoBehaviour
{
    public GameObject mud;
    private AM_DigUpKey digUpScript;

    private void Start()
    {
        digUpScript = mud.GetComponentInChildren<AM_DigUpKey>();
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            if(digUpScript.keyCount > 0)
            {
                SceneManager.LoadScene(2);
            }
            
        }
    }
}
