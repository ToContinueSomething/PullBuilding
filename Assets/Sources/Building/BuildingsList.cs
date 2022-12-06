using System.Collections.Generic;
using UnityEngine;
using System;
using System.Linq;
using Random = UnityEngine.Random;

public class BuildingsList : MonoBehaviour
{
    [SerializeField] private Player _player;
    [SerializeField] private Level _playerLevel;
    [SerializeField] private Transform _container;

    private List<Building> _buildings;

    private int _percentDestroyed = 0;
    private int _countAllBuildingPart;
    private int _reward;

    private const int HundredPercent = 100;
    private const int OneBuilding = 1;

    public event Action<int> PercentChanged;

    public int Reward => _reward;

    private void Awake()
    {
        _buildings = _container.GetComponentsInChildren<Building>().ToList();
    }

    private void OnEnable()
    {
        _player.Moved += OnPlayerMoved;

        foreach (var building in _buildings)
        {
            building.PartRuined += OnBuildingPartRuined;
        }
    }

    private void OnDisable()
    {
        _player.Moved -= OnPlayerMoved;

        foreach (var building in _buildings)
        {
            building.PartRuined -= OnBuildingPartRuined;
        }
    }

    private void Start()
    {
        foreach (var building in _buildings)
        {
            _countAllBuildingPart += building.CountParts;
        }
    }

    public Transform GetRandomPositionPart()
    {
        int randomIndex = Random.Range(0, _buildings.Count);
        return _buildings[randomIndex].GetRandomPositionPart();
    }

    private void OnBuildingPartRuined(int reward)
    {
        _reward += reward;
      _playerLevel.AddExp(reward);

      _percentDestroyed += HundredPercent * OneBuilding / _countAllBuildingPart;

        PercentChanged?.Invoke(_percentDestroyed);
    }

    private void OnPlayerMoved(int force)
    {
        foreach (var building in _buildings)
        {
            building.Fall(force);
        }
    }
}
