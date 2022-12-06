using System.Collections.Generic;
using System;
using UnityEngine;

public class HooksList : MonoBehaviour
{
    [SerializeField] private Player _player;
    [SerializeField] private ParticleSystem _ring;
    [SerializeField] private Transform _rocketPoint;
    [SerializeField] private Counter _hookCounter;
    [SerializeField] private List<Hook> _hooks;

    private Queue<Hook> _activeHooks;
    private Hook _currentHook;
    private Transform _currentParent;
    private int _countEnabledHooks = 1;

    public event Action Finished;

    private void Awake()
    {
        _currentParent = transform;
        _countEnabledHooks = _hookCounter.Value;

        int maxCountEnabledHooks = _hookCounter.MaxValue;

        if (maxCountEnabledHooks > _hooks.Count)
            throw new IndexOutOfRangeException(nameof(_hooks));

        DisableHooks();
        AddLimitedCountHooks(_countEnabledHooks);
    }

    private void OnEnable()
    {
        foreach (var hook in _activeHooks)
            hook.Reached += OnReached;

    }

    private void OnDisable()
    {
        foreach (var hook in _activeHooks)
            hook.Reached -= OnReached;

    }

    private void Start()
    {
        _currentHook = _activeHooks.Dequeue();
        _currentHook.Init(_player);
    }

    private void Update()
    {
        if (_currentHook.IsReached == false)
            return;

        var nextHook = GetNextHook(_currentHook);

        if (nextHook != null)
        {
            _currentHook = nextHook;
            _currentHook.Init(_player);
        }

        if (_activeHooks.Count <= 0 && _currentHook.IsReached)
        {
            Finished?.Invoke();
            enabled = false;
        }
    }

    private void AddLimitedCountHooks(int count)
    {
        if (count > _hooks.Count)
            throw new InvalidOperationException();

        _activeHooks = new Queue<Hook>();

        for (int i = 0; i < count; i++)
        {
            _hooks[i].gameObject.SetActive(true);
            _activeHooks.Enqueue(_hooks[i]);
        }
    }

    private Hook GetNextHook(Hook currentHook)
    {
        return currentHook.IsReached && _activeHooks.Count > 0 ? _activeHooks.Dequeue() : null;
    }

    private void DisableHooks()
    {
        if (_hooks == null)
            throw new NullReferenceException(nameof(_hooks));

        foreach (var hook in _hooks)
            hook.gameObject.SetActive(false);
    }

    private void OnReached(Vector3 target)
    {
        _ring.transform.position = target;
        _ring.Play();
    }
}
