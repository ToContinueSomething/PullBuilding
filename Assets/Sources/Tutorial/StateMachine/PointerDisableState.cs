using System;
using Sources.Interfaces;

namespace Sources.Tutorial.StateMachine
{
    public class PointerDisableState : IState
    {
        private readonly Action _action;

        public PointerDisableState(Action action)
        {
            _action = action;
        }
        public void Enter() => Disable();

        private void Disable() => _action?.Invoke();
    }
}
