using System.Collections.Generic;
using UnityEngine;

public class UpgradeCounter : MonoBehaviour
{
    [SerializeField] private Wallet _wallet;
    [SerializeField] private Transform _container;
    [SerializeField] private TextPresenter _money;
    [SerializeField] private Counter[] _counters;
    [SerializeField] private CounterUpgradePresenter _template;

    private List<CounterUpgradePresenter> _counterPresenters;

    private void Start()
    {
        _counterPresenters = new List<CounterUpgradePresenter>();

        foreach (var counter in _counters)
        {
            var newCounterPresenter = Instantiate(_template, _container);
            newCounterPresenter.Init(counter, OnBuyButtonClick);
            _counterPresenters.Add(newCounterPresenter);
        }

        UpdateInfo();
    }

    private void OnBuyButtonClick(Counter counter)
    {
        if (counter.CanUpgrade == false)
            return;

        if (_wallet.TryBuy(counter.UpgradeCost) == false)
            return;

        counter.Upgrade();
        UpdateInfo();
    }

    private void UpdateInfo()
    {
        foreach (var counterPresenter in _counterPresenters)
            counterPresenter.UpdateInfo();

        _money.UpdateData(_wallet.Money);
    }
}
