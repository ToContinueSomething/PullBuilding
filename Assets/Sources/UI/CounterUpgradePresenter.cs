using System;
using TMPro;
using UnityEngine;

public class CounterUpgradePresenter : MonoBehaviour
{
    [SerializeField] private TMP_Text _name;
    [SerializeField] private TMP_Text _quantity;
    [SerializeField] private TMP_Text _cost;
    [SerializeField] private UIButton _button;

    private Counter _counter;
    private Action<Counter> _buy;

    private void OnEnable()
    {
        _button.Clicked += OnButtonClick;
    }

    private void OnDisable()
    {
        _button.Clicked += OnButtonClick;
    }

    public void Init(Counter counter,Action<Counter> action)
    {
        _counter = counter;
        _buy = action;
    }

    public void UpdateInfo()
    {
        _name.text = _counter.Name;

       var count = Lean.Localization.LeanLocalization.GetTranslationText("Count");
       var cost = Lean.Localization.LeanLocalization.GetTranslationText("Cost");

        _quantity.text = count +" : " + _counter.Value.ToString() + " / " + _counter.MaxValue;
        _cost.text = cost + " : " +_counter.UpgradeCost.ToString();
    }

    private void OnButtonClick()
    {
        _buy(_counter);
    }
}
