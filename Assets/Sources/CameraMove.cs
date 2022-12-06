using System;
using DG.Tweening;
using UnityEngine;

public class CameraMove : MonoBehaviour
{
    [SerializeField] private HooksList _hooksList;
    [SerializeField] private Vector3 _offset = new Vector3(0f,1f,-3f);
    [SerializeField] private Vector3 _rotate = new Vector3(3.7f, 0f, 0f);

    private void OnEnable()
    {
        _hooksList.Finished += OnFinished;
    }

    private void OnDisable()
    {
        _hooksList.Finished -= OnFinished;
    }

    private void OnFinished()
    {
       Sequence sequence = DOTween.Sequence();
       var currentTransform = transform;

       var currentPosition = currentTransform.position;
       var currentRotation = currentTransform.rotation.eulerAngles;

       var targetPosition = new Vector3(currentPosition.x,currentPosition.y + _offset.y,currentPosition.z + _offset.z);
       var targetRotation = new Vector3(currentRotation.x + _rotate.x, currentRotation.y, currentRotation.z);

        sequence.Append(transform.DOMove(targetPosition, 1f)).SetEase(Ease.InOutQuart);
        sequence.Append(transform.DORotate(targetRotation, 1f).SetEase(Ease.Linear));
    }
}
