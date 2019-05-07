using UnityEngine;

[RequireComponent(typeof(playerMotor))]
public class playerController : MonoBehaviour
{

    [SerializeField]
    private float speed = 5f;
    [SerializeField]
    private float looksensitivity = 3f;
    [SerializeField]
    private float thrusterForce = 1000f;

    private playerMotor motor;

    private void Start()
    {
        motor = GetComponent<playerMotor>();
    }

    private void Update()
    {
        float xMove = Input.GetAxisRaw("Horizontal");
        float zmove = Input.GetAxisRaw("Vertical");

        Vector3 movHorizontal = transform.right * xMove;
        Vector3 movVertical = transform.forward * zmove;


        // final movement
        Vector3 _velocity = (movHorizontal + movVertical).normalized * speed;

        //apply movement

        motor.Move(_velocity);

        float _yRot = Input.GetAxis("Mouse X");

        Vector3 _Rotation = new Vector3(0f, _yRot, 0f) * looksensitivity;

        motor.Rotate(_Rotation);

        // camera rot calc
        motor.Move(_velocity);

        float _xRot = Input.GetAxis("Mouse Y");

        float _CameraRotationX = _xRot * looksensitivity;


        // apply camera rot
        motor.RotateCamera(_CameraRotationX);

        Vector3 _thrusterForce = Vector3.zero;

        //thruster force

        if (Input.GetButton("Jump"))
        {
            _thrusterForce = Vector3.up * thrusterForce;
            
        }

        //thrusterForce apply

        motor.ApplyThruster(_thrusterForce);

    }

}