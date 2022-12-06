using System;
using Sources.Interfaces;
using UnityEngine;

[RequireComponent(typeof(PlayerAnimator))]
[RequireComponent(typeof(Player))]
public class PlayerShooting : MonoBehaviour, IShootable
{
    [SerializeField] private ParticleSystem _fire;
    [SerializeField] private float _delay;

    private PlayerAnimator _animator;
    private Player _player;

    private Camera _camera;
    private bool _canShoot;

    private float _elapsedTime;

    public event Action<Vector3> Collided;
    public event Action ShootStopped;

    private void Awake()
    {
        _canShoot = true;
        _camera = Camera.main;
        _animator = GetComponent<PlayerAnimator>();
        _player = GetComponent<Player>();
    }

    private void OnEnable() => _player.Started += OnMoveStarted;

    private void OnDisable() => _player.Started -= OnMoveStarted;

    private void Start() => _elapsedTime = _delay;

    private void Update()
    {
        _elapsedTime += Time.deltaTime;

        if (_elapsedTime >= _delay)
        {
            _canShoot = true;
            _elapsedTime = 0;
        }
    }

    private void OnMoveStarted() => ShootStopped?.Invoke();

    public void Shoot(Vector3 startPosition)
    {
        if (_canShoot == false)
            return;

        if (TryGetCollisionPoint(out Vector3 point,startPosition))
        {
            _animator.PlayShot();
            _fire.Play();
            Collided?.Invoke(point);
            _canShoot = false;
        }
    }

    private bool TryGetCollisionPoint(out Vector3 point, Vector3 startPosition)
    {
        point = default;

        Ray ray = _camera.ScreenPointToRay(startPosition);

        if (Physics.Raycast(ray, out RaycastHit hit))
        {
            point = hit.point;
            return true;
        }

        return false;
    }
}
