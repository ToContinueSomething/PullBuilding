using Obi;
using UnityEngine;

public class Rope : MonoBehaviour
{
    [SerializeField] private Hook _hook;
    [SerializeField] private Transform _rocketPoint;
    [SerializeField] private float _maxStretch;

    private ObiRope _rope;

    private void Awake() => _rope = GetComponent<ObiRope>();

    private void OnEnable() => _hook.PlayerShooted += OnPlayerShooted;

    private void OnDisable() => _hook.PlayerShooted -= OnPlayerShooted;

    private void Start()
    {

        if(_hook.gameObject.activeSelf == false)
            gameObject.SetActive(false);
    }

    private void OnPlayerShooted(Vector3 obj)
    {
        _hook.transform.SetParent(transform);
        Stretch();
    }

    private void Stretch() => _rope.stretchCompliance = _maxStretch;
}
