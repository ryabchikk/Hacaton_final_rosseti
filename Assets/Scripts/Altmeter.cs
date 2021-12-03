using System;
using System.Collections;
using System.Collections.Generic;
using System.Globalization;
using TMPro;
using UnityEngine;

public class Altmeter : MonoBehaviour
{
    [SerializeField] private Transform player;
    [SerializeField] private TextMeshProUGUI text;

    private void Start()
    {
        StartCoroutine(UpdateAltitude());
    }

    private IEnumerator UpdateAltitude()
    {
        while (true)
        {
            var alt = Math.Round(FlightParameters.GetCurrentAltitude(player), 3);
            text.text = alt.ToString(CultureInfo.InvariantCulture);
            yield return new WaitForSeconds(0.1f);
        }
    }
}
