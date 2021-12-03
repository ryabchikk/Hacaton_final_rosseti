using System;
using System.Collections;
using TMPro;
using UnityEngine;
using UnityEngine.UI;
using Random = UnityEngine.Random;

public enum WindDirection
{
    South = 0,
    East,
    West, 
    North
}

public class GlobalWind : MonoBehaviour
{
    public event Action<Vector3> WindChanged;
    
    [Range(1, 3)] [SerializeField] private float pulseMultiplier;
    [SerializeField] private Toggle pulsingToggle;
    [SerializeField] private Toggle toggle;
    [SerializeField] private Slider windStrengthSlider;
    [SerializeField] private TMP_Dropdown directionDropdown;
    
    private Vector3 windDirection;

    private void Start()
    {
        windDirection = DirectionToVector((WindDirection) directionDropdown.value);
        
        if(toggle.isOn == false)
            return;
        
        if (pulsingToggle.isOn)
            StartCoroutine(Pulse());
        else
            WindChanged?.Invoke(windDirection * windStrengthSlider.value);
        
        toggle.onValueChanged.AddListener(OnWindChanged);
        pulsingToggle.onValueChanged.AddListener(OnPulseChanged);
        windStrengthSlider.onValueChanged.AddListener(OnSliderChanged);
        directionDropdown.onValueChanged.AddListener(OnDirectionChanged);
    }

    private IEnumerator Pulse()
    {
        while (pulsingToggle.isOn)
        {
            var w = windDirection * windStrengthSlider.value;
            WindChanged?.Invoke(windDirection * windStrengthSlider.value);
            Debug.Log($"Wind set to ({w.x}, {w.y}, {w.z})");
            yield return new WaitForSeconds(Random.Range(10, 30));
            w = windDirection * (windStrengthSlider.value * pulseMultiplier);
            WindChanged?.Invoke(windDirection * (windStrengthSlider.value * pulseMultiplier));
            Debug.Log($"Wind set to ({w.x}, {w.y}, {w.z})");
            yield return new WaitForSeconds(Random.Range(3, 7));
        }
    }

    private void OnWindChanged(bool state)
    {
        Debug.Log("Toggle changed");
        WindChanged?.Invoke(state ? windDirection * windStrengthSlider.value : Vector3.zero);
    }

    private void OnSliderChanged(float value)
    {
        if (toggle.isOn == false)
            return;
        
        Debug.Log("Slider changed");
        WindChanged?.Invoke(windDirection * windStrengthSlider.value);
    }

    private void OnPulseChanged(bool state)
    {
        if(toggle.isOn == false)
            return;
        
        if (state)
            StartCoroutine(Pulse());
        else
            StopCoroutine(Pulse());
    }
    
    private void OnDirectionChanged(int value)
    {
        windDirection = DirectionToVector((WindDirection) value);

        if(toggle.isOn == false)
            return;
        
        WindChanged?.Invoke(windDirection * windStrengthSlider.value);
    }

    private Vector3 DirectionToVector(WindDirection direction)
    {
        return direction switch
        {
            WindDirection.South => Vector3.back,
            WindDirection.East => Vector3.right,
            WindDirection.West => Vector3.left,
            WindDirection.North => Vector3.forward
        };
    }
}
