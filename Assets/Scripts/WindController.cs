using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WindController : MonoBehaviour
{
    [SerializeField] private GlobalWind globalWind;
    [SerializeField] private new ConstantForce constantForce;
    
    private void Awake()
    {
        globalWind.WindChanged += ChangeWind;
    }

    private void ChangeWind(Vector3 direction)
    {
        constantForce.force = direction;
    }
}
