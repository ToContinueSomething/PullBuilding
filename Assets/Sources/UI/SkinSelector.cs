using System.Collections.Generic;
using UnityEngine;

public class SkinSelector : MonoBehaviour
{
    [SerializeField] private RopeSkinList _ropesList;
    [SerializeField] private Skin[] _skins;
    [SerializeField] private Transform _container;
    [SerializeField] private SkinPresenter _template;
    [SerializeField] private Level _playerLevel;

    private List<SkinPresenter> _skinPresenters;

    private void Start()
    {
        _skinPresenters = new List<SkinPresenter>();

        for (int i = 0; i < _skins.Length; i++)
        {
           var newSkinPresenter = Instantiate(_template, _container);
           _skinPresenters.Add(newSkinPresenter);
        }
    }

    public void Show()
    {
        for (int i = 0; i < _skins.Length; i++)
        {
            _skinPresenters[i].Init(_skins[i],OnSelectButtonClick,_playerLevel.Value < _skins[i].UnlockLevel ? true : false);
        }
    }

    private void OnSelectButtonClick(Skin skin)
    {
        _ropesList.Change(skin);
    }
}

