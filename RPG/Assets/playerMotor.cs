using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
public class playerMotor : MonoBehaviour
{
    private Vector3 velocity = Vector3.zero;

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

    //Run every phisics iteration
    private void FixedUpdate()
    {
        PerformMovement();
    }

    //Perform movement based on velocity variable
    void PerformMovement()
    {
        if (velocity !=Vector3.zero)
        {
            rb.MovePosition(rb.position+velocity*Time.deltaTime);
        }
    }

}
