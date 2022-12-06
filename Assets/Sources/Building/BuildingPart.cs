using System;
using UnityEngine;
using Vector3 = UnityEngine.Vector3;

[RequireComponent(typeof(Rigidbody))]
[RequireComponent(typeof(BuildingPartFallHandler))]
public class BuildingPart : MonoBehaviour
{
    private int _reward = 1;

    private BuildingPartFallHandler _handler;
    private Rigidbody _rigidbody;

    private bool _canDown;

    private readonly Vector3 _velocityDown = new Vector3(0f, 0.1f, 0.1f);

    public event Action<int> Ruined;

    public bool CanDown => _canDown;

    private void Awake()
    {
        _rigidbody = GetComponent<Rigidbody>();
        _rigidbody.isKinematic = true;
        _handler = GetComponent<BuildingPartFallHandler>();
        _canDown = false;
    }

    private void OnEnable()
    {
        _handler.Dropped += OnDropped;
    }

    private void OnDisable()
    {
        _handler.Dropped -= OnDropped;
    }

    private void OnTriggerEnter(Collider other)
    {
        if (_canDown)
            return;

        if (other.TryGetComponent<Hook>(out Hook hook))
            _canDown = true;

    }

    private void OnDropped()
    {
        _canDown = false;
        Ruined?.Invoke(_reward);
        enabled = false;
    }

    public void Enable()
    {
        _rigidbody.isKinematic = false;
    }

    public void Fall(int force)
    {
        var velocity = _rigidbody.velocity;
        velocity -= _velocityDown * force * Time.deltaTime;
        _rigidbody.velocity = velocity;
    }
}
