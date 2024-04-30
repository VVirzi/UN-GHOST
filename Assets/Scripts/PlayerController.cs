using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    private CharacterController _player;
    [SerializeField] private float movementSpeed;
    [SerializeField] private float rotationSensibility;
    [SerializeField] private Camera playerCamera;
    private float cameraVerticalAngle;
    
    void Start()
    {
        Cursor.lockState = CursorLockMode.Locked;
    }

    private void Awake()
    {
        _player = GetComponent<CharacterController>();
    }
    void Update()
    {
        Rotationlook();
        MoveCharacter();
    }

    private void MoveCharacter()
    {
        var horizontal = Input.GetAxisRaw("Horizontal");
        var vertical = Input.GetAxisRaw("Vertical");
        Vector3 movementInput = new Vector3(horizontal, 0, vertical);
        movementInput = transform.TransformDirection(movementInput).normalized;
        _player.Move(movementInput * (Time.deltaTime * movementSpeed));

    }

    private void Rotationlook()
    {
        var horizontalRotation = Input.GetAxisRaw("Mouse X") * rotationSensibility * Time.deltaTime;
        var verticalRotation = Input.GetAxisRaw("Mouse Y") * rotationSensibility* Time.deltaTime;

        transform.Rotate(0f, horizontalRotation, 0f);

        cameraVerticalAngle += verticalRotation;
        cameraVerticalAngle = Mathf.Clamp(cameraVerticalAngle, -40, 20);

       
        playerCamera.transform.localRotation = Quaternion.Euler(-cameraVerticalAngle,0f,0f);
    }
}
