using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LookAtPlayer : MonoBehaviour
{
    [SerializeField] private Transform player;
    
    private void Update()
    {
        transform.LookAt(player);
        transform.Rotate(Vector3.up, 180);
    }
}
