using System;
using System.Collections;
using System.Collections.Generic;
using System.Globalization;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class Speedometer : MonoBehaviour
{
    [SerializeField] private Rigidbody player;
    [SerializeField] private TextMeshProUGUI text;

    private void Start()
    {
        StartCoroutine(UpdateSpeed());
    }

    private IEnumerator UpdateSpeed()
    {
        while (true)
        {
            var speed = Math.Round(FlightParameters.GetCurrentSpeed(player), 3);
            text.text = speed.ToString(CultureInfo.InvariantCulture);
            yield return new WaitForSeconds(0.1f);
        }
    }
}
