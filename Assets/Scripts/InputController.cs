using System;
using UnityEngine;
using UnityEngine.SceneManagement;

public class InputController : MonoBehaviour
{
    [SerializeField] private Rigidbody _rigidbody;
    [SerializeField] private float mouseSensitivity;
    [Range(1, 30)] [SerializeField] private float speed;
    [Range(1, 90)] [SerializeField] private int rotationAngle;
    [Range(0, 10)] [SerializeField] private float rotationSpeed;

    private Vector3 _movement;
    private Vector3 _rotation;

    private void Start()
    {
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
    }

    private void Update()
    {
        if (Input.GetKey(KeyCode.Escape))
        {
            Cursor.lockState = CursorLockMode.None;
            Cursor.visible = true;
            return;
        }

        if (Input.GetKey(KeyCode.Mouse1))
        {
            Cursor.lockState = CursorLockMode.Locked;
            Cursor.visible = false;
        }
        
        _movement = Vector3.zero;
        var rotatingX = false;
        var rotatingZ = false;
        var deltaRotationX = 0f;
        var deltaRotationZ = 0f;
        
        if(Input.GetKey(KeyCode.D))
        {
            rotatingX = true;
            _movement += Vector3.forward;
            deltaRotationX = rotationAngle * Time.deltaTime * rotationSpeed;
        }
        else if(Input.GetKey(KeyCode.A))
        {
            rotatingX = true;
            _movement += Vector3.back;
            deltaRotationX = -rotationAngle * Time.deltaTime * rotationSpeed;
        }
        
        if(Input.GetKey(KeyCode.W))
        {
            rotatingZ = true;
            _movement += Vector3.left;
            deltaRotationZ = rotationAngle * Time.deltaTime * rotationSpeed;
        }
        else if(Input.GetKey(KeyCode.S))
        {
            rotatingZ = true;
            _movement += Vector3.right;
            deltaRotationZ = -rotationAngle * Time.deltaTime * rotationSpeed;
        }
        
        if(Input.GetKey(KeyCode.Space))
        {
            _movement += Vector3.up;
        }
        else if(Input.GetKey(KeyCode.LeftControl) || Input.GetKey(KeyCode.RightControl))
        {
            _movement += Vector3.down;
        }
        
        _movement *= speed;
        
        
        var rotation = Input.GetAxis("Mouse X") * Time.deltaTime * mouseSensitivity;
        transform.Rotate(Vector3.up, rotation, Space.World);
        
        if(Math.Abs(_rotation.x) < rotationAngle)
        {
            _rotation.x += deltaRotationX;
            transform.rotation *= Quaternion.Euler(new Vector3(deltaRotationX, 0, 0));
        }
        
        if(Math.Abs(_rotation.z) < rotationAngle)
        {
            _rotation.z += deltaRotationZ;
            transform.rotation *= Quaternion.Euler(new Vector3(0, 0, deltaRotationZ));
        }

        var deltaRotation = Vector3.zero;
        if(rotatingX == false)
        {
            if (Math.Abs(_rotation.x) > 0.5)
                deltaRotation -= new Vector3(rotationAngle * Math.Sign(_rotation.x) * Time.deltaTime * rotationSpeed, 0,
                    0);
            else
                deltaRotation.x = -_rotation.x;
        }

        if(rotatingZ == false)
        {
            if (Math.Abs(_rotation.z) > 0.5)
                deltaRotation -= new Vector3(0, 0,
                    rotationAngle * Math.Sign(_rotation.z) * Time.deltaTime * rotationSpeed);
            else
                deltaRotation.z = -_rotation.z;
        }

        _rotation += deltaRotation;
        transform.rotation *= Quaternion.Euler(deltaRotation);
    }

    private void FixedUpdate()
    {
        _rigidbody.AddRelativeForce(_movement);
    }

    private void OnCollisionEnter(Collision other)
    {
        SceneManager.LoadScene(1);
    }
}
