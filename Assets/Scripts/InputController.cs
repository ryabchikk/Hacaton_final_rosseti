using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InputController : MonoBehaviour
{
    [SerializeField] private Rigidbody _rigidbody;
    [Range(1, 30)] [SerializeField] private float speed;
    
    private void Update()
    {
        var movement = Vector3.zero;
        
        if(Input.GetKey(KeyCode.W))
            movement += Vector3.forward;
        if(Input.GetKey(KeyCode.S))
            movement += Vector3.back;
        if(Input.GetKey(KeyCode.A))
            movement += Vector3.left;
        if(Input.GetKey(KeyCode.D))
            movement += Vector3.right;
        if(Input.GetKey(KeyCode.Space))
            movement += Vector3.up;
        if(Input.GetKey(KeyCode.LeftControl) || Input.GetKey(KeyCode.RightControl))
            movement += Vector3.down;

        movement *= speed;
        _rigidbody.AddForce(movement);
    }
}
