using UnityEngine;

public class TL_RecoverArms : MonoBehaviour
{
    public GameObject LeftArmPrefab;
    public GameObject RightArmPrefab;
    public GameObject Player;
    private TL_ArmMovement ArmMovementScript;


    void Start()
    {
        ArmMovementScript = Player.GetComponent<TL_ArmMovement>();
    }

    void ObtainDetachableArms()
    {
        if (Input.GetKeyDown(KeyCode.E) && Vector3.Distance(Player.transform.position, transform.position) < 2f)
        {
            TL_ArmMovement ArmScript = Player.GetComponent<TL_ArmMovement>();
            if (ArmScript.LeftArm == null)
            {
                GameObject LeftArmClone = Instantiate(LeftArmPrefab, new Vector3(-0.642f, 0.067f, 0.167f), Quaternion.identity);
                LeftArmClone.transform.eulerAngles = new Vector3(180f, 0f, 0f);
                LeftArmClone.transform.SetParent(Player.transform);                
                ArmMovementScript.LeftArm = LeftArmClone;
                ArmMovementScript.LeftArmAnimator = LeftArmClone.GetComponent<Animator>();
            }

            if (ArmScript.RightArm == null)
            {
                GameObject RightArmClone = Instantiate(RightArmPrefab, new Vector3(0.642f, 0.067f, 0.167f), Quaternion.identity);
                RightArmClone.transform.eulerAngles = new Vector3(0f, 0f, 180f);
                RightArmClone.transform.SetParent(Player.transform);                
                ArmMovementScript.RightArm = RightArmClone;
                ArmMovementScript.RightArmAnimator = RightArmClone.GetComponent<Animator>();
            }
        }
    }

    void Update()
    {
        ObtainDetachableArms();
    }

}
