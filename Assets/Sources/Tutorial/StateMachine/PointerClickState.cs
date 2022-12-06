using Sources.Interfaces;
using UnityEngine;

public class PointerClickState : IState
{
    private readonly Animator _animator;
    private readonly Transform _currentTransform;
    private readonly InputRouter _inputRouter;
    private readonly PointerStateMachine _stateMachine;

    private readonly int _click = Animator.StringToHash("Click");

    public PointerClickState(PointerStateMachine stateMachine, InputRouter inputRouter, Animator animator,
        Transform transform)
    {
        _inputRouter = inputRouter;
        _animator = animator;
        _currentTransform = transform;
        _stateMachine = stateMachine;
    }

    public void Enter()
    {
        _animator.SetTrigger(_click);
        _inputRouter.Shootable.Shoot(_currentTransform.position);
        _stateMachine.Enter<PointerPressState>();
    }
}
