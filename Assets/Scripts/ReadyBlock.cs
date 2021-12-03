using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System.Linq;

public class ReadyBlock : MonoBehaviour
{
    [SerializeField] private GameObject block;
    [SerializeField] private List<Toggle> checkboxes;

    private bool _shouldCheck = true;

    private void Update()
    {
        if(_shouldCheck == false)
            return;
        Debug.Log(checkboxes.All(x => x.isOn));
        
        if(checkboxes.All(x => x.isOn))
        {
            block.SetActive(true);
            _shouldCheck = false;
        }
    }
}
