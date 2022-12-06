using UnityEngine;

public class Tutorial : MonoBehaviour
{
    [SerializeField] private InputRouter _inputRouter;
    [SerializeField] private UIButton _skipButton;
    [SerializeField] private CompositeRoot _compositeRoot;

    private void OnEnable()
    {
        _skipButton.Clicked += OnButtonClicked;
       _inputRouter.Disable();
    }

    private void OnDisable()
    {
        _skipButton.Clicked -= OnButtonClicked;
    }

    private void OnButtonClicked()
    {
        _compositeRoot.LoadNextLevel();
    }
}
