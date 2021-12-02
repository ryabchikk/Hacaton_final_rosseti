using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WindController : MonoBehaviour
{
    [SerializeField] private ConstantForce wind;
    [Range(1, 3)] [SerializeField] private float pulseMultiplier;
    
    [SerializeField] private Vector3 windDirection;
    [SerializeField] private bool _isPulsing;
    

    private void Start()
    {
        Init(windDirection, _isPulsing);
    }

    public void Init(Vector3 windDirection, bool isPulsing)
    {
        wind.force = windDirection;
        _isPulsing = isPulsing;
        if (isPulsing)
            StartCoroutine(Pulse());
    }

    private IEnumerator Pulse()
    {
        while (_isPulsing)
        {
            var waitTime = Random.Range(10, 30);
            Debug.Log($"Waiting for {waitTime} seconds");
            yield return new WaitForSeconds(waitTime);
            waitTime = Random.Range(3, 7);
            Debug.Log($"Increasing wind and waiting for {waitTime} seconds");
            wind.force *= pulseMultiplier;
            yield return new WaitForSeconds(waitTime);
            Debug.Log("Decreasing wind");
            wind.force /= pulseMultiplier;
        }
    }
}
