using System;
using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Stage : MonoBehaviour
{
    private int _value;

    private const int LoaderStage = 1;

    public int CountStage => SceneManager.sceneCountInBuildSettings - LoaderStage;

    public int NextStage => CountStage > _value ? _value + 1 : _value;
    public int NextIndexStage => _value + 1;

    private void Awake()
    {
        _value = SceneManager.GetActiveScene().buildIndex;
    }

    public void LoadNext()
    {
        _value = NextStage;

       Load(_value);
    }

    public void LoadCurrent()
    {
        Load(_value);
    }

    public void Load(int value)
    {
        if (value > CountStage)
            throw new ArgumentOutOfRangeException(nameof(value));

        SceneManager.LoadScene(value);
    }
}
