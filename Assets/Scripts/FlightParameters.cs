using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class FlightParameters
{
    private const float CoordMultiplier = 0.577f;

    public static float GetCurrentAltitude(Transform transform)
    {
        return transform.position.y * CoordMultiplier;
    }

    public static float GetCurrentSpeed(Rigidbody rigidbody)
    {
        return rigidbody.velocity.magnitude * CoordMultiplier;
    }
}
