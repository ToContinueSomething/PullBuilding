using System;
using UnityEngine;

[RequireComponent(typeof(PlayerMovement))]
[RequireComponent(typeof(PlayerShooting))]
public class Player : MonoBehaviour
{
    [SerializeField] private HooksList _hooksList;
    [SerializeField] private Stat _pullForce;

    private PlayerMovement _movement;
    private PlayerShooting _shooting;

    public Action Started;
    public Action<int> Moved;
    public Action MoveCompleted;
    public Action<Vector3> Shooted;

    private void Awake()
    {
        _movement = GetComponent<PlayerMovement>();
        _shooting = GetComponent<PlayerShooting>();
    }

    private void OnEnable()
    {
        _shooting.Collided += OnCollided;
        _movement.EndMoved += OnEndMoved;
        _movement.Moved += OnMoved;
        _hooksList.Finished += OnHooksFinished;
    }

    private void OnDisable()
    {
        MoveCompleted?.Invoke();

        _movement.Moved -= OnMoved;
        _shooting.Collided -= OnCollided;
        _movement.EndMoved -= OnEndMoved;
        _hooksList.Finished -= OnHooksFinished;
    }

    private void OnCollided(Vector3 point) => Shooted?.Invoke(point);

    private void OnMoved() => Moved?.Invoke(_pullForce.Value);

    private void OnHooksFinished() => Started?.Invoke();

    private void OnEndMoved()
    {
        enabled = false;
    }
}
