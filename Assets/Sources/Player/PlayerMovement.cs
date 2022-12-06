using System;
using System.Collections;
using UnityEngine;
using DG.Tweening;
using Sources;
using Sources.Interfaces;

[RequireComponent(typeof(Player))]
[RequireComponent(typeof(PlayerRotater))]
public class PlayerMovement : MonoBehaviour,IMovable
{
    [SerializeField] private float _moveSpeed = 0.5f;
    [SerializeField] private FinishRing _finishRing;

    private Player _player;
    private PlayerRotater _playerRotate;

    public event Action Moved;
    public event Action EndMoved;

    private void Awake()
    {
        _playerRotate = GetComponent<PlayerRotater>();
        _player = GetComponent<Player>();
    }

    private void OnEnable()
    {
        _player.Started += OnStarted;
    }

    private void OnDisable()
    {
        EndMoved?.Invoke();
        _player.Started -= OnStarted;
    }

    private void Update()
    {
        if (transform.position.z == _finishRing.transform.position.z)
            enabled = false;
    }

    private void OnStarted() => _playerRotate.Look(_finishRing.transform.position);

    public void Move()
    {
        StartCoroutine(MoveTo());
    }

    private IEnumerator MoveTo()
    {
        var position = transform.position;
        var targetPoint = new Vector3(_finishRing.transform.position.x, position.y, _finishRing.transform.position.z);

        while (enabled)
        {
            position = Vector3.MoveTowards(position, targetPoint, _moveSpeed * Time.deltaTime);
            transform.position = position;
            Moved?.Invoke();
            yield return null;
        }
    }
}
