﻿using UnityEngine;

[RequireComponent(typeof(playerMotor))]
public class playerController : MonoBehaviour
{

    [SerializeField]
    private float speed = 5f;
    [SerializeField]
    private float lookSensitivity = 3f;

    private playerMotor motor;

    private void Start()
    {
        motor = GetComponent<playerMotor>();
    }

    private void Update()
    {
        //calculate movement velocity as 3D vector
        float _XMovement = Input.GetAxisRaw("Horizontal");
        float _ZMovement = Input.GetAxisRaw("Vertical");

        Vector3 _movHorizontal = transform.right * _XMovement;
        Vector3 _movVertical = transform.forward * _ZMovement;

        //final movement vector
        Vector3 _velocity = (_movHorizontal + _movVertical).normalized * speed;

        //apply movement
        motor.Move(_velocity);


        //calculate rotation as a 3D vector/ turning arround
        float _yRot = Input.GetAxisRaw("Mouse X");

        Vector3 _rotation = new Vector3(0f, _yRot, 0f) * lookSensitivity;

        //apply rotation
        motor.Rotate(_rotation);

        //calculate camera as a 3D vector/ turning arround
        float _xRot = Input.GetAxisRaw("Mouse Y");

        Vector3 _cameraRotation = new Vector3(_xRot,0f, 0f) * lookSensitivity;

        //apply rotation
        motor.RotateCamera(_cameraRotation);

    }
}