using UnityEngine;
using DG.Tweening;
using Sources.Interfaces;

public class PointerMoveState : IState
{
    private readonly Camera _camera;
    private readonly Transform _target;
    private readonly Transform _currentTransform;
    private readonly PointerStateMachine _stateMachine;

    public PointerMoveState(PointerStateMachine stateMachine,Transform transform,Transform target)
    {
        _camera = Camera.main;
        _stateMachine = stateMachine;
        _currentTransform = transform;
        _target = target;
    }

    public void Enter() => Move();

    private void Move()
    {
         var target = _camera.WorldToScreenPoint(_target.position);
          _currentTransform.DOMove(target, 2f).OnComplete(() => _stateMachine.Enter<PointerClickState>());
    }
}
