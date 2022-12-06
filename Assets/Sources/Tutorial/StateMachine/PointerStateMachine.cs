using System;
using System.Collections.Generic;
using Sources.Interfaces;
using Sources.Tutorial.StateMachine;
using UnityEngine;

public class PointerStateMachine : MonoBehaviour,ICoroutineRunner
{
    [SerializeField] private Transform _buildingTransform;
    [SerializeField] private Player _player;
    [SerializeField] private InputRouter _inputRouter;
    [SerializeField] private Animator _animator;

    private Dictionary<Type,IState> _states;

    private void Awake()
    {
        Transform currentTransform = transform;

        _states = new Dictionary<Type,IState>()
        {
            [typeof(PointerMoveState)] = new PointerMoveState(this,currentTransform,_buildingTransform),
            [typeof(PointerClickState)] = new PointerClickState(this,_inputRouter,_animator,currentTransform),
            [typeof(PointerPressState)] = new PointerPressState(this,_player,_inputRouter,this,_animator),
            [typeof(PointerDisableState)] = new PointerDisableState(OnDisableStateMachine)
        };

        Enter<PointerMoveState>();
    }

    public void Enter<TState>() where TState : IState
    {
        IState state = _states[typeof(TState)];
        state.Enter();
    }

    private void OnDisableStateMachine() => enabled = false;
}
