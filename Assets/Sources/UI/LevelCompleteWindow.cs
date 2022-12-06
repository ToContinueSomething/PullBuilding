public sealed class LevelCompleteWindow : Window
{
    protected override void OnButtonClick()
    {
        CompositeRoot.LoadNextLevel();
    }
}
