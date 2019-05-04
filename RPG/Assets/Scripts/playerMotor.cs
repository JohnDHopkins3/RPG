﻿using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
public class playerMotor : MonoBehaviour
{
    [SerializeField]
    private Camera cam;

    private Vector3 velocity = Vector3.zero;
    private Vector3 rotation = Vector3.zero;
    private float cameraRotationX = 0f;
    private float currentCameraRotX = 0f;
    private Vector3 thrusterForce = Vector3.zero;

    [SerializeField]
    private float cameraRotationLimit = 85f;

    private Rigidbody rb;

    private void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    //gets a movement method
    public void Move(Vector3 _velocity)
    {
        velocity = _velocity;
    }

    //gets a rotational vector
    public void Rotate(Vector3 _rotation)
    {
        rotation = _rotation;
    }

    //gets a rotational vector for the camera
    public void RotateCamera(float _cameraRotationX)
    {
        cameraRotationX = _cameraRotationX;
    }

    //get a force vector for our thruster
    public void ApplyThruster(Vector3 _thrusterForce)
    {
        thrusterForce = _thrusterForce;
    }

    //Run every phisics iteration
    private void FixedUpdate()
    {
        PerformMovement();
        PerformRotation();
    }

    //Perform movement based on velocity variable
    void PerformMovement()
    {
        if (velocity !=Vector3.zero)
        {
            rb.MovePosition(rb.position+velocity*Time.fixedDeltaTime);
        }

        if (thrusterForce!=Vector3.zero)
        {
            rb.AddForce(thrusterForce * Time.fixedDeltaTime, ForceMode.Acceleration);
        }
    }

    //perform rotation
    void PerformRotation()
    {
        rb.MoveRotation(rb.rotation*Quaternion.Euler(rotation));
        if (cam!=null)
        {
            //set our rotation and clamp it (set camera rotation limits)
            currentCameraRotX -= cameraRotationX;
            currentCameraRotX = Mathf.Clamp(currentCameraRotX, -cameraRotationLimit, cameraRotationLimit);

            //apply rotation to the transform of our camera
            cam.transform.localEulerAngles = new Vector3(currentCameraRotX, 0f, 0f);
        }
    }

}
