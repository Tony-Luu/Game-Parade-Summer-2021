using UnityEngine;

public class TL_MoveCharacter : MonoBehaviour
{
    public float MoveSpeed;
    public float MoveMultiplier;
    private float HorizontalMovement;
    private float VerticalMovement;
    private Vector3 MoveDirection;
    private Rigidbody CharacterRigidbody;



    void Awake()
    {
        CharacterRigidbody = GetComponent<Rigidbody>();
    }

    void MovementInput()
    {
        HorizontalMovement = Input.GetAxisRaw("Horizontal");
        VerticalMovement = Input.GetAxisRaw("Vertical");
        MoveDirection = new Vector3(HorizontalMovement, 0f, VerticalMovement);
    }

    void Update()
    {
        MovementInput();
    }

    void MovePlayer(Vector3 Direction)
    {
        Direction = CharacterRigidbody.rotation * Direction;
        CharacterRigidbody.MovePosition(CharacterRigidbody.position + Direction * MoveSpeed * Time.fixedDeltaTime);

        foreach (Transform Child in transform)
        {
            Rigidbody ChildRigidbody = Child.GetComponent<Rigidbody>();
            if(ChildRigidbody != null)
            {
                ChildRigidbody.MovePosition(ChildRigidbody.position + Direction * MoveSpeed * Time.fixedDeltaTime);
            }
        }
    }

    void FixedUpdate()
    {
        MovePlayer(MoveDirection);
    }

}
