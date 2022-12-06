using UnityEngine;
using System;
using Random = UnityEngine.Random;

public class Building : MonoBehaviour
{
    private BuildingPart[] _parts;

    public event Action<int> PartRuined;

    private int _reward = 0;
    private int _amountDroppedPart = 0;

    public int CountParts => _parts.Length;

    private int _halfParts => _parts.Length / 2;

    private void Awake()
    {
        _parts = GetComponentsInChildren<BuildingPart>();
    }

    private void OnEnable()
    {
        for (int i = 0; i < _parts.Length; i++)
        {
            _parts[i].Ruined += OnRuined;
        }
    }

    private void OnDisable()
    {
        for (int i = 0; i < _parts.Length; i++)
        {
            _parts[i].Ruined -= OnRuined;
        }
    }


    public void Fall(int force)
    {
        foreach (var part in _parts)
        {
            part.Enable();

            if (part.CanDown)
            {
                part.Fall(force);
            }
        }
    }

    public Transform GetRandomPositionPart()
    {
        int randomIndex = Random.Range(0, _parts.Length);

      return _parts[randomIndex].transform;
    }

    private void OnRuined(int reward)
    {
        _amountDroppedPart++;
        _reward += reward;

        if (ContainsFallingParts(_amountDroppedPart,_halfParts))
            PartRuined?.Invoke(_reward);
    }

    private bool ContainsFallingParts(int amountDroppedPart,int rightAmount)
    {
        var countPart = _parts.Length;

        if (rightAmount > countPart)
            rightAmount = countPart;

        return amountDroppedPart >= rightAmount;
    }
}
