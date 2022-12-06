using System;
using UnityEngine;

[RequireComponent(typeof(HookMovement))]
public class Hook : MonoBehaviour
{
    private HookMovement _hookMovement;
    private bool _isReached = false;
    private Player _player;

    public event Action<Vector3> Reached;
    public event Action<Vector3> PlayerShooted;

    public bool IsReached => _isReached;

    private void Awake()
    {
        _hookMovement = GetComponent<HookMovement>();
    }

    private void OnEnable()
    {
        _hookMovement.Reached += OnReached;
    }

    private void OnDisable()
    {
        _hookMovement.Reached -= OnReached;
    }

    public void Init(Player player)
    {
        if (player == null)
            throw new NullReferenceException(nameof(_player));

        _player = player;
        _player.Shooted += OnShooted;
    }

    private void OnShooted(Vector3 collisionPoint)
    {
        PlayerShooted?.Invoke(collisionPoint);
    }

    private void OnReached(Vector3 target)
    {
        if (_player != null)
            _player.Shooted -= OnShooted;

        _isReached = true;
        Reached?.Invoke(target);
    }
}
