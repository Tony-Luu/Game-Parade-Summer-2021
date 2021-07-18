using UnityEngine;

public class TL_RopeSwing : MonoBehaviour
{
    public float SwingForce;
    private Rigidbody PlayerRigidbody;
    private TL_MoveCharacter MoveCharacterScript;


    void Start()
    {
        PlayerRigidbody = GetComponent<Rigidbody>();        
        MoveCharacterScript = GetComponent<TL_MoveCharacter>();
    }

    void SwingRope()
    {
        float VerticalInput = Input.GetAxisRaw("Vertical");
        PlayerRigidbody.AddForce(transform.forward * VerticalInput * SwingForce, ForceMode.Acceleration);
    }

    void RemoveHingeJointFromArms()
    {
        foreach (Transform Child in transform)
        {
            HingeJoint ChildHingeJoint = Child.GetComponent<HingeJoint>();
            if (ChildHingeJoint != null)
            {
                Destroy(ChildHingeJoint);
            }
        }
    }

    void JumpOffRope()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            HingeJoint PlayerHingeJoint = GetComponent<HingeJoint>();
            Destroy(PlayerHingeJoint);
            RemoveHingeJointFromArms();
            MoveCharacterScript.enabled = true;
            enabled = false;
        }
    }

    void Update()
    {
        JumpOffRope();
    }

    void FixedUpdate()
    {
        SwingRope();
    }

}
