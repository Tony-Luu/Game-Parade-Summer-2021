using System;
using UnityEngine;

public class TL_JumpCharacter : MonoBehaviour
{
    public float JumpHeight;
    private Collider CharacterCollider;
    private Rigidbody CharacterRigidbody;
    private bool readyToJump;


    void Start()
    {
        //Obtain the collider and rigidbody
        CharacterCollider = GetComponent<Collider>();
        CharacterRigidbody = GetComponent<Rigidbody>();
    }

    void Jump()
    {
        //If the player presses the jump button and if the character is touching the ground
        if (Input.GetKeyDown(KeyCode.Space) && IsCharacterTouchingTheGround())
        {
            readyToJump = true;
        }
    }

    //Checks if the character is touching the ground or not
    public bool IsCharacterTouchingTheGround()
    {
        return Physics.Raycast(transform.position, Vector3.down, CharacterCollider.bounds.extents.y + 0.1f, 3);
    }

    void JumpVelocity()
    {
        if (readyToJump)
        {
            CharacterRigidbody.velocity = Vector3.zero;
            CharacterRigidbody.velocity = Vector3.up * JumpHeight;
            readyToJump = false;
        }

        if (CharacterRigidbody.velocity.y != 0f)
        {
            foreach (Transform Child in transform)
            {
                Rigidbody ChildRigidbody = Child.GetComponent<Rigidbody>();
                if (ChildRigidbody != null)
                {
                    ChildRigidbody.velocity = CharacterRigidbody.velocity;
                }
            }
        }
        else
        {
            foreach (Transform Child in transform)
            {
                Rigidbody ChildRigidbody = Child.GetComponent<Rigidbody>();
                if (ChildRigidbody != null)
                {
                    TL_ArmFollow ArmFollowScript = Child.GetComponent<TL_ArmFollow>();
                    ChildRigidbody.position = new Vector3(ChildRigidbody.position.x, ArmFollowScript.ReturnOriginalPosition().y, ChildRigidbody.position.z);
                    ChildRigidbody.velocity = Vector3.zero;
                }
            }
        }
    }

    void FixedUpdate()
    {
        JumpVelocity();
    }

    private void LateUpdate()
    {
        Jump();
    }
}
