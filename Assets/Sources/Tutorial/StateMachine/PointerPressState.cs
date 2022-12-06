using Sources.Interfaces;
using Sources.Tutorial.StateMachine;
using UnityEngine;

public class PointerPressState : IState
{
    private readonly InputRouter _inputRouter;
    private readonly PointerStateMachine _stateMachine;
    private readonly Player _player;
    private readonly Animator _animator;
    private readonly int _press = Animator.StringToHash("Press");

    public PointerPressState(PointerStateMachine stateMachine,Player player, InputRouter inputRouter,ICoroutineRunner coroutineRunner,Animator animator)
    {
        _stateMachine = stateMachine;
        _inputRouter = inputRouter;
        _player = player;
        _animator = animator;
        _player.MoveCompleted += OnMoveCompleted;
    }

    private void OnMoveCompleted()
    {
        _player.MoveCompleted -= OnMoveCompleted;
        _stateMachine.Enter<PointerDisableState>();
    }

    public void Enter()
    {
        _animator.SetTrigger(_press);
        _inputRouter.Movable.Move();
    }
}
