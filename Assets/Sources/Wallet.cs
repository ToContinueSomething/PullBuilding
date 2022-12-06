using UnityEditor;
using UnityEngine;
using System;

public class Wallet : MonoBehaviour
{
    private int _money;

    public int Money => _money;

    public void Init(int money)
    {
        _money = money;
    }

    public bool TryBuy(int price)
    {
        if (price < 0)
            throw new InvalidOperationException();

        if (Money < price)
            return false;

        _money -= price;
        return true;
    }

    public void AddMoney(int money)
    {
        if (money < 0)
            throw new InvalidOperationException();

        _money += money;
    }
}
