using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ExitButton : MonoBehaviour
{
    [SerializeField] private Button button;
    
    private void Start()
    {
        button.onClick.AddListener(Exit);
    }

    private void Exit()
    {
        Application.Quit();
    }
}
