using System.Collections.Generic;
using System;
using UnityEngine;

public class RopeSkinList : MonoBehaviour
{
    [SerializeField] private List<RopeSkin> _ropes;
    [SerializeField] private Skin[] _skins;

    private int _currentIndex;
    
    public int CurrentIndex => _currentIndex;

    public void Change(Skin skin)
    {
        int index = Array.FindIndex(_skins, s => s == skin);

        if (index == -1)
            throw new IndexOutOfRangeException(nameof(skin));

        _currentIndex = index;
    }

    public void Init(int indexSkin)
    {
        if (indexSkin > _skins.Length)
            throw new IndexOutOfRangeException(nameof(indexSkin));

        _currentIndex = indexSkin;

        Skin skin = _skins[_currentIndex];

        foreach (var ropeSkin in _ropes)
            ropeSkin.Select(skin);
    }
}
