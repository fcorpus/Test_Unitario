using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SujetoMovement : MonoBehaviour
{
    public float Speed = 3.0f;
    public float RotationSpeed = 64.0f;
    public float Jump = 3.0f;
    public Transform CameraTransform;
    public float maxLookAngle = 80f;

    private float verticalRotation = 0f;
    private Rigidbody Physics;

    // Start is called before the first frame update
    void Start()
    {
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;

        Physics = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        //mov
        float horizontal = Input.GetAxis("Horizontal");
        float vertical = Input.GetAxis("Vertical");

        transform.Translate(new Vector3(horizontal, 0.0f, vertical) * Time.deltaTime * Speed);
        
        //Camara
        float rotationY = Input.GetAxis("Mouse X");
        transform.Rotate(new Vector3(0.0f, rotationY * Time.deltaTime * RotationSpeed, 0.0f));

        float rotationX = Input.GetAxis("Mouse Y");
        verticalRotation -= rotationX * Time.deltaTime * RotationSpeed;
        verticalRotation = Mathf.Clamp(verticalRotation, -maxLookAngle, maxLookAngle);
        CameraTransform.localEulerAngles = new Vector3(verticalRotation,0.0f,0.0f);

        //Salto
        if (Input.GetKeyDown(   KeyCode.Space))
        {
            Physics.AddForce(new Vector3(0, Jump, 0), ForceMode.Impulse);
        }
    }
}
