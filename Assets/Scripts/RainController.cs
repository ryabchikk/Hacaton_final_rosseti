using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class RainController : MonoBehaviour
{
    [SerializeField] private ParticleSystem rain;
    [SerializeField] private Toggle rainToggle;
    
    private void Start()
    {
        if(rainToggle.isOn)
            rain.Play();
        else
            rain.Stop();
        
        rainToggle.onValueChanged.AddListener(OnToggleChanged);
    }

    private void OnToggleChanged(bool state)
    {
        if(state)
            rain.Play();
        else
            rain.Stop();
    }
}
