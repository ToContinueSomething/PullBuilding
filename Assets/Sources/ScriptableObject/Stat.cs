using System;
using UnityEngine;

[CreateAssetMenu(fileName = "Stat", menuName = "Stats/Stat", order = 0)]
public class Stat : ScriptableObject
{
    [SerializeField] private string _name;
    [SerializeField] private int _value;
    [SerializeField] private int _maxValue;
    [SerializeField] private int _startCost;
    [SerializeField] private int _defaultValue;
    [SerializeField] private int _increase;
    [SerializeField] private Sprite _icon;

    private int _upgradeCost;

    public string Name => _name;
    public int UpgradeCost => _upgradeCost;
    public int Value => _value;
    public int DefaultValue => _defaultValue;
    public int MaxValue => _maxValue;
    public int StartCost => _startCost;
    public Sprite Icon => _icon;
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
