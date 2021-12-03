using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Assistant : MonoBehaviour
{
    [SerializeField] private List<Transform> waypoints;
    [SerializeField] private float speed;

    private bool _playerInRange;
    private Transform _currentWaypoint;
    private IEnumerator<Transform> _waypoints;

    private void Start()
    {
        _waypoints = waypoints.GetEnumerator();
        _waypoints.MoveNext();
        _currentWaypoint = _waypoints.Current;
    }

    private void Update()
    {
        if(_currentWaypoint is null)
            return;
        
        if(_playerInRange)
            transform.Translate(Time.deltaTime * speed * (_currentWaypoint.position - transform.position).normalized);
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
            _playerInRange = true;
    }

    private void OnCollisionEnter(Collision other)
    {
        if (other.gameObject.CompareTag("Waypoint"))
            _currentWaypoint = _waypoints.MoveNext() ? _waypoints.Current : null;
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player"))
            _playerInRange = false;
    }
}
