public sealed class LevelRestartWindow : Window
{
    protected override void OnButtonClick()
    {
        CompositeRoot.LoadCurrentLevel();
    }
}
