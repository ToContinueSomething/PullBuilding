using System;
using System.Collections;
using UnityEngine;

public class HookMovement : MonoBehaviour
{
    [SerializeField] private float _speed;

    private Hook _hook;
    private bool _isReached = false;
    private Vector3 _target; 

    public event Action<Vector3> Reached;

    private void Awake()
    {
        _hook = GetComponent<Hook>();
    }

    private void OnEnable()
    {
        _hook.PlayerShooted += OnPlayerShooted;
    }

    private void OnDisable()
    {
        _hook.PlayerShooted -= OnPlayerShooted;
    }

    private void OnTriggerEnter(Collider other)
    {
        if (_isReached)
            return;

        if (other.transform.TryGetComponent<BuildingPart>(out BuildingPart buildingPart))
        {
            transform.SetParent(buildingPart.transform);
            Reached?.Invoke(_target);
            _isReached = true;
        }
    }

    private void OnPlayerShooted(Vector3 point)
    {
        _target = point;
        StartCoroutine(Move(point));
    }

    private IEnumerator Move(Vector3 target)
    {
        while (_isReached == false)
        {
            var currentPosition = transform.position;
            var direction = currentPosition - target;
            
            currentPosition = Vector3.MoveTowards(currentPosition, target, _speed * Time.deltaTime);
            transform.position = currentPosition;
            transform.LookAt(direction,-transform.forward);

            yield return null;
        }
    }
}