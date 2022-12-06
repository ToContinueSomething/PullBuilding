using System;
using Sources;
using UnityEngine;

public class CompositeRoot : MonoBehaviour
{
    [SerializeField] private Player _player;
    [SerializeField] private Wallet _wallet;
    [SerializeField] private InputRouter _input;
    [SerializeField] private LevelCompleteWindow _levelCompleteWindow;
    [SerializeField] private LevelRestartWindow _levelRestartWindow;
    [SerializeField] private BuildingsList _buildingsList;
    [SerializeField] private PlayerMovement _movement;
    [SerializeField] private TextPresenter _walletPresenter;
    [SerializeField] private TextPresenter _playerLevelPresenter;
    [SerializeField] private LevelTask _levelTask;
    [SerializeField] private Level _playerLevel;
    [SerializeField] private SaveLoad _saveLoad;
    [SerializeField] private Stage _stage;
    [SerializeField] private FinishRing _finishRing;

    private void OnEnable()
    {
        _player.MoveCompleted += OnPlayerMoveCompleted;
        _buildingsList.PercentChanged += OnBuildingPercentChanged;
    }

    private void OnDisable()
    {
        _buildingsList.PercentChanged -= OnBuildingPercentChanged;
        _player.MoveCompleted -= OnPlayerMoveCompleted;
    }

    private void Start()
    {
        _saveLoad.Load();
    }

    public void LoadNextLevel()
    {
        _saveLoad.Save();
        _stage.LoadNext();
    }

    public void LoadCurrentLevel()
    {
        _saveLoad.Save();
        _stage.LoadCurrent();
    }

    private void OnPlayerMoveCompleted()
    {
        if (_levelTask.IsComplete == false)
        {
            CompleteGame(_levelRestartWindow);
            _buildingsList.enabled = false;
        }
    }

    private void OnBuildingPercentChanged(int percent)
    {
        _levelTask.UpdateInfo(percent);

        if (_levelTask.IsComplete)
        {
            CompleteGame(_levelCompleteWindow);
            _buildingsList.enabled = false;
        }
    }

    private void CompleteGame(Window window)
    {
        _finishRing.enabled = false;
        _movement.enabled = false;
        _input.Disable();

        int money = _buildingsList.Reward;
        _wallet.AddMoney(money);

        _playerLevelPresenter.UpdateData(_playerLevel.Value);
        _walletPresenter.UpdateData(_wallet.Money);

        window.Show(money, _playerLevel);
        _saveLoad.Save();
    }
}
