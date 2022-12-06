using System;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class UpgradeStats : MonoBehaviour
{
    [SerializeField] private Wallet _wallet;
    [SerializeField] private Stat[] _stats;
    [SerializeField] private StatUpgradePresenter _statPresenterTemplate;
    [SerializeField] private Transform _container;
    [SerializeField] private TMP_Text _moneyText;

    private List<StatUpgradePresenter> _statsPresenters;

    private void Start()
    {
        _statsPresenters = new List<StatUpgradePresenter>();

        foreach (Stat state in _stats)
        {
            StatUpgradePresenter newStatPresenter = Instantiate(_statPresenterTemplate, _container);
            newStatPresenter.Init(state, OnBuyButtonClicked);
            _statsPresenters.Add(newStatPresenter);
        }

        UpdateData();
    }

    private void OnBuyButtonClicked(Stat ability)
    {
        if (ability.CanUpgrade == false)
            return;

        if (_wallet.TryBuy(ability.UpgradeCost) == false)
            return;

        ability.Upgrade();
        UpdateData();
    }

    private void UpdateData()
    {
        foreach (StatUpgradePresenter ability in _statsPresenters)
            ability.UpdateInfo();

        _moneyText.SetText(_wallet.Money.ToString());
    }
}
