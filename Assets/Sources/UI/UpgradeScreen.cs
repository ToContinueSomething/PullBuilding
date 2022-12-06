using System;
using UnityEngine;

public class UpgradeScreen : MonoBehaviour
{
   [SerializeField] private UIButton _okButton;
   [SerializeField] private SkinSelector _skinSelector;

    private Window _currentWindow;

    private void OnEnable()
    {
        _okButton.Clicked += OnButtonClick;
    }

    private void OnDisable()
    {
        _okButton.Clicked += OnButtonClick;
    }

    public void Show()
    {
        gameObject.SetActive(true);
        _skinSelector.Show();
    }

    public void Init(Window currentWindow)
    {
        _currentWindow = currentWindow;
    }

    private void OnButtonClick()
    {
        if (_currentWindow == null)
            throw new ArgumentNullException(nameof(_currentWindow));

        gameObject.SetActive(false);
        _currentWindow.gameObject.SetActive(true);
    }
}
