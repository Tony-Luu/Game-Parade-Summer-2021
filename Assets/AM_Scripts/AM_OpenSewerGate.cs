using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class AM_OpenSewerGate : MonoBehaviour
{
    public GameObject dirt;
    private AM_DigUpKey digUpScript;

    [SerializeField] private GameObject sewerGrate;

    [SerializeField] private Text sewerEntranceLockedText;

    // Start is called before the first frame update
    void Start()
    {
        digUpScript = dirt.GetComponentInChildren<AM_DigUpKey>();
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            if (digUpScript.keyCount > 0)
            {
                HingeJoint hinge = sewerGrate.GetComponent<HingeJoint>();

                JointLimits limits = hinge.limits;
                limits.min = 108.0f;
                limits.min++;
                limits.bounciness = 0.0f;
                limits.bounceMinVelocity = 0;
                limits.max = 108.0f;
                hinge.limits = limits;
                hinge.useLimits = true;

                transform.GetComponent<BoxCollider>().enabled = false;
                sewerGrate.GetComponent<Rigidbody>().isKinematic = false;

                digUpScript.keyCount--;
                digUpScript.foundKeyText.SetActive(false);
            }
            else
            {
                sewerEntranceLockedText.gameObject.SetActive(true);
            }
        }
    }

    private void OnCollisionExit(Collision collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            sewerEntranceLockedText.gameObject.SetActive(false);
        }
    }
}
