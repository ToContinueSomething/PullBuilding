using System;
using UnityEngine;

public class Level : MonoBehaviour
{
    private int _value;
    private int _exp;
    private int _valueForLevelUp;

    public int ValueForLevelUp => _valueForLevelUp;
    public int Value => _value;
    public int Exp => _exp;

    public void Init(int value, int exp, int valueForLevelUp)
    {
        _value = value;
        _exp = exp;
        _valueForLevelUp = valueForLevelUp;
    }

    public void AddExp(int value)
    {
        int accumulation = value;

        while (accumulation > 0)
        {
            _exp++;
            accumulation--;

            if (_exp >= _valueForLevelUp)
            {
                _value++;
                _valueForLevelUp += _valueForLevelUp;
            }
        }
    }
}
