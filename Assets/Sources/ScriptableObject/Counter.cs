using System;
using UnityEngine;

[CreateAssetMenu(fileName = "Counter", menuName = "Counters/Counter", order = 0)]
public class Counter : ScriptableObject
{
    [SerializeField] private string _name;
    [SerializeField] private int _value;
    [SerializeField] private int _maxValue;
    [SerializeField] private int _startCost;
    [SerializeField] private int _defaultValue;
    [SerializeField] private int _increase;

    private int _upgradeCost;

    public string Name => _name;
    public int UpgradeCost => _upgradeCost;
    public int Value => _value;
    public int DefaultValue => _defaultValue;
    public int MaxValue => _maxValue;
    public int StartCost => _startCost;
    public bool CanUpgrade => _value + _increase <= _maxValue;

    public void Init(int value, int upgradeCost)
    {
        _value = value;
        _upgradeCost = upgradeCost;
    }

    public void Upgrade()
    {
        if (CanUpgrade == false)
            throw new InvalidOperationException();

        _value += _increase;
        _upgradeCost += _upgradeCost;
    }
}
