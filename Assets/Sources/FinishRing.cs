using System;
using UnityEngine;

namespace Sources
{
    public class FinishRing : MonoBehaviour
    {
        [SerializeField] private ParticleSystem _ring;
        [SerializeField] private LevelTask _levelTask;
        [SerializeField] private Player _player;

        private void OnEnable()
        {
            _levelTask.Completed += OnLevelCompleted;
            _player.Started += OnPlayerMoveStarted;
            _player.MoveCompleted += OnPlayerMoveCompleted;
        }

        private void OnDisable()
        {
            _levelTask.Completed -= OnLevelCompleted;
            _player.Started -= OnPlayerMoveStarted;
            _player.MoveCompleted -= OnPlayerMoveCompleted;

        }

        private void OnLevelCompleted()
        {
            _ring.Stop();
        }

        private void OnPlayerMoveCompleted()
        {
            _ring.Stop();
        }

        private void OnPlayerMoveStarted()
        {
            _ring.Play();
        }
    }
}
