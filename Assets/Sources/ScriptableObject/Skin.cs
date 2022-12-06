using UnityEngine;

[CreateAssetMenu(fileName = "Skin", menuName = "Skins/Skin", order = 0)]
public class Skin: ScriptableObject
{
    [SerializeField] private string _name;
    [SerializeField] private Sprite _icon;
    [SerializeField] private Color _color;
    [SerializeField] private int _unlockLevel;
    [SerializeField] private Material _template;

    public int UnlockLevel => _unlockLevel;
    public string Name => _name;
    public Sprite Icon => _icon;
    public Color Color => _color;
    public Material Template => _template;
}
