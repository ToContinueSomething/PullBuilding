using System;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class SkinPresenter : MonoBehaviour
{
    [SerializeField] private TMP_Text _levelForUnlock;
    [SerializeField] private TMP_Text _name;
    [SerializeField] private UIButton _button;
    [SerializeField] private Image _lockIcon;
    [SerializeField] private Image _icon;

    private Skin _skin;
    private Action<Skin> _select;

    private void OnEnable()
    {
        _button.Clicked += OnButtonClick;
    }

    private void OnDisable()
    {
        _button.Clicked -= OnButtonClick;
    }

    public void Init(Skin skin,Action<Skin> action,bool isLock)
    {
        _skin = skin;

        _name.text = skin.Name;
        _levelForUnlock.text = _skin.UnlockLevel.ToString() + " lvl";
        _icon.sprite = _skin.Icon;
        _icon.color = _skin.Color;

        if (isLock)
        {
            _lockIcon.gameObject.SetActive(true);
        }
        else
        {
            _select = action;
            _lockIcon.gameObject.SetActive(false);
        }
    }

    private void OnButtonClick()
    {
        _select?.Invoke(_skin);
    }
}
