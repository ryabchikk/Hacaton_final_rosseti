using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class Upscreen : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI text;

    private void OnEnable()
    {
        StartCoroutine(Enabled());
    }

    private IEnumerator Enabled()
    {
        for (int i = 0; i < 100; i++)
        {
            text.alpha += 0.01f;
            yield return new WaitForSeconds(0.01f);
        }

        yield return new WaitForSeconds(5);
        
        for (int i = 0; i < 100; i++)
        {
            text.alpha -= 0.01f;
            yield return new WaitForSeconds(0.01f);
        }

        text.gameObject.SetActive(false);
    }
}
