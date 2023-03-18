using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PigRegistration : MonoBehaviour
{
    void Start() => PigLevelPool.Instance?.Add(transform);
    void OnDestroy() => PigLevelPool.Instance?.Remove(transform);
}
