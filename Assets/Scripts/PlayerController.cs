using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Networking.Types;
using UnityEngine.SceneManagement;

public class PlayerController : MonoBehaviour, IDamagable
{
    private CharacterController _player;
    [SerializeField] private float movementSpeed;
    [SerializeField] private float rotationSensibility;
    [SerializeField] private Camera playerCamera;
    private float life = 100;
    private float maxLife = 100;
    [SerializeField] private Canvas barraDeVidaUI;
    [SerializeField] private Image barraDeVida;
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
        ApplyGravityWhenNeeded();
        Lifebaractualization();
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

    private void ApplyGravityWhenNeeded()
    {
        if(transform.position.y > 0.96f)
        {
            Vector3 moventY = new Vector3 (0, -5.5f, 0);
            _player.Move(moventY*Time.deltaTime);
        }
    }

    public void GetDamage(float damage)
    {
        life-= damage;
        if(life < 0)
        {
            SceneManager.LoadScene("DefeatMenu");
        }
    }

    public void Lifebaractualization()
    {
        barraDeVida.fillAmount = life/maxLife;
    }
}
