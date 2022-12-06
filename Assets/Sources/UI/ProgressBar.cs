using UnityEngine;
using DG.Tweening;
using TMPro;
using UnityEngine.UI;

public class ProgressBar : MonoBehaviour
{
    [SerializeField] private LevelTask _levelTask;
    [SerializeField] private Slider _bar;
    [SerializeField] private TMP_Text _level;

    private const float DividerForHundred = 100;

    private void Awake()
    {
        float percentForComplete = (float)_levelTask.PercentForComplete;
        percentForComplete /= DividerForHundred;

        _bar.maxValue = percentForComplete;
    }

    private void OnEnable()
    {
        _levelTask.Updated += OnLevelTaskUpdated;
    }

    private void OnDisable()
    {
        _levelTask.Updated -= OnLevelTaskUpdated;
    }

    public void Init(int nextLevel)
    {
        _level.text = nextLevel.ToString();
    }

    private void OnLevelTaskUpdated(int percent)
    {
        float value = (float)percent / DividerForHundred;
        _bar.DOValue(value, 2f);

    }
}
