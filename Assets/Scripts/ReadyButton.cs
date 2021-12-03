using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ReadyButton : MonoBehaviour
{
    [SerializeField] private Button button;
    [SerializeField] private Camera mainCamera;
    [SerializeField] private Camera auxiliaryCamera;
    [SerializeField] private GameObject player;
    [SerializeField] private GameObject upscreen;

    private void Start()
    {
        button.onClick.AddListener(OnClick);
    }

    private void OnClick()
    {
        mainCamera.gameObject.SetActive(true);
        auxiliaryCamera.gameObject.SetActive(false);
        player.SetActive(true);
        upscreen.SetActive(true);
    }
}
