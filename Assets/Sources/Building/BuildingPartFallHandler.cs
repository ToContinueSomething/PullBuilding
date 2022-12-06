using System;
using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
public class BuildingPartFallHandler : MonoBehaviour
{
    private Rigidbody _rigidbody;
    private readonly Vector3 _maxVelocityDown = new Vector3(0f, 0.5f, 0.5f);
    
    public event Action Dropped;

    private void Start()
    {
        _rigidbody = GetComponent<Rigidbody>();
    }

    private void Update()
    {
        if (_rigidbody.velocity.z >= _maxVelocityDown.z || _rigidbody.velocity.y >= _maxVelocityDown.y)
        {
            Dropped?.Invoke();
            _rigidbody.velocity = Vector3.zero;
            enabled = false;
        }
    }
}