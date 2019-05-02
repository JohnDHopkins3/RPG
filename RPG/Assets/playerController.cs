using UnityEngine;

[RequireComponent(typeof(playerMotor))]
public class playerController : MonoBehaviour
{

    [SerializeField]
    private float speed = 5f;

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

    }
}
