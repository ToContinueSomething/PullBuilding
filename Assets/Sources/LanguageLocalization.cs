using UnityEngine;
using Lean.Localization;

public class LanguageLocalization : MonoBehaviour
{
    private const string Russian = "Russian";
    private const string English = "English";

    private const string Ru = "ru";
    private const string En = "en";

    private void Awake()
    {
        LeanLocalization.SetCurrentLanguageAll(Russian);
    }
}
