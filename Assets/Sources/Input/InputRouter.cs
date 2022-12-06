using Sources.Interfaces;
using UnityEngine;
using UnityEngine.InputSystem;

public class InputRouter : MonoBehaviour
{
    [SerializeField] private MonoBehaviour _movementBehaviour;
    [SerializeField] private MonoBehaviour _shootingBehaviour;

    private PlayerInput _input;

    private bool _isEnable = true;

    public IMovable Movable => (IMovable)_movementBehaviour;
    public IShootable Shootable => (IShootable)_shootingBehaviour;

    private void OnValidate()
    {
        if (_movementBehaviour is IMovable)
            return;

        if (_shootingBehaviour is IShootable)
            return;

        _movementBehaviour = null;
        _shootingBehaviour = null;

        Debug.LogError("Value cannot be null");
    }

    private void OnEnable()
    {
        _input = new PlayerInput();
        _input.Enable();

        _input.Shooting.Enable();
        _input.Movement.Disable();

        _input.Movement.Move.started += OnStartMoved;
        _input.Shooting.Shoot.performed += OnShootPerformed;
       Shootable.ShootStopped += OnShootStopped;

    }

    private void OnDisable()
    {
       _input.Shooting.Shoot.performed -= OnShootPerformed;
       Shootable.ShootStopped -= OnShootStopped;

       _input.Movement.Move.started -= OnStartMoved;
    }


    public void Disable()
    {
        _isEnable = false;
        _input.Movement.Disable();

        _input.Shooting.Disable();
        _input.Disable();
    }

    private void OnShootPerformed(InputAction.CallbackContext obj)
    {
        Shootable.Shoot(Input.mousePosition);
    }

    private void OnShootStopped()
    {
        if(_isEnable == false)
            return;

        _input.Shooting.Disable();
        _input.Movement.Enable();
    }

    private void OnStartMoved(InputAction.CallbackContext ctx)
    {
        Movable.Move();
    }
}
