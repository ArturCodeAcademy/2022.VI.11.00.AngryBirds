using System.Collections.Generic;
using UnityEngine;

[DisallowMultipleComponent]
public class PigLevelPool : MonoBehaviour
{
    public static PigLevelPool Instance { get; private set; }
    [SerializeField] private GameObject _panel;
    private HashSet<Transform> _pigs;

    void Awake()
    {
        Instance = this;
        _pigs = new HashSet<Transform>();
    }

    public void Add(Transform pig) => _pigs.Add(pig);

    public void Remove(Transform pig)
    { 
        _pigs.Remove(pig);
        if (_pigs.Count <= 0 && _panel != null)
            _panel.SetActive(true);
    }
}
