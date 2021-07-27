using System.Collections;
using UnityEngine;

public class AM_KillPlayer : MonoBehaviour
{
    [SerializeField] private Transform checkpoint;
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            print("die");
            other.gameObject.GetComponent<TL_MoveCharacter>().enabled = false;
            other.gameObject.GetComponent<TL_JumpCharacter>().enabled = false;
            other.gameObject.transform.position = new Vector3(checkpoint.transform.position.x, checkpoint.transform.position.y, 
                checkpoint.transform.position.z);
            StartCoroutine(WaitBeforeMoving());
        }
    }

    IEnumerator WaitBeforeMoving()
    {
        yield return new WaitForSeconds(0.5f);
        GameObject.FindGameObjectWithTag("Player").GetComponent<TL_MoveCharacter>().enabled = true;
        GameObject.FindGameObjectWithTag("Player").GetComponent<TL_JumpCharacter>().enabled = true;
    }
}
