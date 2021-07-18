using UnityEngine;

public class TL_ArmFollow : MonoBehaviour
{
    private Vector3 Offset;
    private Vector3 OriginalPosition;
    private GameObject Player;
    

    void Awake()
    {
        Player = GameObject.FindGameObjectWithTag("Player");
        OriginalPosition = transform.position;
        Offset = transform.position - Player.transform.position;
    }
    
    public Vector3 ReturnOffset()
    {
        return Offset;
    }

    public Vector3 ReturnOriginalPosition()
    {
        return OriginalPosition;
    }

}
