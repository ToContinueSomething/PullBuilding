using System;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class StatUpgradePresenter : MonoBehaviour
{
    [SerializeField] private TMP_Text _name;
    [SerializeField] private TMP_Text _currentValue;
    [SerializeField] private TMP_Text _cost;
    [SerializeField] private UIButton _button;
    [SerializeField] private Image _icon;

    private Action<Stat> _buy;
    private Stat _ability;

    private void OnEnable()
    {
        _button.Clicked += OnButtonClick;
    }

    private void OnDisable()
    {
        _button.Clicked -= OnButtonClick;
    }

    public void Init(Stat ability,Action<Stat> action)
    {
        _ability = ability;
        _buy = action;
    }

    public void UpdateInfo()
    {
        _name.SetText(_ability.Name);
        _currentValue.SetText(_ability.Value.ToString() + "/" + _ability.MaxValue);
        _cost.SetText(_ability.UpgradeCost.ToString());
        _icon.sprite = _ability.Icon;
    }

    private void OnButtonClick()
    {
        _buy(_ability);
    }
}
