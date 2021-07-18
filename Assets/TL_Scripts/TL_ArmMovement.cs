using UnityEngine;

public class TL_ArmMovement : MonoBehaviour
{
    public GameObject LeftArm;
    public GameObject RightArm;
    public Animator LeftArmAnimator;
    public Animator RightArmAnimator;


    void MoveArms()
    {
        if (Input.GetMouseButtonDown(0) && LeftArmAnimator != null)
        {
            LeftArmAnimator.SetTrigger("MoveLeftArm");
        }

        if (Input.GetMouseButtonDown(1) && RightArmAnimator != null)
        {
            RightArmAnimator.SetTrigger("MoveRightArm");
        }
    }

    void RemoveArms()
    {
        if (LeftArm != null && LeftArm.transform.parent == null)
        {
            LeftArm = null;
            LeftArmAnimator = null;
        }
        else if (RightArm != null && RightArm.transform.parent == null)
        {
            RightArm = null;
            RightArmAnimator = null;
        }
    }

    void Update()
    {
        MoveArms();
        RemoveArms();
    }

}
