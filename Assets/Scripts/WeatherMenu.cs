using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class WeatherMenu : MonoBehaviour
{
    [SerializeField] private GameObject panel;
    [SerializeField] private GameObject button;
    public void OpenWeatherSettings() 
    {
        Time.timeScale = 0f;
        panel.SetActive(true);
        button.SetActive(false);
    }
    public void CloseWeatherSettings()
    {
        Time.timeScale = 1f;
        panel.SetActive(false);
        button.SetActive(true);
    }
}
