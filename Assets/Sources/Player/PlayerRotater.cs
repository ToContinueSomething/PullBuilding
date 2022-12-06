using System;
using DG.Tweening;
using UnityEngine;

public class PlayerRotater : MonoBehaviour
{
    private const float RotateDuration = 0.6f;

    public event Action Turned;

    public void Look(Vector3 target)
    {
        Turned?.Invoke();
        Tween tween = transform.DOLookAt(target, RotateDuration);
        tween.OnComplete(() => tween.Kill());
    }
}
