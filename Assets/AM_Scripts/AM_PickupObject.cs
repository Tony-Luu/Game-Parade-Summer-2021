using UnityEngine;

public class AM_PickupObject : MonoBehaviour
{
    public bool isShovelInHand = false;
    private AudioSource PickupShovelSound;


    void Start()
    {
        PickupShovelSound = GetComponent<AudioSource>();
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Player") && GameObject.FindGameObjectWithTag("ObjectHolder").transform.childCount == 0)
        {
            transform.SetParent(GameObject.FindGameObjectWithTag("ObjectHolder").transform);
            transform.position = GameObject.FindGameObjectWithTag("ObjectHolder").transform.position;
            transform.rotation = GameObject.FindGameObjectWithTag("ObjectHolder").transform.rotation;

            if (gameObject.CompareTag("Shovel"))
            {
                PickupShovelSound.Play();
                isShovelInHand = true;
            }
        }
    }
}
