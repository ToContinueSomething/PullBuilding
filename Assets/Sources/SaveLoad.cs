using UnityEngine;

public class SaveLoad : MonoBehaviour
{
    [SerializeField] private Wallet _wallet;
    [SerializeField] private ProgressBar _progressBar;
    [SerializeField] private Counter _hookCounter;
    [SerializeField] private Stat _pullForce;
    [SerializeField] private Stat _agility;
    [SerializeField] private RopeSkinList _skinList;
    [SerializeField] private Stage _stage;
    [SerializeField] private Level _playerLevel;

    private const string Money = "Money";
    private const string PullForce = "PullForce";
    private const string Agility = "Agility";
    private const string PlayerLevel = "PlayerLevel";
    private const string AgilityUpgradeCost = "AgilityUpgradeCost";
    private const string PullForceUpgradeCost = "PullForceUpgradeCost";
    private const string PlayerValueForLevelUp = "PlayerValueForLevelUp";
    private const string PlayerExp = "PlayerExp";
    private const string Stage = "Stage";
    private const string RopeSkins = "RopeSkins";
    private const string HookCounter = "HookCounter";
    private const string CounterUpgradeCost = "CounterUpgradeCost";

    private const int DefaultLevel = 1;
    private const int DefaultValueForLevelUp = 30;

    public int GetStage => PlayerPrefs.GetInt(Stage, DefaultLevel);

    public void Save()
    {
        PlayerPrefs.SetInt(Money, _wallet.Money);
        PlayerPrefs.SetInt(PlayerLevel, _playerLevel.Value);
        PlayerPrefs.SetInt(PlayerValueForLevelUp, _playerLevel.ValueForLevelUp);
        PlayerPrefs.SetInt(PlayerExp, _playerLevel.Exp);
        PlayerPrefs.SetInt(Stage, _stage.NextStage);
        PlayerPrefs.SetInt(Agility, _agility.Value);
        PlayerPrefs.SetInt(PullForce, _pullForce.Value);
        PlayerPrefs.SetInt(AgilityUpgradeCost, _agility.UpgradeCost);
        PlayerPrefs.SetInt(PullForceUpgradeCost, _pullForce.UpgradeCost);
        PlayerPrefs.SetInt(RopeSkins, _skinList.CurrentIndex);
        PlayerPrefs.SetInt(HookCounter,_hookCounter.Value);
        PlayerPrefs.SetInt(CounterUpgradeCost,_hookCounter.UpgradeCost);
    }

    public void Load()
    {
        _progressBar.Init(_stage.NextIndexStage);
        _skinList.Init(PlayerPrefs.GetInt(RopeSkins));
        _hookCounter.Init(PlayerPrefs.GetInt(HookCounter,_hookCounter.DefaultValue),PlayerPrefs.GetInt(CounterUpgradeCost));
        _wallet.Init(PlayerPrefs.GetInt(Money));
        _agility.Init(PlayerPrefs.GetInt(Agility, _agility.DefaultValue), PlayerPrefs.GetInt(AgilityUpgradeCost));
        _pullForce.Init(PlayerPrefs.GetInt(PullForce, _pullForce.DefaultValue), PlayerPrefs.GetInt(PullForceUpgradeCost));
        _playerLevel.Init(PlayerPrefs.GetInt(PlayerLevel, DefaultLevel), PlayerPrefs.GetInt(PlayerExp), PlayerPrefs.GetInt(PlayerValueForLevelUp, _playerLevel.ValueForLevelUp));
    }

    public void Reset()
    {
        PlayerPrefs.SetInt(HookCounter, _hookCounter.DefaultValue);
        PlayerPrefs.SetInt(Money, 0);
        PlayerPrefs.SetInt(PlayerLevel, DefaultLevel);
        PlayerPrefs.SetInt(PlayerValueForLevelUp, DefaultValueForLevelUp);
        PlayerPrefs.SetInt(PlayerExp, 0);
        PlayerPrefs.SetInt(Stage, DefaultLevel);
        PlayerPrefs.SetInt(AgilityUpgradeCost, _agility.StartCost);
        PlayerPrefs.SetInt(PullForceUpgradeCost, _pullForce.StartCost);
        PlayerPrefs.SetInt(PullForce, _pullForce.DefaultValue);
        PlayerPrefs.SetInt(Agility, _agility.DefaultValue);
        PlayerPrefs.SetInt(RopeSkins, 0);
        PlayerPrefs.SetInt(CounterUpgradeCost, _hookCounter.StartCost);
    }
}
