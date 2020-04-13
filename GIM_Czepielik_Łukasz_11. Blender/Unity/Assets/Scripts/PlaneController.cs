using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlaneController : MonoBehaviour
{
    public int maximumRotationAngle = 90;
    public int minimumRotationAngle = -90;
    public int maximumSpeed = 1000;
    public int minimumSpeed = 100;

    private float _speed;
    public int speedIncrease = 10;
    public int speedDecrease = -10;

    public int zRotationForce = 1;
    public int yRotationForce = 1;

    public int takeOffSpeed = 200;
    public int lift = 100;
    public int minimumLift = 50;

    private Rigidbody _rigidbody;


    // Start is called before the first frame update
    void Start()
    {
        _rigidbody = GetComponent<Rigidbody>();
        InvokeRepeating("Speed", .1f, .1f);
    }

    void Speed()
    {
        if (Input.GetKey(KeyCode.Space))
        {
            Mathf.Repeat(1, Time.time);
            _speed = _speed + speedIncrease;
        }
        if (Input.GetKey(KeyCode.LeftAlt))
        {
            Mathf.Repeat(1, Time.time);
            _speed = _speed - speedDecrease;
        }
    }

    // Update is called once per frame
    void Update()
    {
        float magnitude = _rigidbody.velocity.magnitude;
        _rigidbody.AddRelativeForce(0, 0, -_speed);

        float horizontalMove = (Input.GetAxis("Horizontal")) * zRotationForce;
        _rigidbody.AddRelativeTorque(0, 0, horizontalMove * (magnitude / 100));

        float verticalMove = (Input.GetAxis("Vertical")) * yRotationForce;
        _rigidbody.AddRelativeTorque(verticalMove * (magnitude / 100), 0, 0);

        if (maximumSpeed <= _speed)
        {
            _speed = maximumSpeed;
        }
        else
        {
            _speed = _speed;
        }

        if (minimumSpeed >= _speed)
        {
            _speed = minimumSpeed;
        }
        else
        {
            _speed = _speed;
        }

        if (_speed < takeOffSpeed)
        {
            _rigidbody.AddForce(0, minimumLift, 0);
        }
        else if (_speed > takeOffSpeed)
        {
            _rigidbody.AddForce(0, lift, 0);
        }

        if (_rigidbody.rotation.z > maximumRotationAngle)
        {
            _rigidbody.MoveRotation(new Quaternion(_rigidbody.rotation.x,
                _rigidbody.rotation.y, maximumRotationAngle, _rigidbody.rotation.w));
        }
        else if (_rigidbody.rotation.z < minimumRotationAngle)
        {
            _rigidbody.MoveRotation(new Quaternion(_rigidbody.rotation.x,
       _rigidbody.rotation.y, minimumRotationAngle, _rigidbody.rotation.w));
        }
    }
}
