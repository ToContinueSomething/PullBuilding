using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelTask : MonoBehaviour
{
    [SerializeField] private int _percentForComplete;

    private bool _isComplete;

    public event Action<int> Updated;
    public event Action Completed;

    public bool IsComplete => _isComplete;
    public int PercentForComplete => _percentForComplete;

    public void UpdateInfo(int percentRuinedBuilding)
    {
        Updated?.Invoke(percentRuinedBuilding);

        if (percentRuinedBuilding < _percentForComplete)
            return;

        _isComplete = true;
        Completed?.Invoke();
    }
}
