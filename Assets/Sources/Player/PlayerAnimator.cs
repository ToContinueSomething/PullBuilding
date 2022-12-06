using UnityEngine;

[RequireComponent(typeof(Animator))]
[RequireComponent(typeof(PlayerMovement))]
[RequireComponent(typeof(PlayerRotater))]
public class PlayerAnimator : MonoBehaviour
{
    private Animator _animator;
    private Player _player;
    private PlayerRotater _rotater;
    private PlayerMovement _movement;

    private readonly int _walk = Animator.StringToHash("Walk");
    private readonly int _putGun = Animator.StringToHash("PutGun");
    private readonly int _shot = Animator.StringToHash("Shot");

    private void Awake()
    {
        _rotater = GetComponent<PlayerRotater>();
        _player = GetComponent<Player>();
        _animator = GetComponent<Animator>();
        _movement = GetComponent<PlayerMovement>();
    }

    private void OnEnable()
    {
        _player.MoveCompleted += OnMoveCompleted;
        _rotater.Turned += OnTurned;
        _movement.Moved += OnMoved;
        _movement.EndMoved += OnEndMoved;
    }

    private void OnDisable()
    {
        _player.MoveCompleted -= OnMoveCompleted;
        _rotater.Turned -= OnTurned;
        _movement.Moved -= OnMoved;
        _movement.EndMoved -= OnEndMoved;
    }

    public void PlayShot() => _animator.SetTrigger(_shot);

    private void OnEndMoved() => _animator.SetBool(_walk, false);

    private void OnTurned() => _animator.SetBool(_putGun, true);

    private void OnMoved() => PlayAnimationWalk();

    private void StopWalk() => _animator.SetBool(_walk, false);

    private void PlayAnimationWalk() => _animator.SetBool(_walk, true);

    private void OnMoveCompleted()
    {
        StopWalk();
        enabled = false;
    }
}
