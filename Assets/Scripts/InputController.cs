using UnityEngine;

public class InputController : MonoBehaviour
{
    [SerializeField] private Rigidbody _rigidbody;
    [Range(1, 30)] [SerializeField] private float speed;
    [SerializeField] private float mouseSensitivity;

    private Vector3 _movement;

    private void Start()
    {
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
    }

    private void Update()
    {
        _movement = Vector3.zero;
        
        if(Input.GetKey(KeyCode.W))
            _movement += Vector3.forward;
        else if(Input.GetKey(KeyCode.S))
            _movement += Vector3.back;
        
        if(Input.GetKey(KeyCode.A))
            _movement += Vector3.left;
        else if(Input.GetKey(KeyCode.D))
            _movement += Vector3.right;
        
        if(Input.GetKey(KeyCode.Space))
            _movement += Vector3.up;
        else if(Input.GetKey(KeyCode.LeftControl) || Input.GetKey(KeyCode.RightControl))
            _movement += Vector3.down;
        
        _movement *= speed;
        
        var rotation = Input.GetAxis("Mouse X") * Time.deltaTime * mouseSensitivity;
        transform.Rotate(Vector3.up * rotation);
    }

    private void FixedUpdate()
    {
        _rigidbody.AddRelativeForce(_movement);
    }
}
