using UnityEngine;

public class TL_AttachableArm : MonoBehaviour
{
    private Animator ArmAnimator;
    private Rigidbody ArmRigidbody;
    private Rigidbody PlayerRigidbody;
    private BoxCollider ArmCollider;
    private GameObject Player;
    private TL_MoveCharacter MoveCharacterScript;
    private TL_RopeSwing RopeSwingScript;
    private TL_ArmFollow ArmFollowScript;
    private TL_ArmMovement ArmMovementScript;

    
    void Start()
    {
        ArmAnimator = GetComponent<Animator>();
        ArmCollider = GetComponent<BoxCollider>();
        ArmRigidbody = GetComponent<Rigidbody>();

        Player = GameObject.FindGameObjectWithTag("Player");
        PlayerRigidbody = Player.GetComponent<Rigidbody>();
        MoveCharacterScript = Player.GetComponent<TL_MoveCharacter>();
        RopeSwingScript = Player.GetComponent<TL_RopeSwing>();
        ArmFollowScript = GetComponent<TL_ArmFollow>();
        ArmMovementScript = GetComponent<TL_ArmMovement>();
    }

    public void EnableArmCollider()
    {
        ArmCollider.enabled = true;
    }

    public void DisableArmCollider()
    {
        ArmCollider.enabled = false;
    }

    void SetParentForAttachableArm(Transform Parent)
    {
        Destroy(ArmFollowScript);
        Destroy(ArmAnimator);
        transform.SetParent(Parent);
    }

    void SetHingeJointAnchor(HingeJoint HingeAnchor, Vector3 AnchorPosition, Vector3 ConnectedAnchorPosition)
    {
        HingeAnchor.autoConfigureConnectedAnchor = false;
        HingeAnchor.anchor = AnchorPosition;
        HingeAnchor.connectedAnchor = ConnectedAnchorPosition;
    }

    bool IsJointAttachedToHingeJoint(Rigidbody Joint)
    {
        GameObject[] GrabbableJoints = GameObject.FindGameObjectsWithTag("Grabbable");
        foreach (GameObject GrabbedObject in GrabbableJoints)
        {
            if (GrabbedObject.GetComponent<HingeJoint>() != null)
            {
                Rigidbody GrabbedJoint = GrabbedObject.GetComponent<HingeJoint>().connectedBody;
                if (GrabbedJoint == Joint)
                {
                    return true;
                }
            }
        }
        return false;
    }

    void OnCollisionEnter(Collision collision)
    {
        if (collision.transform.CompareTag("Wall") && transform.parent != null)
        {
            SetParentForAttachableArm(null);
            ArmRigidbody.constraints = RigidbodyConstraints.FreezeAll;
            ArmRigidbody.isKinematic = true;
        }

        if (collision.transform.CompareTag("Grabbable"))
        {
            HingeJoint GrabbableHingeJoint = collision.gameObject.GetComponent<HingeJoint>();
            if (GetComponent<HingeJoint>() == null)
            {
                HingeJoint ArmHingeJoint = gameObject.AddComponent<HingeJoint>();
                Rigidbody JointRigidbody = collision.gameObject.GetComponent<Rigidbody>();

                if (!IsJointAttachedToHingeJoint(JointRigidbody))
                {
                    SetParentForAttachableArm(null);
                    transform.localRotation = Quaternion.identity;
                    ArmRigidbody.velocity = Vector3.zero;
                    PlayerRigidbody.velocity = Vector3.zero;

                    ArmRigidbody.useGravity = true;
                    ArmHingeJoint.connectedBody = JointRigidbody;
                    SetHingeJointAnchor(ArmHingeJoint, new Vector3(0f, 1f, 0f), new Vector3(0f, -1f, 0f));
                }
                else
                {
                    HingeJoint PlayerHingeJoint = transform.parent.gameObject.AddComponent<HingeJoint>();
                    PlayerHingeJoint.connectedBody = JointRigidbody;
                    SetHingeJointAnchor(PlayerHingeJoint, new Vector3(0f, 0f, 0f), new Vector3(-5f, -2f, -5f));
                    MoveCharacterScript.enabled = false;
                    RopeSwingScript.enabled = true;
                }
            }

            if (GrabbableHingeJoint == null)
            {
                collision.collider.enabled = false;
            }
            transform.tag = "Grabbable";
        }
    }

}
