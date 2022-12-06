using UnityEngine;

[RequireComponent(typeof(MeshRenderer))]
public class RopeSkin : MonoBehaviour
{
    private MeshRenderer _renderer;

    private void Awake() => _renderer = GetComponent<MeshRenderer>();

    public void Select(Skin skin) => _renderer.material = skin.Template;
}
