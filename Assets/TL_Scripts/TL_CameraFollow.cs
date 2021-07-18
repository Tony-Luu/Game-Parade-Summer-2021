using UnityEngine;

public class TL_CameraFollow : MonoBehaviour
{
    public float MouseSensitivity;
    private float xRotation = 0f;
    private Transform Player;
    

    void Start()
    {
        Player = transform.parent;
    }

    void RotateCamera()
    {
        float MouseX = Input.GetAxis("Mouse X") * MouseSensitivity * Time.deltaTime;
        float MouseY = Input.GetAxis("Mouse Y") * MouseSensitivity * Time.deltaTime;

        xRotation -= MouseY;
        xRotation = Mathf.Clamp(xRotation, -90f, 90f);
        transform.localRotation = Quaternion.Euler(xRotation, 0f, 0f);

        Player.Rotate(Vector3.up * MouseX);
    }

    void Update()
    {
        RotateCamera();
    }

}
